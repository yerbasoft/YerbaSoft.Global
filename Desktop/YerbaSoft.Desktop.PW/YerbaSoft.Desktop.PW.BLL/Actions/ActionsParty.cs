using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YerbaSoft.Desktop.PW.BLL.Actions
{
    public class ActionsParty
    {
        public PWActions Actions { get; set; }
        public PWClient Client => Actions.Client;

        public ActionsParty(PWActions actions)
        {
            this.Actions = actions;
        }

        internal void SetPartyIndividual(bool individualPick)
        {
            var win = this.Client.Mem.Link.GetGUIObj(Mem.Basic.GUIObj.GUIs.WinParty);
            win.Show(true);
            Thread.Sleep(300);
            if (individualPick)
            {
                this.Client.Manager.MouseDown(Convert.ToInt32(win.Data.Left + 360), Convert.ToInt32(win.Data.Top + 345));
                this.Client.Manager.MouseUp(Convert.ToInt32(win.Data.Left + 360), Convert.ToInt32(win.Data.Top + 345));
            }
            else // random pick
            {
                this.Client.Manager.MouseDown(Convert.ToInt32(win.Data.Left + 296), Convert.ToInt32(win.Data.Top + 345));
                this.Client.Manager.MouseUp(Convert.ToInt32(win.Data.Left + 296), Convert.ToInt32(win.Data.Top + 345));
            }
            Thread.Sleep(300);
            win.Show(false);
            Thread.Sleep(50);
        }

        public void LeaveParty()
        {
            var partymembers = this.Client.MemMgr.ReadInt(PW.Client.PWI_1_3_6_2265.ElementClient.PartyMembers);
            if (partymembers > 0)
            {
                var win = this.Client.Mem.Link.GetGUIObj(Mem.Basic.GUIObj.GUIs.WinParty);
                win.Show(true);
                Thread.Sleep(300);

                // re-check si sigo en party
                partymembers = this.Client.MemMgr.ReadInt(PW.Client.PWI_1_3_6_2265.ElementClient.PartyMembers);
                if (partymembers == 0)
                {
                    win.Show(false);
                    return;
                }

                this.Client.Manager.MouseDown(Convert.ToInt32(win.Data.Left + 370), Convert.ToInt32(win.Data.Top + 305));
                this.Client.Manager.MouseUp(Convert.ToInt32(win.Data.Left + 370), Convert.ToInt32(win.Data.Top + 305));
                Thread.Sleep(300);

                // re-check si sigo en party
                partymembers = this.Client.MemMgr.ReadInt(PW.Client.PWI_1_3_6_2265.ElementClient.PartyMembers);
                if (partymembers == 0)
                {
                    win.Show(false);
                    return;
                }

                // se abre la ventana de aceptacion y se pone en focus
                win = this.Client.Mem.Link.GetGUIObj(Mem.Basic.GUIObj.GUIs.LastCmdSend);
                this.Client.Manager.MouseDown(Convert.ToInt32(win.Data.Left + 100), Convert.ToInt32(win.Data.Top + 95));
                this.Client.Manager.MouseUp(Convert.ToInt32(win.Data.Left + 100), Convert.ToInt32(win.Data.Top + 95));
                Thread.Sleep(300);
            }
        }

        public void InviteToParty(string name)
        {
            var win = this.Client.Mem.Link.GetGUIObj(Mem.Basic.GUIObj.GUIs.WinParty);
            win.Show(true);
            Thread.Sleep(100);

            this.Client.Manager.MouseDown(Convert.ToInt32(win.Data.Left + 220), Convert.ToInt32(win.Data.Top + 297));
            this.Client.Manager.MouseUp(Convert.ToInt32(win.Data.Left + 220), Convert.ToInt32(win.Data.Top + 297));
            Thread.Sleep(300);
            for (var i = 0; i < 20; i++) this.Client.Manager.KeyUp(Keys.Back);

            lock (BLL.ClientManager.TakeControlKeyboard)
            {
                // recorro nombre y lo escribo
                foreach (var l in name)
                {
                    bool shift = false;
                    string letter;
                    if (int.TryParse(l.ToString(), out int aux))
                    {
                        letter = $"D{l}";
                    }
                    else
                    {
                        letter = l.ToString().ToUpper();
                        shift = l == l.ToString().ToUpper()[0];
                    }

                    if (shift)
                    {
                        this.Client.Manager.KeyDownSimulator(Keys.LShiftKey);
                        Thread.Sleep(100);
                    }

                    var key = (Keys)Enum.Parse(typeof(Keys), letter);
                    this.Client.Manager.KeyUp(key);

                    if (shift)
                    {
                        this.Client.Manager.KeyUpSimulator(Keys.LShiftKey);
                        Thread.Sleep(100);
                    }
                }
            }
            Thread.Sleep(100);
            this.Client.Manager.MouseDown(Convert.ToInt32(win.Data.Left + 60), Convert.ToInt32(win.Data.Top + 297));
            this.Client.Manager.MouseUp(Convert.ToInt32(win.Data.Left + 60), Convert.ToInt32(win.Data.Top + 297));
            Thread.Sleep(500);
            win.Show(true);
        }

    }
}
