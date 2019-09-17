using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YerbaSoft.Desktop.PW.Client.PWI_1_3_6_2265.Structs;

namespace YerbaSoft.Desktop.PW.BLL.Mem
{
    public class PWMem : IDisposable
    {
        internal PWClient Client { get; set; }
        private Guid MemChkBase0 { get; set; }
        private Guid MemChkFreeze { get; set; }
        private bool ChkFreezeActive { get; set; } = true;

        public Basic.Base1 Base1 { get; set; }
        public Links Link { get; set; }

        public event EventHandler<bool> OnConnect;

        public PWMem(PWClient client)
        {
            this.Client = client;
            this.Link = new Links(this);

            this.MemChkBase0 = this.Client.MemMgr.OnMemoryChange<uint>(new IntPtr(PW.Client.PWI_1_3_6_2265.ElementClient.Base0), LoadBase0);

            this.MemChkFreeze = this.Client.MemMgr.OnMemoryChange<uint>(new IntPtr(PW.Client.PWI_1_3_6_2265.ElementClient.Frezee), ChkFreeze);
        }

        private void ChkFreeze(object e)
        {
            if (ChkFreezeActive)
                if ((this.Client.Config.AntiFreeze ?? true) && (uint)e == 0)
                    this.Client.MemMgr.Write(new IntPtr(PW.Client.PWI_1_3_6_2265.ElementClient.Frezee), (uint)1);
        }

        private void LoadBase0(object value)
        {
            var pointer = (uint)value;

            // ¿cierre del juego?
            if (pointer == 0 && this.Base1 != null)
            {
                this.Base1?.Dispose();
                this.Base1 = null;

                OnConnect?.Invoke(this, false);
            }

            if (pointer > 0 && this.Base1?.BasePointer != pointer)
            {
                this.Base1?.Dispose();
                this.Base1 = new Basic.Base1(this.Client, pointer);
                OnConnect?.Invoke(this, true);
            }
        }
        
        public void Dispose()
        {
            this.Client.MemMgr.RemoveMemoryChange(this.MemChkBase0);
            this.Client.MemMgr.RemoveMemoryChange(this.MemChkFreeze);
        }

        public void SetFreeze(bool freeze, bool autoCheckActive)
        {
            this.ChkFreezeActive = autoCheckActive;
            this.Client.MemMgr.Write(new IntPtr(PW.Client.PWI_1_3_6_2265.ElementClient.Frezee), freeze ? (uint)0 : (uint)1);
        }
    }
}
