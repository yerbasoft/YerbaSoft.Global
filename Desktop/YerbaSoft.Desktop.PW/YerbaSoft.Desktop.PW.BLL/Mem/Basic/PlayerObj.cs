using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YerbaSoft.Desktop.PW.BLL.Mem.Basic
{
    public class PlayerObj : IDisposable
    {
        private PWClient Client;
        public uint BasePointer;

        private Thread Listener { get; set; }

        // Events
        public event EventHandler<uint> OnDataCurrHPChange;

        public Client.PWI_1_3_6_2265.Structs.PlayerObj PrevData;
        public Client.PWI_1_3_6_2265.Structs.PlayerObj Data;

        public PlayerObj(PWClient client, uint basePointer)
        {
            this.Client = client;
            this.BasePointer = basePointer;

            (this.Listener = new Thread(_Listener) { IsBackground = true, Priority = ThreadPriority.Lowest }).Start();
        }

        private void _Listener()
        {
            while (true)
            {
                Thread.Sleep(200);
                this.PrevData = this.Data;
                lock (this)
                    this.Data = this.Client.MemMgr.ReadStruct<Client.PWI_1_3_6_2265.Structs.PlayerObj>(this.BasePointer);

                if (this.PrevData.CurrHP != this.Data.CurrHP)
                    this.OnDataCurrHPChange?.Invoke(this, this.Data.CurrHP);
            }
        }

        public void Dispose()
        {
            BasePointer = 0;

            this.Listener?.Abort();
            this.Listener = null;
        }

        public void SetTarget(uint targetid)
        {
            this.Client.MemMgr.Write(this.BasePointer + (uint)0xAF0, targetid);
            Thread.Sleep(100);
        }

        public void SetBloquearMovimiento(bool bloquear)
        {
            this.Client.MemMgr.Write(this.BasePointer + (uint)0xB0C, bloquear ? (uint)1 : (uint)0);
            Thread.Sleep(100);
        }

        public void SetCamDist(float dist)
        {
            this.Client.MemMgr.Write(this.BasePointer + (uint)0x844, dist);
            this.Client.MemMgr.Write(this.BasePointer + (uint)0x848, dist);
        }

        internal void SetCamAngleXZ(float angle)
        {
            this.Client.MemMgr.Write(this.BasePointer + (uint)0x83C, angle);
            this.Client.MemMgr.Write(this.BasePointer + (uint)0x840, angle);
        }

        internal void SetCamAngleY(float angle)
        {
            this.Client.MemMgr.Write(this.BasePointer + (uint)0x834, angle);
            this.Client.MemMgr.Write(this.BasePointer + (uint)0x838, angle);
        }
    }
}
