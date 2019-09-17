using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.Desktop.PW.Client.PWI_1_3_6_2265.Structs;

namespace YerbaSoft.Desktop.PW.BLL.Mem.Items
{
    public class Inventory
    {
        public enum InventoryType
        {
            InventorySlots,
            InventoryQuestItem,
            InventorySet
        }

        PWClient Client;
        InventoryType Type;

        public Inventory(PWClient client, InventoryType type)
        {
            this.Client = client;
            this.Type = type;
        }

        public uint[] GetPointerMap()
        {
            var result = new List<uint>();

            var base0 = this.Client.MemMgr.ReadStruct<Base0>(this.Client.Mem.Base1.BasePointer);
            var _InventarioContainer = this.Client.MemMgr.ReadStruct<InventarioContainer>(base0.pInventarioContainer);
            uint pointer = 0;
            switch(this.Type)
            {
                case InventoryType.InventoryQuestItem: pointer = _InventarioContainer.pInventarioQuestSlots; break;
                case InventoryType.InventorySet: pointer = _InventarioContainer.pInventarioSet; break;
                case InventoryType.InventorySlots: pointer = _InventarioContainer.pInventarioSlots; break;
            }

            return new uint[] { this.Client.Mem.Base1.BasePointer, base0.pInventarioContainer, pointer };
        }

        public InvItemObj[] GetItems()
        {
            var pointers = GetPointerMap();
            var pointer = pointers.Last();

            var _Inventario = this.Client.MemMgr.ReadStruct<Inventario>(pointer);
            var cant = _Inventario.Cantidad;
            var punteros = this.Client.MemMgr.ReadInts(_Inventario.pInventarioItemArray, cant * 4);

            return punteros.Select(p => p == 0 ? null : new InvItemObj(this.Client, p)).ToArray();
        }
        public string[] GetItemTexts()
        {
            var texts = new List<string>();
            foreach (var p in GetItems().Select(p => p?.Data.pTextoDescriptivo))
            {
                if (p.HasValue)
                    texts.Add(this.Client.MemMgr.ReadString(p.Value, 300));
                /*else
                    texts.Add(null);*/
            }
            return texts.ToArray();
        }

        public bool ExistsItem(uint dbCode)
        {
            var pointers = GetPointerMap();
            var pointer = pointers.Last();

            var _Inventario = this.Client.MemMgr.ReadStruct<Inventario>(pointer);
            var cant = _Inventario.Cantidad;
            var punteros = this.Client.MemMgr.ReadInts(_Inventario.pInventarioItemArray, cant * 4);

            return punteros.Where(p => p != 0).Select(p => new InvItemObj(this.Client, p)).Any(p => p.Data.dbCode == dbCode);
        }

    }
}
