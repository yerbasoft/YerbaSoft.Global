using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using YerbaSoft.DTO.Types;

namespace YerbaSoft.Windows.API
{
    public class MemoryManager
    {
        [DllImport("Kernel32.dll")]
        static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, UInt32 nSize, ref UInt32 lpNumberOfBytesRead);
        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, UInt32 size, ref UInt32 lpNumberOfBytesWritten);
        [DllImport("Kernel32.dll", EntryPoint = "ReadProcessMemory")]
        static extern bool ReadProcessMemoryInts(IntPtr hProcess, IntPtr lpBaseAddress, uint[] lpBuffer, UInt32 nSize, ref UInt32 lpNumberOfBytesRead);

        private Process Process;
        private IntPtr hProcess;

        public MemoryManager(Process process)
        {
            this.Process = process;
            this.hProcess = process.Handle;
        }

        public UInt32 Write(IntPtr address, byte[] buffer)
        {
            UInt32 written = default;
            WriteProcessMemory(hProcess, address, buffer, Convert.ToUInt32(buffer.Length), ref written);
            return written;
        }
        public UInt32 Write(IntPtr address, byte value) => Write(address, new byte[] { value });
        public UInt32 Write(IntPtr address, short value) => Write(address, BitConverter.GetBytes(value));
        public UInt32 Write(uint address, uint value) => Write(new IntPtr(address), value);
        public UInt32 Write(IntPtr address, uint value) => Write(address, BitConverter.GetBytes(value));
        public UInt32 Write(IntPtr address, float value) => Write(address, BitConverter.GetBytes(value));
        public UInt32 Write(uint address, float value) => Write(new IntPtr(address), value);
        public UInt32 Write(IntPtr address, ulong value) => Write(address, BitConverter.GetBytes(value));
        public UInt32 Write(IntPtr address, double value) => Write(address, BitConverter.GetBytes(value));

        public byte[] ReadBytes(IntPtr address, UInt32 size)
        {
            uint readed = default;
            var buffer = new byte[size];
            ReadProcessMemory(this.hProcess, address, buffer, size, ref readed);
            return buffer;
        }
        public uint[] ReadInts(uint address, UInt32 size) => ReadInts(new IntPtr(address), size);
        public uint[] ReadInts(IntPtr address, UInt32 size)
        {
            uint readed = default;
            var buffer = new uint[size / 4];
            ReadProcessMemoryInts(this.hProcess, address, buffer, size, ref readed);
            return buffer;
        }
        public byte ReadByte(IntPtr address) => ReadBytes(address, 1)[0];
        public short ReadShort(IntPtr address) => BitConverter.ToInt16(ReadBytes(address, 2), 0);
        public uint ReadInt(IntPtr address) => BitConverter.ToUInt32(ReadBytes(address, 4), 0);
        public uint ReadInt(uint address) => BitConverter.ToUInt32(ReadBytes(new IntPtr(address), 4), 0);
        public ulong ReadLong(IntPtr address) => BitConverter.ToUInt64(ReadBytes(address, 8), 0);
        public string ReadString(uint address, uint maxsize) => ReadString(new IntPtr(address), maxsize);
        public string ReadString(IntPtr address, uint maxsize)
        {
            var buffer = ReadBytes(address, maxsize);
            string res = string.Empty;

            for(int i = 0; i < maxsize; i += 2)
            {
                var v = BitConverter.ToChar(buffer, i);
                if (v == 0)
                    return res;

                res += BitConverter.ToChar(buffer, i);
            }

            return res;
        }

        public T ReadStruct<T>(uint address)
        {
            var bytes = ReadBytes(new IntPtr(address), Convert.ToUInt32(Marshal.SizeOf(typeof(T))));
            return Helpers.StructTools.RawDeserialize<T>(bytes, 0);
        }



        private Thread CheckChangesThread;
        private readonly object CheckChangeLock = 1;
        private FourList<Guid, IntPtr, Action<object>, Type> CheckChange = new FourList<Guid, IntPtr, Action<object>, Type>();

        /*
        public Guid OnMemoryChange(IntPtr address, Action<object> action)
        {
            if (CheckChangesThread == null)
            {
                CheckChangesThread = new Thread(_OnMemoryChange) { Priority = ThreadPriority.Lowest };
                CheckChangesThread.Start();
            }

            var id = Guid.NewGuid();
            lock (CheckChangeLock)
                CheckChange.Add(id, address, action, typeof(byte));

            return id;
        }
        */

        public Guid OnMemoryChange<T>(IntPtr address, Action<object> action)
        {
            if (CheckChangesThread == null)
            {
                CheckChangesThread = new Thread(_OnMemoryChange) { Priority = ThreadPriority.Lowest };
                CheckChangesThread.Start();
            }

            var id = Guid.NewGuid();
            lock (CheckChangeLock)
                CheckChange.Add(id, address, action, typeof(T));

            return id;
        }

        public bool ExistsMemoryCheck(Guid id)
        {
            lock (CheckChangeLock)
                return CheckChange.Any(p => p.V1 == id);
        }
        public void RemoveMemoryChange(Guid id)
        {
            lock (CheckChangeLock)
            {
                if (CheckChange.Any(p => p.V1 == id))
                    CheckChange.Remove(CheckChange.Single(p => p.V1 == id));
            }
        }

        private void _OnMemoryChange()
        {
            var checks = new FiveList<Guid, IntPtr, Action<object>, Type, object>();
            while (true)
            {
                Thread.Sleep(100);

                lock (CheckChangeLock)
                {
                    checks.AddRange(CheckChange.Where(c => !checks.Select(p => p.V1).Contains(c.V1)).Select(p => new Five<Guid, IntPtr, Action<object>, Type, object>(p.V1, p.V2, p.V3, p.V4, null)));
                    checks.RemoveRange(checks.Where(p => !CheckChange.Select(c => c.V1).Contains(p.V1)));
                }

                foreach (var check in checks)
                {
                    object invokeValue = null;

                    switch (check.V4.Name.ToUpper())
                    {
                        case "BYTE":
                            var value = ReadByte(check.V2);
                            if (check.V5 == null || value != (byte)check.V5)
                                invokeValue = value;
                            break;
                        case "SHORT":
                        case "UINT16":
                            var valueShort = ReadShort(check.V2);
                            if (check.V5 == null || valueShort != (short)check.V5)
                                invokeValue = valueShort;
                            break;
                        case "INT":
                        case "UINT":
                        case "UINT32":
                            var valueInt = ReadInt(check.V2);
                            if (check.V5 == null || valueInt != (uint)check.V5)
                                invokeValue = valueInt;
                            break;
                        case "LONG":
                        case "ULONG":
                        case "UINT64":
                            var valueLong = ReadLong(check.V2);
                            if (check.V5 == null || valueLong != (ulong)check.V5)
                                invokeValue = valueLong;
                            break;
                    }

                    if (invokeValue != null)
                    {
                        check.V3.Invoke(invokeValue);
                        check.V5 = invokeValue;
                    }

                }
            }
        }

        public IEnumerable<IntPtr> FindInt(uint find, IEnumerable<IntPtr> list = null)
        {
            var result = new List<IntPtr>();
            if ((list?.Count() ?? 0) > 0)
            {
                // buscar en la lista
                return list.Where(p => ReadInt(p) == find).ToArray();
            }
            else
            {
                return FindArray(BitConverter.GetBytes(find));
            }
        }
        public IEnumerable<IntPtr> FindLong(ulong find, IEnumerable<IntPtr> list = null)
        {
            var result = new List<IntPtr>();
            if ((list?.Count() ?? 0) > 0)
            {
                // buscar en la lista
                return list.Where(p => ReadLong(p) == find).ToArray();
            }
            else
            {
                return FindArray(BitConverter.GetBytes(find));
            }
        }
        public IEnumerable<IntPtr> FindArray(byte[] find)
        {
            // buscar en toda la memoria
            var foundeds = new List<long>();

            long pos = 0;
            uint take = 8000;
            long jump = take;

            while (pos < this.Process.VirtualMemorySize64)
            {
                var buffer = ReadBytes(new IntPtr(pos), take);

                int findIndex = 0;
                while (findIndex >= 0)
                {
                    findIndex = Contains(buffer, findIndex, find);

                    if (findIndex >= 0)
                    {
                        // encontrado
                        foundeds.Add(pos + findIndex);
                        findIndex += find.Length;
                    }
                    else
                    {
                        pos += jump;
                    }
                }

            }

            return foundeds.Select(p => new IntPtr(p)).ToArray();
        }

        public Dictionary<DTO.MemFindComplex, List<IntPtr>> FindMany(IEnumerable<DTO.MemFindComplex> tofind)
        {
            var res = tofind.ToDictionary(k => k, v => new List<IntPtr>());

            long pos = 0;
            uint take = 0x1000 * 4;
            long jump = take - (4 * tofind.Max(p => p.MaxSize));

            while (pos < this.Process.VirtualMemorySize64)
            {
                var buffer = ReadInts(new IntPtr(pos), take);

                for (var i = 0; i < (jump / 4); i++) // bucle en el array
                {

                    if (pos + (i * 4) == 0x294D0F40)
                    {
                        int ii = 0;
                        ii++;
                    }

                    foreach (var complex in tofind) // bucle general por complex
                    {
                        bool founded = true;
                        foreach (var find in complex)
                        {
                            if (buffer[i + find.offset] != find.Value)
                            {
                                founded = false;
                                break;
                            }
                        }

                        if (founded)
                            res[complex].Add(new IntPtr(pos + (i * 4)));
                    }
                }

                pos += jump;
            }

            return res;
        }

        private int Contains(byte[] buffer, int offset, byte[] find)
        {
            var type = find.Length;
            var i = offset;
            while (i < buffer.Length)
            {
                var founded = false;
                if (type == 4)
                    founded = buffer[i + 0] == find[0] && buffer[i + 1] == find[1] && buffer[i + 2] == find[2] && buffer[i + 3] == find[3];
                else
                    founded = buffer[i + 0] == find[0] && buffer[i + 1] == find[1] && buffer[i + 2] == find[2] && buffer[i + 3] == find[3] &&
                              buffer[i + 4] == find[4] && buffer[i + 5] == find[5] && buffer[i + 6] == find[6] && buffer[i + 7] == find[7];

                if (founded)
                    return i;

                i += type;
            }

            return -1;
        }

        public uint? Navigate(IntPtr start, IEnumerable<int> offsets)
        {
            var pointer = ReadInt(start);
            foreach (var offset in offsets)
            {
                if (pointer == 0)
                    return null;

                if (pointer > int.MaxValue)
                    return null;

                pointer = ReadInt(new IntPtr(pointer) + offset);
            }
            return pointer;
        }
    }
}
