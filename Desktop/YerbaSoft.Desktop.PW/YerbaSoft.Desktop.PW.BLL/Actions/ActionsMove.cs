using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YerbaSoft.Desktop.PW.Client.PWI_1_3_6_2265.Structs;

namespace YerbaSoft.Desktop.PW.BLL.Actions
{
    public class ActionsMove
    {
        public PWActions Actions { get; set; }
        public PWClient Client => Actions.Client;

        public ActionsMove(PWActions actions)
        {
            this.Actions = actions;
        }

        public void DoFly(bool fly, float alturaMinima = 0)
        {
            if ((fly && this.Client.Mem.Base1.PJInfo.Data.TransportMode == 0) ||
                (!fly && this.Client.Mem.Base1.PJInfo.Data.TransportMode == 2))  // parado y quiero volar o volando y quiero pararme
            {
                var wAction = this.Client.Mem.Link.GetGUIObj(BLL.Mem.Basic.GUIObj.GUIs.WinAction);
                wAction.Show(true);
                Thread.Sleep(100);

                this.Client.Manager.MouseDown(Convert.ToInt32(wAction.Data.Left + 170), Convert.ToInt32(wAction.Data.Top + 92));
                this.Client.Manager.MouseUp(Convert.ToInt32(wAction.Data.Left + 170), Convert.ToInt32(wAction.Data.Top + 92));
                Thread.Sleep(500);
                wAction.Show(false);
                Thread.Sleep(1000);
            }

            if (fly && alturaMinima > 0)
            {
                lock (BLL.ClientManager.TakeControlKeyboard)
                {
                    var start = DateTime.Now;
                    while (this.Client.Mem.Base1.PJInfo.Data.Coords.Y < alturaMinima && start.AddSeconds(12) > DateTime.Now)
                    {
                        this.Client.Manager.SetWindowForeground();
                        this.Client.Manager.KeyDownSimulator(Keys.Space);
                    }
                    this.Client.Manager.KeyUpSimulator(Keys.Space);
                }
            }
        }

        public bool GoTo(bool flying, float x, float z, int altura, bool esperar, bool freezeDuringFly)
        {
            // seteo el punto
            var wPoints = this.Client.Mem.Link.GetGUIObj(BLL.Mem.Basic.GUIObj.GUIs.WinPoints);
            var pointer = this.Client.Mem.Link.GetPointerObj();

            if (!pointer.IsValid)
            {
                wPoints.Show(true);

                Thread.Sleep(100);
                this.Client.Manager.MouseDown(Convert.ToInt32(wPoints.Data.Left + 230), Convert.ToInt32(wPoints.Data.Top + 40));
                this.Client.Manager.MouseUp(Convert.ToInt32(wPoints.Data.Left + 230), Convert.ToInt32(wPoints.Data.Top + 40));
                Thread.Sleep(100);
                for (var i = 0; i <= 10; i++) this.Client.Manager.KeyPress(Keys.Back);
                this.Client.Manager.KeyUp(Keys.D1);
                this.Client.Manager.KeyUp(Keys.Space);
                this.Client.Manager.KeyUp(Keys.D1);
                Thread.Sleep(100);
                this.Client.Manager.KeyDown(Keys.Enter);
                Thread.Sleep(100);
                this.Client.Manager.KeyUp(Keys.D1);
                Thread.Sleep(100);
                this.Client.Manager.KeyDown(Keys.Enter);
                this.Client.Manager.KeyUp(Keys.Enter);
                Thread.Sleep(200);

                wPoints = this.Client.Mem.Link.GetGUIObj(BLL.Mem.Basic.GUIObj.GUIs.WinPoints);
                pointer = this.Client.Mem.Link.GetPointerObj();
            }

            pointer.SetCoords(x, z);

            bool arrive = false;
            while (!arrive)
            {
                if (flying)
                    DoFly(true);

                lock (ClientManager.TakeControlKeyboard)
                {
                    // doble click al punto
                    wPoints.Show(true);
                    Thread.Sleep(100);
                    this.Client.Manager.MouseDblClick(Convert.ToInt32(wPoints.Data.Left + 220), Convert.ToInt32(wPoints.Data.Top + 63));
                    Thread.Sleep(100);
                    wPoints.Show(false);
                    Thread.Sleep(100);

                    // ajustar la altura
                    var wAutoPathing = this.Client.Mem.Link.GetGUIObj(BLL.Mem.Basic.GUIObj.GUIs.WinAutoPathing);
                    if (altura > 0)
                    {
                        lock (ClientManager.TakeControlKeyboard)
                        {
                            this.Client.Manager.MouseDown(Convert.ToInt32(wAutoPathing.Data.Left + 140), Convert.ToInt32(wAutoPathing.Data.Top + 43));
                            this.Client.Manager.MouseUp(Convert.ToInt32(wAutoPathing.Data.Left + 140), Convert.ToInt32(wAutoPathing.Data.Top + 43));
                            Thread.Sleep(100);
                            this.Client.Manager.KeyPress(Keys.Back);
                            this.Client.Manager.KeyPress(Keys.Back);
                            this.Client.Manager.KeyPress(Keys.Back);
                            this.Client.Manager.KeyPress(Keys.Back);
                            Thread.Sleep(100);
                            // escribo la altura
                            foreach (var l in altura.ToString())
                                this.Client.Manager.KeyUp((Keys)Enum.Parse(typeof(Keys), $"D{l}"));
                            Thread.Sleep(500);

                            // chequeo de cancelfly
                            var wininfo = this.Client.MemMgr.ReadStruct<GUIWinInfoAutoPath>(wAutoPathing.Data.pGUIWinInfoAutoPath);
                            if (wininfo.StopOnArrive == 0)
                            {
                                // 18,80
                                this.Client.Manager.MouseDown(Convert.ToInt32(wAutoPathing.Data.Left + 18), Convert.ToInt32(wAutoPathing.Data.Top + 80));
                                this.Client.Manager.MouseUp(Convert.ToInt32(wAutoPathing.Data.Left + 18), Convert.ToInt32(wAutoPathing.Data.Top + 80));
                                Thread.Sleep(500);
                            }
                        }
                        lock (ClientManager.TakeControlMouse)
                        {
                            // confirm 
                            this.Client.Manager.MouseMove(Convert.ToInt32(wAutoPathing.Data.Left + 99), Convert.ToInt32(wAutoPathing.Data.Top + 108));
                            this.Client.Manager.MouseDown(Convert.ToInt32(wAutoPathing.Data.Left + 99), Convert.ToInt32(wAutoPathing.Data.Top + 108));
                            this.Client.Manager.MouseUp(Convert.ToInt32(wAutoPathing.Data.Left + 99), Convert.ToInt32(wAutoPathing.Data.Top + 108));
                            Thread.Sleep(500);
                            this.Client.Manager.MouseDown(Convert.ToInt32(wAutoPathing.Data.Left + 99), Convert.ToInt32(wAutoPathing.Data.Top + 108));
                            this.Client.Manager.MouseUp(Convert.ToInt32(wAutoPathing.Data.Left + 99), Convert.ToInt32(wAutoPathing.Data.Top + 108));
                        }

                    }
                }

                if (!esperar)
                    return true;

                // esperar a llegar
                if (freezeDuringFly) this.Client.Mem.SetFreeze(true, false);
                var coords = this.Client.Action.Move.WaitToStop();
                if (freezeDuringFly) this.Client.Mem.SetFreeze(false, true);

                // verificar si llegué o vuelvo a intentar
                arrive = coords.InRange2D(new Point3D() { X = x, Z = z }, 1.5f);

                if (this.Client.Mem.Link.PJInfo.Data.CurrHP == 0)
                    return false;   // estoy muerto ¿revivir?
            }

            return true;
        }

        public Point3D WaitToStop()
        {
            Point3D ant = new Point3D();
            var quietoIntentos = 0;
            while (true)
            {
                var act = this.Client.Mem.Link.PJInfo.Data.Coords;
                if (ant.X == act.X && ant.Y == act.Y && ant.Z == act.Z)
                    quietoIntentos++;
                else
                    quietoIntentos = 0;

                if (quietoIntentos == 3)
                    return act;

                ant = act;
                Thread.Sleep(500);
            }
        }
    }
}
