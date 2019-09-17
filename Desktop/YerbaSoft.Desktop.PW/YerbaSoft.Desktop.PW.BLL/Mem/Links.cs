using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.Desktop.PW.Client.PWI_1_3_6_2265;
using YerbaSoft.Desktop.PW.Client.PWI_1_3_6_2265.Structs;

namespace YerbaSoft.Desktop.PW.BLL.Mem
{
    public class Links
    {
        private PWMem Mem;

        public event EventHandler<bool> OnConnect;
        public event EventHandler<bool> OnPlayerConnect;
        public event EventHandler<uint> OnCurrentHPChange;

        public Basic.PlayerObj PJInfo => this.Mem.Base1?.PJInfo;

        private Items.Inventory _InventoryQuestItem;
        public Items.Inventory InventoryQuestItem => _InventoryQuestItem = _InventoryQuestItem ?? new Items.Inventory(this.Mem.Client, Items.Inventory.InventoryType.InventoryQuestItem);
        private Items.Inventory _InventorySet;
        public Items.Inventory InventorySet => _InventorySet = _InventorySet ?? new Items.Inventory(this.Mem.Client, Items.Inventory.InventoryType.InventorySet);
        private Items.Inventory _InventorySlots;
        public Items.Inventory InventorySlots => _InventorySlots = _InventorySlots ?? new Items.Inventory(this.Mem.Client, Items.Inventory.InventoryType.InventorySlots);

        private NPCs.NPCManager _NPC;
        public NPCs.NPCManager NPC => _NPC = _NPC ?? new NPCs.NPCManager(this.Mem.Client);

        private Basic.GUI.WinTakeQuest _WinTakeQuest;
        public Basic.GUI.WinTakeQuest WinTakeQuest => _WinTakeQuest = _WinTakeQuest ?? new Basic.GUI.WinTakeQuest(this.Mem.Client);

        public Links(PWMem mem)
        {
            this.Mem = mem;

            this.Mem.OnConnect += Mem_OnConnect;
        }

        public Pointers.PointerObj GetPointerObj()
        {
            var base0 = Mem.Client.MemMgr.ReadStruct<CoordPointsBase0>(ElementClient.Points);
            var base1 = Mem.Client.MemMgr.ReadStruct<CoordPointsBase1>(base0.pCoordPointsBase1);

            return new Pointers.PointerObj(Mem.Client, base1.pCoordPunto);
        }

        public Basic.GUIObj GetGUIObj(Basic.GUIObj.GUIs gui)
        {
            var base1 = Mem.Client.MemMgr.ReadStruct<PW.Client.PWI_1_3_6_2265.Structs.Base1>(Mem.Base1.BasePointer);
            var guibase0 = Mem.Client.MemMgr.ReadStruct<PW.Client.PWI_1_3_6_2265.Structs.GUIBase0>(base1.pGUIBase0);
            //var guibase1 = Mem.Client.MemMgr.ReadStruct<PW.Client.PWI_1_3_6_2265.Structs.GUIBase1>(guibase0.pGUIBase1);

            var pGUIObj = Mem.Client.MemMgr.ReadInt(guibase0.pGUIBase1 + Convert.ToUInt32((int)gui));
            return new Basic.GUIObj(this.Mem.Client, pGUIObj);
        }
        public uint[] GetGUIPointers(Basic.GUIObj.GUIs? gui)
        {
            var base1 = Mem.Client.MemMgr.ReadStruct<PW.Client.PWI_1_3_6_2265.Structs.Base1>(Mem.Base1.BasePointer);
            var guibase0 = Mem.Client.MemMgr.ReadStruct<PW.Client.PWI_1_3_6_2265.Structs.GUIBase0>(base1.pGUIBase0);
            var guibase1 = Mem.Client.MemMgr.ReadStruct<PW.Client.PWI_1_3_6_2265.Structs.GUIBase1>(guibase0.pGUIBase1);

            var res = new List<uint>() { Mem.Base1.BasePointer, base1.pGUIBase0, guibase0.pGUIBase1 };

            if (gui.HasValue)
            {
                var pGUIObj = Mem.Client.MemMgr.ReadInt(guibase0.pGUIBase1 + Convert.ToUInt32((int)gui));
                res.Add(pGUIObj);
            }

            return res.ToArray();
        }

        private void Mem_OnConnect(object sender, bool connected)
        {
            this.OnConnect?.Invoke(sender, connected);

            if (this.Mem.Base1 != null)
            {
                this.Mem.Base1.OnPlayerConnect += Base1_OnPlayerConnect;
            }
        }

        private void Base1_OnPlayerConnect(object sender, bool e)
        {
            this.OnPlayerConnect?.Invoke(sender, e);

            if (this.Mem.Base1?.PJInfo != null)
            {
                this.Mem.Base1.PJInfo.OnDataCurrHPChange += PJInfo_OnDataCurrHPChange;
            }
        }

        private void PJInfo_OnDataCurrHPChange(object sender, uint e)
        {
            this.OnCurrentHPChange?.Invoke(sender, e);
        }
    }
}
