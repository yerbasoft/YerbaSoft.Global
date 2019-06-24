using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Desktop.PW.Forms.Helper
{
    public class Areas : List<Area>
    {
        public class PJInfoStruct
        {
            public Area HP { get; set; }
            public Area MP { get; set; }
        }

        public class ShowInfoStruct
        {
            public Area HP { get; set; }
            public Area MP { get; set; }
            public Area Oro { get; set; }
            public Area Target { get; set; }
            public Area Cast { get; set; }
        }

        public class AutoAssistStruct
        {
            public Area AutoAssist_FollowOrden { get; set; }
        }

        public PJInfoStruct PJInfo { get; }
        public ShowInfoStruct ShowInfo { get; }
        public AutoAssistStruct AutoAssist { get; }

        public Area Menu { get; }
        public Area MenuOption { get; }

        public Area AutoKeyWin { get; }
        public Area AutoSpotWin { get; }
        public Area ShowInfoWin { get; }
        public Area AutoAssistWin { get; internal set; }

        public Areas()
        {
            Area work;
            this.PJInfo = new PJInfoStruct();
            this.Add(this.Menu = new Area() { Name = "Menu", Clickeable = true, Rect = new Rectangle(2, 6, 32, 32), Enabled = true });
            this.Add(this.MenuOption = new Area() { Name = "MenuOption", Rect = new Rectangle(0, 42, 100, 20) });

            this.Add(this.PJInfo.HP = new Area() { Name = "PJInfoHP", Rect = new Rectangle(0, 0, 34, 3) });
            this.Add(this.PJInfo.MP = new Area() { Name = "PJInfoMP", Rect = new Rectangle(0, 3, 34, 3) });

            // AutoKey
            Area AutoKeyFZone;
            Area AutoKeyDZone;
            this.Add(this.AutoKeyWin = new Area() { Name = "AutoKeyWin", Rect = new Rectangle(45, 0, 122, 170) });
            this.Add(AutoKeyFZone = new Area() { Name = "AutoKeyFZone", Rect = new Rectangle(45, 0, 70, 170) });
            this.Add(AutoKeyDZone = new Area() { Name = "AutoKeyDZone", Rect = new Rectangle(110, 0, 70, 170) });

            for (int i = 1; i <= 9; i++)
                this.Add(new Area()
                {
                    Name = $"AutoKey_{(i == 9 ? "Tab" : $"F{i}")}",
                    Rect = new Rectangle(AutoKeyFZone.Rect.X + 2, AutoKeyFZone.Rect.Y + 3 + ((AutoKeyFZone.Rect.Height / 9) * (i - 1)), AutoKeyFZone.Rect.Width - 1, AutoKeyFZone.Rect.Height / 9),
                    Clickeable = true
                });
            for (int i = 1; i <= 9; i++)
                this.Add(new Area()
                {
                    Name = $"AutoKey_D{i}",
                    Rect = new Rectangle(AutoKeyDZone.Rect.X + 2, AutoKeyDZone.Rect.Y + 3 + ((AutoKeyDZone.Rect.Height / 9) * (i - 1)), AutoKeyDZone.Rect.Width - 1, AutoKeyDZone.Rect.Height / 9),
                    Clickeable = true
                });

            this.AutoKeyWin.OnEnabledChange += (sender, e) => { foreach (var a in this.Where(p => p.Name.StartsWith("AutoKey_"))) a.Enabled = e.Enabled; };


            // AutoSpot
            this.Add(this.AutoSpotWin = new Area() { Name = "AutoSpotWin", Rect = new Rectangle(45, 0, 150, 20) });
            this.Add(work = new Area() { Name = "AutoSpot_BuffKey", Clickeable = true, Rect = this.AutoSpotWin.Rect.SetOffset(2, 20) });
            this.Add(work = new Area() { Name = "AutoSpot_BuffExpireTime", Clickeable = true, Rect = work.Rect.MoveDown(20) });
            this.Add(work = new Area() { Name = "AutoSpot_BuffCastTime", Clickeable = true, Rect = work.Rect.MoveDown(20) });

            this.Add(work = new Area() { Name = "AutoSpot_AssistKey", Clickeable = true, Rect = work.Rect.MoveDown(40) });

            this.Add(work = new Area() { Name = "AutoSpot_PickKey", Clickeable = true, Rect = work.Rect.MoveDown(40) });
            this.Add(work = new Area() { Name = "AutoSpot_PickTime", Clickeable = true, Rect = work.Rect.MoveDown(20) });

            this.Add(work = new Area() { Name = "AutoSpot_Atk1", Clickeable = true, Rect = work.Rect.MoveDown(40).SetSize(70, 20) });
            this.Add(new Area() { Name = "AutoSpot_AtkTime1", Clickeable = true, Rect = work.Rect.MoveRigth(70) });
            this.Add(work = new Area() { Name = "AutoSpot_Atk2", Clickeable = true, Rect = work.Rect.MoveDown(20) });
            this.Add(new Area() { Name = "AutoSpot_AtkTime2", Clickeable = true, Rect = work.Rect.MoveRigth(70) });
            this.Add(work = new Area() { Name = "AutoSpot_Atk3", Clickeable = true, Rect = work.Rect.MoveDown(20) });
            this.Add(new Area() { Name = "AutoSpot_AtkTime3", Clickeable = true, Rect = work.Rect.MoveRigth(70) });
            this.Add(work = new Area() { Name = "AutoSpot_Atk4", Clickeable = true, Rect = work.Rect.MoveDown(20) });
            this.Add(new Area() { Name = "AutoSpot_AtkTime4", Clickeable = true, Rect = work.Rect.MoveRigth(70) });
            this.Add(work = new Area() { Name = "AutoSpot_Atk5", Clickeable = true, Rect = work.Rect.MoveDown(20) });
            this.Add(new Area() { Name = "AutoSpot_AtkTime5", Clickeable = true, Rect = work.Rect.MoveRigth(70) });
            this.Add(work = new Area() { Name = "AutoSpot_Atk6", Clickeable = true, Rect = work.Rect.MoveDown(20) });
            this.Add(new Area() { Name = "AutoSpot_AtkTime6", Clickeable = true, Rect = work.Rect.MoveRigth(70) });
            this.AutoSpotWin.Rect = this.AutoSpotWin.Rect.SetSize(this.AutoSpotWin.Rect.Width, this.Where(p => p.Name.StartsWith("AutoSpot_")).Select(p => p.Rect.Y + p.Rect.Height).Max() - this.AutoSpotWin.Rect.Y + 2);
            this.AutoSpotWin.OnEnabledChange += (sender, e) => { foreach (var a in this.Where(p => p.Name.StartsWith("AutoSpot_"))) a.Enabled = e.Enabled; };

            // ShowInfo
            this.ShowInfo = new ShowInfoStruct();
            this.Add(this.ShowInfoWin = new Area() { Name = "ShowInfoWin", Rect = new Rectangle(45, 0, 200, 110) });
            this.Add(this.ShowInfo.HP = new Area() { Name = "ShowInfo_HP", Rect = this.ShowInfoWin.Rect.SetSize(200, 20).MoveDown(2) });
            this.Add(this.ShowInfo.MP = new Area() { Name = "ShowInfo_MP", Rect = this.ShowInfo.HP.Rect.MoveDown(20) });
            this.Add(this.ShowInfo.Oro = new Area() { Name = "ShowInfo_Oro", Rect = this.ShowInfo.MP.Rect.MoveDown(20) });
            this.Add(this.ShowInfo.Target = new Area() { Name = "ShowInfo_Target", Rect = this.ShowInfo.Oro.Rect.MoveDown(20) });
            this.Add(this.ShowInfo.Cast = new Area() { Name = "ShowInfo_Cast", Rect = this.ShowInfo.Target.Rect.MoveDown(20) });


            // Auto Assist
            this.AutoAssist = new AutoAssistStruct();
            this.Add(this.AutoAssistWin = new Area() { Name = "AutoAssistWin", Rect = new Rectangle(45, 0, 150, 20) });

            this.Add(work = new Area() { Name = "AutoAssist_AssistPJKey", Rect = this.AutoAssistWin.Rect.MoveDown(22), Clickeable = true });
            this.Add(work = new Area() { Name = "AutoAssist_AssistKey", Rect = work.Rect.MoveDown(22), Clickeable = true });
            this.Add(work = new Area() { Name = "AutoAssist_AssistTime", Rect = work.Rect.MoveDown(20), Clickeable = true });

            this.Add(work = this.AutoAssist.AutoAssist_FollowOrden = new Area() { Name = "AutoAssist_FollowOrden", Rect = work.Rect.MoveDown(42), Clickeable = true });

            this.Add(work = new Area() { Name = "AutoAssist_Atk1", Clickeable = true, Rect = work.Rect.MoveDown(40).SetSize(70, 20) });
            this.Add(new Area() { Name = "AutoAssist_AtkTime1", Clickeable = true, Rect = work.Rect.MoveRigth(70) });
            this.Add(work = new Area() { Name = "AutoAssist_Atk2", Clickeable = true, Rect = work.Rect.MoveDown(20) });
            this.Add(new Area() { Name = "AutoAssist_AtkTime2", Clickeable = true, Rect = work.Rect.MoveRigth(70) });
            this.Add(work = new Area() { Name = "AutoAssist_Atk3", Clickeable = true, Rect = work.Rect.MoveDown(20) });
            this.Add(new Area() { Name = "AutoAssist_AtkTime3", Clickeable = true, Rect = work.Rect.MoveRigth(70) });
            this.Add(work = new Area() { Name = "AutoAssist_Atk4", Clickeable = true, Rect = work.Rect.MoveDown(20) });
            this.Add(new Area() { Name = "AutoAssist_AtkTime4", Clickeable = true, Rect = work.Rect.MoveRigth(70) });
            this.Add(work = new Area() { Name = "AutoAssist_Atk5", Clickeable = true, Rect = work.Rect.MoveDown(20) });
            this.Add(new Area() { Name = "AutoAssist_AtkTime5", Clickeable = true, Rect = work.Rect.MoveRigth(70) });
            this.Add(work = new Area() { Name = "AutoAssist_Atk6", Clickeable = true, Rect = work.Rect.MoveDown(20) });
            this.Add(new Area() { Name = "AutoAssist_AtkTime6", Clickeable = true, Rect = work.Rect.MoveRigth(70) });

            this.AutoAssistWin.Rect = this.AutoSpotWin.Rect.SetSize(this.AutoAssistWin.Rect.Width, this.Where(p => p.Name.StartsWith("AutoAssist_")).Select(p => p.Rect.Y + p.Rect.Height).Max() - this.AutoAssistWin.Rect.Y + 2);
            this.AutoAssistWin.OnEnabledChange += (sender, e) => { foreach (var a in this.Where(p => p.Name.StartsWith("AutoAssist_"))) a.Enabled = e.Enabled; };
        }

        /// <summary>
        /// Devuelve el área clickeable y activada que se encuentra en las coordenadas
        /// </summary>
        public Area GetByCoords(int x, int y)
        {
            return this.Where(p => p.Clickeable && p.Enabled &&
                                   p.Rect.X <= x && (p.Rect.X + p.Rect.Width >= x) &&
                                   p.Rect.Y <= y && (p.Rect.Y + p.Rect.Height >= y)).FirstOrDefault();
        }
    }
}
