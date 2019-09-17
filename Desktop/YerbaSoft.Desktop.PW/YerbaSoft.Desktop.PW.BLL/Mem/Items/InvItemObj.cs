using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.Desktop.PW.Client.PWI_1_3_6_2265.Structs;

namespace YerbaSoft.Desktop.PW.BLL.Mem.Items
{
    public class InvItemObj
    {
        public PWClient Client;
        public uint BasePointer;
        public InventarioItem Data;

        public InvItemObj(PWClient client, uint basePointer)
        {
            this.Client = client;
            this.BasePointer = basePointer;
            this.Data = this.Client.MemMgr.ReadStruct<InventarioItem>(this.BasePointer);
        }

        public string GetDesc()
        {
            return this.Client.MemMgr.ReadString(this.Data.pTextoDescriptivo, 200);
        }
    }
}
