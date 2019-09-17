using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YerbaSoft.Desktop.PW.Client.PWI_1_3_6_2265.Structs;

namespace YerbaSoft.Desktop.PW.BLL.Actions
{
    public class ActionsInteract
    {
        public PWActions Actions { get; set; }
        public PWClient Client => Actions.Client;

        public ActionsInteract(PWActions actions)
        {
            this.Actions = actions;
        }

        public bool DoSetTargetNPCWithClick(NPCObj npc, bool waitTargetSet)
        {
            var pj = this.Client.Mem.Link.PJInfo;

            // calculo el angulo XZ
            var z = Convert.ToSingle(npc.Coord.Z - pj.Data.Coords.Z);
            var x = Convert.ToSingle(npc.Coord.X - pj.Data.Coords.X);
            var angleXZ = Convert.ToSingle(Math.Atan(x / z) * 180 / Math.PI);
            if (z < 0)
                angleXZ += 180;

            // invierto el ángulo para poner la camara atrás
            angleXZ += 180;
            if (angleXZ > 360)
                angleXZ -= 360;

            // Calculo en ángulo Y
            var npcY = new float[] { npc.CoordBottom.Y, npc.CoordHead.Y }.Average();
            var y = Convert.ToSingle(npcY - pj.Data.Coords.Y);
            var h = npc.DistAlPJ;
            var angleY = Convert.ToSingle(Math.Asin(y / h) * 180 / Math.PI);

            // Seteo la cámara
            var prevDist = pj.Data.CamDist;
            var prevAngleY = pj.Data.CamAngleY;
            var prevAngleXZ = pj.Data.CamAngleXZ;
            pj.SetCamDist(npc.DistAlPJ + 2);
            pj.SetCamAngleY(-angleY);
            pj.SetCamAngleXZ(angleXZ);


            pj.SetBloquearMovimiento(true);
            Thread.Sleep(50);
            var win = this.Client.Manager.GetWindowRect();
            this.Client.Manager.MouseDown(win.Width / 2, win.Height / 2);
            Thread.Sleep(50);
            pj.SetBloquearMovimiento(false);

            // restauro la camara
            pj.SetCamDist(prevDist);
            pj.SetCamAngleY(prevAngleY);
            pj.SetCamAngleXZ(prevAngleXZ);

            var start = DateTime.Now;
            while (waitTargetSet && start.AddSeconds(3) > DateTime.Now && this.Client.Mem.Link.PJInfo.Data.TargetId != npc.Id)
            {
                Thread.Sleep(500);
            }

            return this.Client.Mem.Link.PJInfo.Data.TargetId == npc.Id;
        }

        public bool DoTalkNearNPC(uint dbCode, string questName)
        {
            Mem.Basic.GUIObj wQuest = this.Client.Mem.Link.GetGUIObj(Mem.Basic.GUIObj.GUIs.WinTakeQuest);
            int reintento = 0;
            do
            {
                this.Client.Action.Move.DoFly(false);

                var npc = this.Client.Mem.Link.NPC.GetAll().Where(p => p.IsNPC && p.Data.dbCode == dbCode).FirstOrDefault();
                if (npc == null)
                    return false;   // no se encuentra el NPC en rango de vision

                wQuest.ReLoadData(); if (wQuest.Data.Open == 1) break;  // si está abierta la ventana de quest, voy a tomar la mision

                if (npc.Data.DistAlPJ > 1.5f) // voy caminando al npc hasta chocarme con él (por algún error en la caída)
                    this.Client.Action.Move.GoTo(false, npc.Data.Coord.X, npc.Data.Coord.Z, 0, true, false);

                // llegué cerca del NPC - acomodo lo cámara
                var targetPoint = this.Client.Action.Cam.DoCamaraVerNPC(npc.Data.Coord, npc.Data.Id);
                if (targetPoint == default)
                {
                    reintento++;
                    continue;   // error al ver al NPC
                }

                // doble click para abrir las quest
                wQuest.ReLoadData(); if (wQuest.Data.Open == 1) break;  // si está abierta la ventana de quest, voy a tomar la mision

                Thread.Sleep(200);
                this.Client.Mem.Link.PJInfo.SetTarget(npc.Data.Id);  // Selecciono el npc
                Thread.Sleep(500);

                this.Client.Manager.MouseDown(targetPoint.X, targetPoint.Y, shift: true);
                this.Client.Manager.MouseUp(targetPoint.X, targetPoint.Y, shift: true);
                Thread.Sleep(400);

                // espero a que abra las quest
                var start = DateTime.Now;
                while (start.AddSeconds(8) > DateTime.Now && wQuest.Data.Open == 0)
                {
                    wQuest.ReLoadData();
                    Thread.Sleep(200);
                }

                reintento++;
            } while (reintento < 5 && wQuest.Data.Open == 0);

            return (wQuest.Data.Open == 1) ? DoTakeMission(questName) : false;
        }

        /// <summary>
        /// Acepta una mision de la ventana de quest que ya debe estar abierta
        /// </summary>
        /// <param name="hasRelevantMission">null: opcional / true:siempre / false:nunca</param>
        private bool DoTakeMission(string questName, bool? hasRelevantMission = null)
        {
            // chekeo y/o espero que esté abierta la ventana de quest
            var winTakeQuest = this.Client.Mem.Link.GetGUIObj(Mem.Basic.GUIObj.GUIs.WinTakeQuest);
            bool opened = false;
            var reintentos = 0;
            while (!opened && reintentos < 5)
            {
                winTakeQuest.ReLoadData();
                opened = (winTakeQuest.Data.Open == 1);

                if (!opened)
                    Thread.Sleep(800);
                reintentos++;
            }

            if (!opened)
                return false;   //no está abierta la ventana de quest

            reintentos = 0;
            while (reintentos < 10)
            {
                // busco la quest correspondiente
                var questlist = this.Client.Mem.Link.WinTakeQuest.GetQuestList();
                var questlistCant = questlist.Count();

                // a veces está dentro de Relevant Mission
                int? indexQuest;
                if (hasRelevantMission ?? true)
                {
                    indexQuest = questlist.Select((p, i) => new { v = p.Contains("Relevant mission"), i = i }).Where(v => v.v).FirstOrDefault()?.i;
                    if (indexQuest.HasValue)
                    {
                        this.Client.Mem.Link.WinTakeQuest.ClickOption(indexQuest.Value, questlistCant);
                        Thread.Sleep(500);
                    }
                    else if (hasRelevantMission == true)
                    {
                        reintentos++;
                        Thread.Sleep(500);
                        continue;
                        //return false; // se exie "RelevantMission" pero no está
                    }
                }

                questlist = this.Client.Mem.Link.WinTakeQuest.GetQuestList();
                indexQuest = questlist.Select((p, i) => new { v = p.Contains(questName), i = i }).Where(v => v.v).FirstOrDefault()?.i;
                if (!indexQuest.HasValue)
                {
                    reintentos++;
                    Thread.Sleep(500);
                    continue;
                    //return false; // no existe la mision "questName" (parámetro)
                }
                this.Client.Mem.Link.WinTakeQuest.ClickOption(indexQuest.Value, questlistCant);
                Thread.Sleep(500);

                // acepto las subquest
                var wQuest = this.Client.Mem.Link.GetGUIObj(Mem.Basic.GUIObj.GUIs.WinTakeQuest);
                while (true)
                {
                    wQuest.ReLoadData();
                    if (wQuest.Data.Open == 0)
                        break;

                    this.Client.Mem.Link.WinTakeQuest.ClickOption(0, questlistCant);
                    Thread.Sleep(500);
                }

                return true;
            }

            /* queda bugueado el pj si oculto la ventana, de ultima cerrar con ESC o la "X"
            var win = this.Client.Mem.Link.GetGUIObj(Mem.Basic.GUIObj.GUIs.WinTakeQuest);
            if (win.Data.Open == 1)
                win.Show(false);
                */

            return false;
        }

    }
}
