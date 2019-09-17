using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YerbaSoft.Desktop.PW.BLL.Actions
{
    public class ActionsGlobal
    {
        public PWActions Actions { get; set; }
        public PWClient Client => Actions.Client;

        public ActionsGlobal(PWActions actions)
        {
            this.Actions = actions;
        }

        public void Test()
        {
            /*
            var npcs = this.Client.Mem.Link.NPC.GetAll().Where(p => p.IsNPC && p.Data.Id == 2148556121);
            foreach (var npc in npcs)
            {
                DoSetTargetNPCWithClick(npc.Data, true);
                Thread.Sleep(3000);
            }

            */

            //DoFly(true, 250);
            //LeaveParty();
            //SetPartyIndividual(false);
            //InviteToParty("Sprayette");
            //DoAcceptMessage();
            /*
            var npcs = this.Client.Mem.Link.NPC.GetAll().Where(p => p.IsMob);
            var marcados = npcs.Where(p => p.Data.CurrHP > 0).Select(p => p.BasePointer).ToArray();
            var sincargar = npcs.Where(p => p.Data.CurrHP == 0).Select(p => p.BasePointer).ToArray();
            var i = 0;
            i++;
            */
            //this.Client.Auto.SetVilla(true);

            /*
            var _Base0 = this.Client.MemMgr.ReadStruct<Base0>(PW.Client.PWI_1_3_6_2265.ElementClient.Base0);
            var _Base1 = this.Client.MemMgr.ReadStruct<Base1>(_Base0.pBase1);
            var _DataContainer = this.Client.MemMgr.ReadStruct<DataContainer>(_Base1.pDataContainer);
            var _NPCHeader = this.Client.MemMgr.ReadStruct<NPCHeader>(_DataContainer.pNPCHeader);

            
            var punteros = this.Client.MemMgr.ReadInts(_NPCHeader.HeaderList.pNPCArray, _NPCHeader.HeaderList.Cantidad * 4);

            var npcs = new List<NPCObj>();
            foreach (var p in punteros)
                npcs.Add(this.Client.MemMgr.ReadStruct<NPCObj>(p));

            var names = new List<string>();
            foreach (var npc in npcs)
                if (npc.pName != 0)
                    names.Add(this.Client.MemMgr.ReadString(npc.pName, 150));

            int i = 0;
            i++;
            */
            // ver el inventario


            /*
             * apuntar y abrir quest y elegir una
            DoZoom(4);
            DoMirarEjeZ();

            // seleccionar npc y abrir ventana de quest
            var screen = this.Client.Manager.GetWindowRect();
            this.Client.Manager.MouseDblClick(screen.Width / 2, (screen.Height / 2) + 100);
            Thread.Sleep(1000);
            this.Client.Manager.MouseDblClick(screen.Width / 2, (screen.Height / 2) + 100);
            Thread.Sleep(2000);

            var win = new Mem.Basic.GUI.WinTakeQuest(this.Client);
            var lista = win.GetQuestList();
            win.ClickOption(2);
            */
        }

        public void DoLogin(bool includeFirstEnter = false)
        {
            if (includeFirstEnter)
            {
                this.Client.Manager.KeyPress(Keys.Enter);
                Thread.Sleep(1000);
            }

            // recorro el login
            foreach (var l in this.Client.Config.Login)
            {
                string letter;
                if (int.TryParse(l.ToString(), out int aux))
                    letter = $"D{l}";
                else
                    letter = l.ToString().ToUpper();
                var key = (Keys)Enum.Parse(typeof(Keys), letter);

                this.Client.Manager.KeyUp(key);
            }
            Thread.Sleep(1000);
            this.Client.Manager.KeyDown(Keys.Tab);
            // recorro el pass

            lock (BLL.ClientManager.TakeControlKeyboard)
            {
                // recorro nombre y lo escribo
                foreach (var l in this.Client.Config.Pass)
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

                Thread.Sleep(1000);
                this.Client.Manager.KeyPress(Keys.Enter);
                Thread.Sleep(3500);
                this.Client.Manager.KeyPress(Keys.Enter);
            }

            new Thread(() =>
            {
                Thread.Sleep(8000);

                var w = this.Client?.Mem?.Link?.GetGUIObj(Mem.Basic.GUIObj.GUIs.FsShortCuts);
                if (w != null && w.Data.Open == 1)
                {
                    this.Client.Manager.MouseDown(w.Data.Left + 10, w.Data.Top + 20);
                    this.Client.Manager.MouseUp(w.Data.Left + 10, w.Data.Top + 20);
                    Thread.Sleep(500);
                    this.Client.Manager.MouseDown(w.Data.Left + 10, w.Data.Top + 20);
                    this.Client.Manager.MouseUp(w.Data.Left + 10, w.Data.Top + 20);
                }

            }).Start();
        }

        public void ShowWin(bool show, Mem.Basic.GUIObj.GUIs win)
        {
            var wPJ = this.Client?.Mem?.Link?.GetGUIObj(win);
            wPJ?.Show(show);
        }

        public void DoAcceptMessage()
        {
            var wPJ = this.Client.Mem.Link.GetGUIObj(Mem.Basic.GUIObj.GUIs.WinPJFace);
            wPJ.Show(false);

            var w = this.Client.Mem.Link.GetGUIObj(Mem.Basic.GUIObj.GUIs.BtnNotification);
            var prevX = w.Data.Left;
            var prevY = w.Data.Top;
            w.SetCoord(0, 0);
            Thread.Sleep(500);

            var x = w.Data.Left + 46;
            var y = w.Data.Top + 20;
            this.Client.Manager.MouseDown(60, 20);
            this.Client.Manager.MouseUp(60, 20);
            Thread.Sleep(200);

            w.SetCoord(prevX, prevY);
            wPJ.Show(true);

            this.Client.Manager.KeyUp(Keys.Y);
            Thread.Sleep(200);
        }

    }
}
