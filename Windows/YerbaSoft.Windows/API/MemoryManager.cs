using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YerbaSoft.DTO.Types;

namespace YerbaSoft.Windows.API
{
    public class MemoryManager
    {
        [DllImport("Kernel32.dll")]
        static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, UInt32 nSize, ref UInt32 lpNumberOfBytesRead);
        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, UInt32 size, ref UInt32 lpNumberOfBytesWritten);

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
        public UInt32 Write(IntPtr address, uint value) => Write(address, BitConverter.GetBytes(value));

        public byte[] ReadBytes(IntPtr address, UInt32 size)
        {
            uint readed = default;
            var buffer = new byte[size];
            ReadProcessMemory(this.hProcess, address, buffer, size, ref readed);
            return buffer;
        }
        public byte ReadByte(IntPtr address) => ReadBytes(address, 1)[0];
        public short ReadShort(IntPtr address) => BitConverter.ToInt16(ReadBytes(address, 2), 0);
        public uint ReadInt(IntPtr address) => BitConverter.ToUInt32(ReadBytes(address, 4), 0);
        public ulong ReadLong(IntPtr address) => BitConverter.ToUInt64(ReadBytes(address, 8), 0);

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

                foreach(var check in checks)
                {
                    object invokeValue = null;

                    switch(check.V4.Name.ToUpper())
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
                // buscar en toda la memoria
                var foundeds = new List<long>();

                byte[] tofind = BitConverter.GetBytes(find);
                long pos = 0;
                uint take = 5000;
                long jump = take - tofind.Length - 1;

                while (pos < this.Process.VirtualMemorySize64)
                {
                    var buffer = ReadBytes(new IntPtr(pos), take);

                    int findIndex = 0;
                    while(findIndex >= 0)
                    {
                        findIndex = Contains(buffer, findIndex, tofind);

                        if (findIndex >= 0)
                        {
                            foundeds.Add(pos + findIndex);
                            // encontrado
                            pos = pos + findIndex + tofind.Length;    // sigue buscando
                            findIndex++;
                        }
                        else
                        {
                            pos += jump;
                        }

                    }
                    
                }

                return foundeds.Select(p => new IntPtr(p)).ToArray();
            }
        }

        private int Contains(byte[] buffer, int offset, byte[] find)
        {
            for (var i = offset; i < buffer.Length - find.Length; i++)
            {
                var founded = true;

                for (var j = 1; j < find.Length; j++)
                {
                    if (buffer[i + j] != find[j])
                    {
                        founded = false;
                        break;
                    }
                    else
                    {
                        int g = 0;
                        g++;
                    }
                }

                if (founded)
                    return i;
            }

            return -1;
        }

    }
}
