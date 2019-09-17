using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.Desktop.PW.Client.PWI_1_3_6_2265.Structs;

namespace YerbaSoft.Desktop.PW.BLL.Mem.Pointers
{
    public class PointerObj : IDisposable
    {
        private PWClient Client;
        public uint BasePointer { get; internal set; }

        public CoordPointObj Data { get; set; }

        public bool IsValid => Data.uk0 == uint.MaxValue && Data.pName != 10300400;
        
        public PointerObj(PWClient client, uint basePointer)
        {
            this.Client = client;
            this.BasePointer = basePointer;

            ReLoadData();
        }

        public void ReLoadData() => this.Data = this.Client.MemMgr.ReadStruct<CoordPointObj>(this.BasePointer);

        public void SetCoords(float x, float z)
        {
            if (IsValid)
            {
                this.Client.MemMgr.Write(new IntPtr(this.BasePointer + 0x8), x);
                this.Client.MemMgr.Write(new IntPtr(this.BasePointer + 0x10), z);

                ReLoadData();
            }
        }

        public void Dispose()
        {
        }
    }
}
