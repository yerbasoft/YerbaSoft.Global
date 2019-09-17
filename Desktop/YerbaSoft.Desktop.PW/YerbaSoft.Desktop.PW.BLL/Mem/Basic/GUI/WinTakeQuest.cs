using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YerbaSoft.Desktop.PW.Client.PWI_1_3_6_2265.Structs;

namespace YerbaSoft.Desktop.PW.BLL.Mem.Basic.GUI
{
    public class WinTakeQuest
    {
        private PWClient Client;
        private GUIObj GUIObj;

        public WinTakeQuest(PWClient client)
        {
            this.Client = client;
            this.GUIObj = this.Client.Mem?.Link?.GetGUIObj(BLL.Mem.Basic.GUIObj.GUIs.WinTakeQuest);
        }

        public string[] GetQuestList()
        {
            var GUIWinTakeQuest_BaseQuest = this.Client.MemMgr.ReadStruct<GUIWinTakeQuest_BaseQuest>(this.GUIObj.Data.pGUIWinTakeQuest_BaseQuest);
            var GUIWinTakeQuest_QuestListParent = this.Client.MemMgr.ReadStruct<GUIWinTakeQuest_QuestListParent>(GUIWinTakeQuest_BaseQuest.pGUIWinTakeQuest_QuestListParent);
            var pointer = GUIWinTakeQuest_QuestListParent.pArrayGUIWinTakeQuest_QuestScreenItem;

            var result = new List<string>();
            uint offset = 0;
            string value;
            do
            {
                var pText = this.Client.MemMgr.ReadInt(pointer + offset);
                value = this.Client.MemMgr.ReadString(pText, 200);

                if (value.Contains("See you next time"))
                    value = null;

                if (!string.IsNullOrEmpty(value))
                    result.Add(value);

                offset += 0x98;
            } while (!string.IsNullOrEmpty(value));

            return result.ToArray();
        }

        public void ClickOption(int order, int cantQuest = 0)
        {
            if (cantQuest == 0)
                cantQuest = GetQuestList().Count();

            var y = 303;
            if (cantQuest == 5) y = 297;
            if (cantQuest == 6) y = 276;

            y +=  + (order * 17); // base 0
            var x = 80;

            // refresh
            this.GUIObj = this.Client.Mem?.Link?.GetGUIObj(BLL.Mem.Basic.GUIObj.GUIs.WinTakeQuest);

            this.Client.Manager.MouseDown(Convert.ToInt32(GUIObj.Data.Left + x), Convert.ToInt32(GUIObj.Data.Top + y));
            this.Client.Manager.MouseUp(Convert.ToInt32(GUIObj.Data.Left + x), Convert.ToInt32(GUIObj.Data.Top + y));
            Thread.Sleep(100);
        }
    }
}
