using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.Desktop.PW.Client.PWI_1_3_6_2265.Structs;

namespace YerbaSoft.Desktop.PW.BLL.Mem.NPCs
{
    public class NPCManager
    {
        PWClient Client;

        public NPCManager(PWClient client)
        {
            this.Client = client;
        }

        public uint[] GetPointerMap()
        {
            var _Base0 = this.Client.MemMgr.ReadStruct<Base0>(PW.Client.PWI_1_3_6_2265.ElementClient.Base0);
            var _Base1 = this.Client.MemMgr.ReadStruct<Base1>(_Base0.pBase1);
            var _DataContainer = this.Client.MemMgr.ReadStruct<DataContainer>(_Base1.pDataContainer);

            return new uint[] { _Base0.pBase1, _Base1.pDataContainer, _DataContainer.pNPCHeader };
        }

        public NPCObj[] GetAll()
        {
            var pointers = GetPointerMap();
            var pointer = pointers.Last();
            var _NPCHeader = this.Client.MemMgr.ReadStruct<NPCHeader>(pointer);
            var punteros = this.Client.MemMgr.ReadInts(_NPCHeader.HeaderList.pNPCArray, _NPCHeader.HeaderList.Cantidad * 4);
                        
            return punteros.Select(p => p == 0 ? null : new NPCObj(this.Client, p)).ToArray();
        }

        public NPCObj GetById(uint targetId)
        {
            return GetAll().SingleOrDefault(p => p.Data.Id == targetId);
        }
    }
}
