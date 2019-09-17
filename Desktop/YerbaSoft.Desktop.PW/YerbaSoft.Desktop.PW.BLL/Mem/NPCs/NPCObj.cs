using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Desktop.PW.BLL.Mem.NPCs
{
    public class NPCObj
    {
        public enum Type
        {
            Pet = 9,
            NPC = 7,
            Mob = 6
        }

        public PWClient Client;
        public uint BasePointer;
        public Client.PWI_1_3_6_2265.Structs.NPCObj Data;

        public bool IsNPC => Data.Tipo == (uint)Type.NPC;
        public bool IsPet => Data.Tipo == (uint)Type.Pet;
        public bool IsMob => Data.Tipo == (uint)Type.Mob;

        public NPCObj(PWClient client, uint basePointer)
        {
            this.Client = client;
            this.BasePointer = basePointer;
            this.Data = this.Client.MemMgr.ReadStruct<Client.PWI_1_3_6_2265.Structs.NPCObj>(this.BasePointer);
        }

        public string GetDesc()
        {
            return this.Client.MemMgr.ReadString(this.Data.pName, 200);
        }
    }
}
