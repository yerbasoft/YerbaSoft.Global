using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YerbaSoft.Windows.API;

namespace YerbaSoft.Desktop.PW.BLL.Structs
{
    public class PJInfo : IDisposable
    {
        public const int MonitorBase = 0x000;

        [StructLayout(LayoutKind.Explicit, /*Size = 2000, */ Pack = 1, CharSet = CharSet.Unicode)]
        public struct Structure
        {
            [FieldOffset(0x4A4)]
            public uint MaxHP;
            [FieldOffset(0x4A4-56)]
            public uint CurrentHP;
            [FieldOffset(0x4A4+4)]
            public uint MaxMP;
            [FieldOffset(0x4A4-52)]
            public uint CurrentMP;

            // Stats
            [FieldOffset(0x4A4 + 36)]
            public uint PAtkMin;
            [FieldOffset(0x4A4 + 40)]
            public uint PAtkMax;
            [FieldOffset(0x4A4 + 44)]   // a confirmar
            public uint MAtkMin;
            [FieldOffset(0x4A4 + 48)]   // a confirmar
            public uint MAtkMax;
            [FieldOffset(0x4A4 + 32)]
            public uint Accuracy;
            [FieldOffset(0x4A4 + 124)]
            public uint Dodge;
            [FieldOffset(0x4A4 + 120)]
            public uint PDef;
            [FieldOffset(0x4A4 + 100)]
            public uint MDefMetal;
            [FieldOffset(0x4A4 + 104)]
            public uint MDefWood;
            [FieldOffset(0x4A4 + 108)]
            public uint MDefWater;
            [FieldOffset(0x4A4 + 112)]
            public uint MDefFire;
            [FieldOffset(0x4A4 + 116)]
            public uint MDefEarth;

            // Puntos
            [FieldOffset(0x4A4 - 40)]
            public uint PuntosDisponibles;
            [FieldOffset(0x4A4 - 8)]
            public uint PuntosSTR;
            [FieldOffset(0x4A4 - 4)]
            public uint PuntosAGI;
            [FieldOffset(0x4A4 - 16)]
            public uint PuntosVIT;
            [FieldOffset(0x4A4 - 12)]
            public uint PuntosMAG;
                       
            [FieldOffset(0x4A4+132)]
            public uint InventoryGold;

            [FieldOffset(0x4A4+1864)]
            public uint FlagSalto;

            [FieldOffset(0xAF0)]
            public uint TargetId;
            [FieldOffset(0x6C4)]
            public uint CastId;
            
            [FieldOffset(PJInfo.MonitorBase + 00)] public uint Var01;
            [FieldOffset(PJInfo.MonitorBase + 04)] public uint Var02;
            [FieldOffset(PJInfo.MonitorBase + 08)] public uint Var03;
            [FieldOffset(PJInfo.MonitorBase + 12)] public uint Var04;
            [FieldOffset(PJInfo.MonitorBase + 16)] public uint Var05;
            [FieldOffset(PJInfo.MonitorBase + 20)] public uint Var06;
            [FieldOffset(PJInfo.MonitorBase + 24)] public uint Var07;
            [FieldOffset(PJInfo.MonitorBase + 28)] public uint Var08;
            [FieldOffset(PJInfo.MonitorBase + 32)] public uint Var09;
            [FieldOffset(PJInfo.MonitorBase + 36)] public uint Var10;
            [FieldOffset(PJInfo.MonitorBase + 40)] public uint Var11;
            [FieldOffset(PJInfo.MonitorBase + 44)] public uint Var12;
            [FieldOffset(PJInfo.MonitorBase + 48)] public uint Var13;
            [FieldOffset(PJInfo.MonitorBase + 52)] public uint Var14;
            [FieldOffset(PJInfo.MonitorBase + 56)] public uint Var15;
            [FieldOffset(PJInfo.MonitorBase + 60)] public uint Var16;
            [FieldOffset(PJInfo.MonitorBase + 64)] public uint Var17;
            [FieldOffset(PJInfo.MonitorBase + 68)] public uint Var18;
            [FieldOffset(PJInfo.MonitorBase + 72)] public uint Var19;
            [FieldOffset(PJInfo.MonitorBase + 76)] public uint Var20;

            [FieldOffset(PJInfo.MonitorBase + 80)] public uint Var21;
            [FieldOffset(PJInfo.MonitorBase + 84)] public uint Var22;
            [FieldOffset(PJInfo.MonitorBase + 88)] public uint Var23;
            [FieldOffset(PJInfo.MonitorBase + 92)] public uint Var24;
            [FieldOffset(PJInfo.MonitorBase + 96)] public uint Var25;
            [FieldOffset(PJInfo.MonitorBase + 100)] public uint Var26;
            [FieldOffset(PJInfo.MonitorBase + 104)] public uint Var27;
            [FieldOffset(PJInfo.MonitorBase + 108)] public uint Var28;
            [FieldOffset(PJInfo.MonitorBase + 112)] public uint Var29;
            [FieldOffset(PJInfo.MonitorBase + 116)] public uint Var30;
            [FieldOffset(PJInfo.MonitorBase + 120)] public uint Var31;
            [FieldOffset(PJInfo.MonitorBase + 124)] public uint Var32;
            [FieldOffset(PJInfo.MonitorBase + 128)] public uint Var33;
            [FieldOffset(PJInfo.MonitorBase + 132)] public uint Var34;
            [FieldOffset(PJInfo.MonitorBase + 136)] public uint Var35;
            [FieldOffset(PJInfo.MonitorBase + 140)] public uint Var36;
            [FieldOffset(PJInfo.MonitorBase + 144)] public uint Var37;
            [FieldOffset(PJInfo.MonitorBase + 148)] public uint Var38;
            [FieldOffset(PJInfo.MonitorBase + 152)] public uint Var39;
            [FieldOffset(PJInfo.MonitorBase + 156)] public uint Var40;
        }

        public event EventHandler<Structure> OnInfoChanged;
        public event EventHandler<Structure> OnTargetIdChanged;

        // Tools
        private ProcessManager Manager;
        private uint BasePointer;

        // Listeners de Memoria
        private Thread Listener;
        private Dictionary<string, Guid> Listeners = new Dictionary<string, Guid>();

        // Propiedades
        public Structure Info { get; set; }

        public PJInfo(ProcessManager manager, uint pointer, Configuration.Cuenta config)
        {
            this.Manager = manager;
            this.BasePointer = pointer;

            this.Listener = new Thread(OnListener);
            this.Listener.Start();
        }

        public void Dispose()
        {
            if (Listener != null && Listener.ThreadState != ThreadState.Aborted)
                Listener.Abort();

            foreach (var l in Listeners.Values)
                this.Manager.Memory.RemoveMemoryChange(l);
            Listeners.Clear();

            // Dispose en Cascada
        }

        private void OnListener()
        {
            while (true)
            {
                Thread.Sleep(500);
                var bytes = this.Manager.Memory.ReadBytes(new IntPtr(this.BasePointer), Convert.ToUInt32(Marshal.SizeOf(typeof(Structure))));

                Structure loaded = StructTools.RawDeserialize<Structure>(bytes, 0);

                // Change Events
                if (loaded.TargetId != this.Info.TargetId)
                    OnTargetIdChanged?.Invoke(this, this.Info);

                lock (this)
                    this.Info = loaded;
                OnInfoChanged?.Invoke(this, this.Info);
            }
        }
    }
}
