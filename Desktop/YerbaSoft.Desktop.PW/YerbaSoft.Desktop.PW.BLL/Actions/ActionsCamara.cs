using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.Desktop.PW.Client.PWI_1_3_6_2265.Structs;

namespace YerbaSoft.Desktop.PW.BLL.Actions
{
    public class ActionsCamara
    {
        public PWActions Actions { get; set; }
        public PWClient Client => Actions.Client;

        public ActionsCamara(PWActions actions)
        {
            this.Actions = actions;
        }

        public Point DoCamaraVerNPC(Point3D target, uint targetid)
        {
            var npc = this.Client.Mem.Link.NPC.GetAll().SingleOrDefault(p => p.Data.Id == targetid).Data;
            var pj = this.Client.Mem.Link.PJInfo;

            var z = Convert.ToSingle(target.Z - pj.Data.Coords.Z);
            var x = Convert.ToSingle(target.X - pj.Data.Coords.X);
            var angleXZ = Convert.ToSingle(Math.Atan(x / z) * 180 / Math.PI);
            if (z < 0)
                angleXZ += 180;

            pj.SetCamDist(1.5f);
            pj.SetCamAngleY(-30);
            pj.SetCamAngleXZ(angleXZ);

            var screen = this.Client.Manager.GetWindowRect();
            var centerScreen = new Point(screen.Width / 2, 5 * screen.Height / 8);
            return centerScreen;
        }

    }
}
