using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YerbaSoft.Desktop.PW.BLL;

namespace YerbaSoft.Desktop.PW.Forms.Helper
{
    public class Toolz
    {
        public Areas Areas { get; set; }
        public BLL.Cuenta Cuenta { get; set; }
        private string Status { get; set; }

        // Auto Key Status
        private string[] AutoKeyRunning { get; set; } = new string[0];

        // Valores Disponibles
        public Dictionary<int, string> AvailableKeys;
        public Dictionary<int, string> AvailableTimes;
        public Dictionary<int, string> AvailableTimeMins;
        public Dictionary<int, string> AvailableOrderInPartys;

        public Toolz(BLL.Cuenta cuenta)
        {
            this.Cuenta = cuenta;
            this.Areas = new Areas();

            this.Cuenta.OnAutoKeyStatusChange += (sender, e) => { CalculateStatus(); SaveAutoKeyStatus(); };
            this.Cuenta.OnAutoPickStatusChange += (sender, e) => { CalculateStatus(); };
            this.Cuenta.OnAutoSpotStatusChange += (sender, e) => { CalculateStatus(); };
            this.Cuenta.OnAutoFollowStatusChange += (sender, e) => { CalculateStatus(); };
            this.Cuenta.OnAutoAssistStatusChange += (sender, e) => { CalculateStatus(); };

            FillData();
        }

        private void FillData()
        {
            AvailableKeys = new Dictionary<int, string>()
            {
                { 0, null },
                { 1, "F1" },{ 2, "F2" },{ 3, "F3" },{ 4, "F4" },{ 5, "F5" },{ 6, "F6" },{ 7, "F7" },{ 8, "F8" },
                { 10, "Tab" },
                { 21, "D1" },{ 22, "D2" },{ 23, "D3" },{ 24, "D4" },{ 25, "D5" },{ 26, "D6" },{ 27, "D7" },{ 28, "D8" },{ 29, "D9" },
                { 31, "NumPad0" },{ 32, "NumPad1" },{ 33, "NumPad2" },{ 34, "NumPad3" },{ 35, "NumPad4" },{ 36, "NumPad5" },{ 37, "NumPad6" },{ 38, "NumPad7" },{ 39, "NumPad8" },{ 40, "NumPad9" }
            };

            AvailableTimes = new Dictionary<int, string>()
            {
                { 0, "off" },{ 120, "faster" },{ 500, "0.5s" }
            };
            for (var i = 1; i <= 59; i++) AvailableTimes.Add(i * 1000, $"{i}s");   // segs
            for (var i = 1; i <= 59; i++) AvailableTimes.Add(i * 60000, $"{i}m");   // mins

            AvailableTimeMins = new Dictionary<int, string>() { { 0, "off" } };
            for (var i = 1; i <= 59; i++) AvailableTimeMins.Add(i * 60000, $"{i}m");   // mins
            
            AvailableOrderInPartys = new Dictionary<int, string>() { { 0, "none" } };
            for (var i = 1; i <= 6; i++) AvailableOrderInPartys.Add(i, $"Party {i}");
        }

        #region Estado de BLL.Cuenta (módulos activados)

        public Color GetStatusColor()
        {
            switch(this.Status)
            {
                case "DEATH": return Color.Red;
                case "AutoKey": return Color.Blue;
                case "AutoFollow": return Color.Yellow;
                case "AutoSpot": return Color.Green;
                case "AutoPick": return Color.Salmon;
                case "AutoAssist": return Color.SkyBlue;
                default: return Color.LightGray;
            }
        }

        private void CalculateStatus()
        {
            this.Status = null;

            if ((this.Cuenta.BaseMem?.Barco1?.PJInfo?.Info.CurrentHP ?? uint.MaxValue) == 0)
                this.Status = "DEATH";
            else if (this.Cuenta.IsAnyAutoKeyRunning)
                this.Status = "AutoKey";
            else if (this.Cuenta.IsAutoFollowRunning)
                this.Status = "AutoFollow";
            else if (this.Cuenta.IsAutoSpotRunning)
                this.Status = "AutoSpot";
            else if (this.Cuenta.IsAutoPickRunning)
                this.Status = "AutoPick";
            else if (this.Cuenta.IsAutoAssistRunning)
                this.Status = "AutoAssist";
        }

        #endregion

        #region Draw Helper

        public void DrawAutoKey(CuentaForm form, Graphics g)
        {
            // recuadro
            g.FillRectangle(Brushes.LightSkyBlue, Areas.AutoKeyWin.Rect);
            g.DrawRectangle(new Pen(Brushes.Blue, 2), Areas.AutoKeyWin.Rect);

            foreach (var area in Areas.Where(p => p.Name.StartsWith("AutoKey_")))
            {
                var text = area.Name.Substring("AutoKey_".Length);
                var key = (Keys)Enum.Parse(typeof(Keys), text);
                var isOn = this.AutoKeyRunning.Contains(text);
                var time = AvailableTimes[Cuenta.Dal.AutoKey.GetValue(key)];
                g.DrawString($"{text}: {time}", form.Font, isOn ? Brushes.DarkGreen : Brushes.DarkRed, area.Rect);
            }
        }

        public void DrawAutoSpot(CuentaForm form, Graphics g)
        {
            // recuadro
            g.FillRectangle(Brushes.LightSeaGreen, Areas.AutoSpotWin.Rect);
            g.DrawRectangle(new Pen(Brushes.Green, 2), Areas.AutoSpotWin.Rect);

            // titulos
            var font = new Font(form.Font, FontStyle.Bold);
            g.DrawString("Buffs", font, Brushes.Black, Areas.Single(p => p.Name == "AutoSpot_BuffKey").Rect.MoveDown(-18));
            g.DrawString("Seleccion de Mobs", font, Brushes.Black, Areas.Single(p => p.Name == "AutoSpot_AssistKey").Rect.MoveDown(-18));
            g.DrawString("Pick Up", font, Brushes.Black, Areas.Single(p => p.Name == "AutoSpot_PickKey").Rect.MoveDown(-18));
            g.DrawString("Ataques", font, Brushes.Black, Areas.Single(p => p.Name == "AutoSpot_Atk1").Rect.MoveDown(-18));

            foreach (var area in this.Areas.Where(p => p.Name.StartsWith("AutoSpot_")))
            {
                var field = area.Name.Substring("AutoSpot_".Length);
                var value = typeof(DAL.AutoSpotConfig).GetProperty(field).GetValue(this.Cuenta.Dal.AutoSpot);
                string text;
                switch (DAL.AutoSpotConfig.GetDataType(field))
                {
                    case DAL.AutoSpotConfig.DataTypes.Time:
                        text = AvailableTimes[(int?)value ?? 0];
                        break;
                    case DAL.AutoSpotConfig.DataTypes.TimeMin:
                        text = AvailableTimeMins[(int?)value ?? 0];
                        break;
                    default:
                        text = (value ?? "").ToString();
                        break;

                }
                g.DrawString($"{DAL.AutoSpotConfig.GetTitle(field)}: {text}", form.Font, Brushes.White, area.Rect);
            }
        }

        public void DrawShowInfo(CuentaForm form, Graphics g, int offsetX, int offsetY)
        {
            //g.FillRectangle(Brushes.LightCoral, Areas.ShowInfoWin.Rect.SetOffset(offsetX, offsetY));
            g.FillRectangle(new SolidBrush(form.TransparencyKey), Areas.ShowInfoWin.Rect.SetOffset(offsetX, offsetY));
            g.DrawString($"HP: {this.Cuenta.BaseMem?.Barco1?.PJInfo?.Info.CurrentHP} / {this.Cuenta.BaseMem?.Barco1?.PJInfo?.Info.MaxHP}", form.Font, Brushes.White, Areas.ShowInfo.HP.Rect.SetOffset(offsetX, offsetY));
            g.DrawString($"MP: {this.Cuenta.BaseMem?.Barco1?.PJInfo?.Info.CurrentMP} / {this.Cuenta.BaseMem?.Barco1?.PJInfo?.Info.MaxMP}", form.Font, Brushes.White, Areas.ShowInfo.MP.Rect.SetOffset(offsetX, offsetY));
            g.DrawString($"Oro: {this.Cuenta.BaseMem?.Barco1?.PJInfo?.Info.InventoryGold}", form.Font, Brushes.White, Areas.ShowInfo.Oro.Rect.SetOffset(offsetX, offsetY));
            g.DrawString($"Target: {this.Cuenta.BaseMem?.Barco1?.PJInfo?.Info.TargetId}", form.Font, Brushes.White, Areas.ShowInfo.Target.Rect.SetOffset(offsetX, offsetY));
            g.DrawString($"Cast: {this.Cuenta.BaseMem?.Barco1?.PJInfo?.Info.CastId}", form.Font, Brushes.White, Areas.ShowInfo.Cast.Rect.SetOffset(offsetX, offsetY));
        }

        internal void DrawAutoAssist(CuentaForm form, Graphics g, int offsetX, int offsetY)
        {
            // recuadro
            g.FillRectangle(Brushes.SkyBlue, Areas.AutoAssistWin.Rect);
            g.DrawRectangle(new Pen(Brushes.Blue, 2), Areas.AutoAssistWin.Rect);

            // titulos
            var font = new Font(form.Font, FontStyle.Bold);
            g.DrawString("Assist", font, Brushes.Black, Areas.AutoAssistWin.Rect.MoveDown(2));
            g.DrawString("Follow", font, Brushes.Black, Areas.AutoAssist.AutoAssist_FollowOrden.Rect.MoveDown(-20));
            g.DrawString("Attack", font, Brushes.Black, Areas.AutoAssist.AutoAssist_FollowOrden.Rect.MoveDown(20));

            foreach (var area in this.Areas.Where(p => p.Name.StartsWith("AutoAssist_")))
            {
                var field = area.Name.Substring("AutoAssist_".Length);
                var value = this.Cuenta.Dal.AutoAssist.GetValue(field);
                string text;
                switch (DAL.AutoAssistConfig.GetDataType(field))
                {
                    case DAL.AutoAssistConfig.DataTypes.Time:
                        text = AvailableTimes[(int)value];
                        break;
                    case DAL.AutoAssistConfig.DataTypes.OrdenInParty:
                        text = AvailableOrderInPartys[(int)value];
                        break;
                    default:
                        text = (value ?? "").ToString();
                        break;

                }
                g.DrawString($"{DAL.AutoAssistConfig.GetTitle(field)}: {text}", form.Font, Brushes.Blue, area.Rect);
            }
        }

        #endregion

        #region Available Values

        public int GetAvailableKeyIndexPrev(int current)
        {
            try { return AvailableKeys.Where(p => p.Key < current).Max(p => p.Key); } catch { return current; }
        }
        public int GetAvailableKeyIndexPost(int current)
        {
            try { return AvailableKeys.Where(p => p.Key > current).Min(p => p.Key); } catch { return current; }
        }

        public int GetAvailableTimeIndexPrev(int current)
        {
            try { return AvailableTimes.Where(p => p.Key < current).Max(p => p.Key); } catch { return current; }
        }
        public int GetAvailableTimeIndexPost(int current)
        {
            try { return AvailableTimes.Where(p => p.Key > current).Min(p => p.Key); } catch { return current; }
        }

        public int GetAvailableTimeMinIndexPrev(int current)
        {
            try { return AvailableTimeMins.Where(p => p.Key < current).Max(p => p.Key); } catch { return current; }
        }
        public int GetAvailableTimeMinIndexPost(int current)
        {
            try { return AvailableTimeMins.Where(p => p.Key > current).Min(p => p.Key); } catch { return current; }
        }

        public int GetAvailableOrdenInPartyIndexPrev(int current)
        {
            try { return AvailableOrderInPartys.Where(p => p.Key < current).Max(p => p.Key); } catch { return current; }
        }
        public int GetAvailableOrdenInPartyIndexPost(int current)
        {
            try { return AvailableOrderInPartys.Where(p => p.Key > current).Min(p => p.Key); } catch { return current; }
        }

        #endregion

        #region AutoKey Controls

        private void SaveAutoKeyStatus()
        {
            this.AutoKeyRunning = this.Cuenta.GetAutoKeyRunningKeys().Select(p => p.ToString()).ToArray();
        }

        #endregion
    }
}
