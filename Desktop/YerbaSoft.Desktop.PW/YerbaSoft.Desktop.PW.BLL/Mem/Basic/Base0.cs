using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Desktop.PW.BLL.Mem.Basic
{
    public class Base1 : IDisposable
    {
        internal PWClient Client { get; set; }
        public uint BasePointer { get; set; }

        private Guid MemChkPlayerObj { get; }
        private Guid MemChkGUIBase { get; }

        public PlayerObj PJInfo { get; set; }
        //public GUIBase GUI { get; set; }

        public event EventHandler<bool> OnPlayerConnect;

        public Base1(PWClient client, uint basePointer)
        {
            this.Client = client;
            this.BasePointer = basePointer;

            //var base0 = this.Client.MemMgr.ReadStruct<PW.Client.PWI_1_3_6_2265.Structs.Base0>(this.BasePointer);

            //this.MemChkGUIBase = this.Client.MemMgr.OnMemoryChange<uint>(new IntPtr(this.BasePointer + 0x04), LoadGUIBase);
            this.MemChkPlayerObj = this.Client.MemMgr.OnMemoryChange<uint>(new IntPtr(this.BasePointer + 0x20), LoadPlayerObj);
        }

        /*
        private void LoadGUIBase(object obj)
        {
            var pointer = (uint)obj;

            if (pointer == 0 && this.GUI != null)
            {
                this.GUI?.Dispose();
                this.GUI = null;
            }

            if (pointer > 0 && this.GUI?.BasePointer != pointer)
            {
                this.GUI?.Dispose();
                this.GUI = new GUIBase(this.Client, pointer);
            }
        }
        */

        private void LoadPlayerObj(object obj)
        {
            var pointer = (uint)obj;

            if (pointer == 0 && this.PJInfo != null)
            {
                this.PJInfo?.Dispose();
                this.PJInfo = null;

                OnPlayerConnect?.Invoke(this, false);
            }

            if (pointer > 0 && this.PJInfo?.BasePointer != pointer)
            {
                this.PJInfo?.Dispose();
                this.PJInfo = new PlayerObj(this.Client, pointer);
                OnPlayerConnect?.Invoke(this, true);
            }
        }
        
        public void Dispose()
        {
            this.BasePointer = 0;

            this.Client.MemMgr.RemoveMemoryChange(this.MemChkGUIBase);
            this.Client.MemMgr.RemoveMemoryChange(this.MemChkPlayerObj);

            PJInfo?.Dispose();
            PJInfo = null;
        }
    }
}
