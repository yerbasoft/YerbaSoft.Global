using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YerbaSoft.Desktop.PW.Properties;
using YerbaSoft.DTO.Types;

namespace YerbaSoft.Desktop.PW.Forms
{
    public partial class CuentaForm : Form
    {
        // Toolz - Cuenta
        private Helper.Toolz Toolz;
        private BLL.Cuenta Cuenta;
        private bool PendingChanges = false;
        
        // Draw / Controls
        private Point WinMovePosition;
        private bool WinMoveMover = false;

        private Dictionary<int, string> MenuOptions;
        private string MenuOptionSelected;
        enum FormModes { Minimize, Compact, OpenAutoKey, OpenAutoSpot, OpenShowInfo, OpenAutoAssist }
        private FormModes WinMode;
        
        public CuentaForm(BLL.Cuenta cuenta = null)
        {
            InitializeComponent();
            this.Cuenta = cuenta;
            cuenta.CuentaForm = this;
            this.Toolz = new Helper.Toolz(this.Cuenta);
            this.Cuenta.Manager.SetWindowRect(this.Cuenta.Dal.GameScreenX, this.Cuenta.Dal.GameScreenY, this.Cuenta.Dal.GameScreenWidth, this.Cuenta.Dal.GameScreenHeight);

            // Form Events
            this.MouseWheel += CuentaForm_MouseWheel;
            this.Deactivate += (sender, e) => { ShowForm(FormModes.Compact); DoDraw(true); };
            this.Paint += (sender, e) => { DoDraw(true, e.Graphics); };

            this.HideIcon.DoubleClick += (sender, e) => { ShowForm(FormModes.Compact); };
            // Timers
            this.tDraw.Tick += (sender, e) => { DoDraw(); };
            this.tAutoSave.Tick += (sender, e) => { if (PendingChanges) { SaveChanges(); } };
            
            // Buttons Events
            bLogin.Click += (sender, e) => { this.Cuenta.DoLogin(); };
            bClose.Click += (sender, e) => { this.Cuenta.Dispose(); this.Close(); };
            bAntiFreeze.Click += (sender, e) => { this.Cuenta.BaseMem.SetFreezeScreen(!this.Cuenta.BaseMem.IsAntiFreezeActive); };
            bAutoKey.Click += (sender, e) => {
                if (this.Cuenta.IsAnyAutoKeyRunning)
                    this.Cuenta.StopAll();
                else
                    foreach (var k in this.Cuenta.Dal.AutoKey.GetConfiguredKeys()) this.Cuenta.SetAutoKey(k.Key, k.Value, true);
            };
            bAutoFollow.Click += (sender, e) => { this.Cuenta.SetAutoFollow(!this.Cuenta.IsAutoFollowRunning); };
            bAutoSpot.Click += (sender, e) => { this.Cuenta.SetAutoSpot(!this.Cuenta.IsAutoSpotRunning); };
            bAutoPick.Click += (sender, e) => { this.Cuenta.SetAutoPick(!this.Cuenta.IsAutoPickRunning); };
            bAutoAssist.Click += (sender, e) => { this.Cuenta.SetAutoAssist(!this.Cuenta.IsAutoAssistRunning); };
            bStopAll.Click += (sender, e) => { this.Cuenta.StopAll(); };
            bMinimize.Click += (sender, e) => { ShowForm(FormModes.Minimize); };

            // Cuenta Events
            this.Cuenta.OnAutoKeyStatusChange += (sender, e) => { bAutoKey.Checked = this.Cuenta.IsAnyAutoKeyRunning; };
            this.Cuenta.OnAutoFollowStatusChange += (sender, e) => { bAutoFollow.Checked = e; };
            this.Cuenta.OnAutoSpotStatusChange += (sender, e) => { bAutoSpot.Checked = e; };
            this.Cuenta.OnAutoPickStatusChange += (sender, e) => { bAutoPick.Checked = e; };
            this.Cuenta.OnAutoAssistStatusChange += (sender, e) => { bAutoAssist.Checked = e; };
            this.Cuenta.BaseMem.OnFreezeScreenStatusChanged += (sender, e) => { bAntiFreeze.Checked = e; };
            this.Cuenta.BaseMem.Barco1.OnPJInfoConnect += (sender, e) => { DoDraw(); if (e == null) { this.Cuenta.StopAll(); } };
            this.Cuenta.BaseMem.Barco1.OnPJInfoDataChanged += (sender, e) => { DoDraw(); };

            InitialFillData();
            
            ShowForm(FormModes.Compact);
        }

        private void InitialFillData()
        {
            this.WinMovePosition = new Point(this.Cuenta.Dal.ScreenX, this.Cuenta.Dal.ScreenY);
            
            this.MenuOptions = new Dictionary<int, string>()
            {
                { -2, "Show Info" }, { -1, "Stop All" },
                { 0, null },
                /*{ 1, "Auto Pick" },*/ { 2, "Auto Key" }, { 3, "Auto Spot" }, { 4, "Auto Assist" }
            };
        }

        private void CuentaForm_Load(object sender, EventArgs e)
        {
            if (this.WinMovePosition != Point.Empty)
                this.Location = this.WinMovePosition;
        }

        private void CuentaForm_MouseWheel(object sender, MouseEventArgs e)
        {
            var area = this.Toolz.Areas.GetByCoords(e.X, e.Y);
            if (area == null)
                return;

            // Menu
            if (area == Toolz.Areas.Menu)
            {
                var order = this.MenuOptions.Single(p => p.Value == this.MenuOptionSelected).Key;

                var ant = this.MenuOptions.Where(p => p.Key < order).Select(p => (int?)p.Key).OrderByDescending(p => p).FirstOrDefault();
                var post = this.MenuOptions.Where(p => p.Key > order).Select(p => (int?)p.Key).OrderBy(p => p).FirstOrDefault();

                if (e.Delta < 0 && ant.HasValue)
                    this.MenuOptionSelected = this.MenuOptions[ant.Value];

                else if (e.Delta > 0 && post.HasValue)
                    this.MenuOptionSelected = this.MenuOptions[post.Value];

                DoDraw();
            }

            // AutoKey
            if (WinMode == FormModes.OpenAutoKey && area.Name.StartsWith("AutoKey_"))
            {
                var key = (Keys)Enum.Parse(typeof(Keys), area.Name.Substring("AutoKey_".Length));

                var auto = this.Cuenta.Dal.AutoKey.GetValue(key);
                try
                {
                    var newvalue = (e.Delta < 0) ? Toolz.GetAvailableTimeIndexPrev(auto) : Toolz.GetAvailableTimeIndexPost(auto);
                    this.Cuenta.Dal.AutoKey.SetValue(key, newvalue);
                    PendingChanges = true;
                }
                catch { }

                DoDraw();
            }

            // Auto Spot
            if (WinMode == FormModes.OpenAutoSpot && area.Name.StartsWith("AutoSpot_"))
            {
                var prop = area.Name.Substring("AutoSpot_".Length);
                var value = this.Cuenta.Dal.AutoSpot.GetValue(prop);
                int newvalue = 0;
                switch(DAL.AutoSpotConfig.GetDataType(prop))
                {
                    case DAL.AutoSpotConfig.DataTypes.Key:
                        newvalue = Toolz.AvailableKeys.Where(p => p.Value == (string)value).Select(p => p.Key).First();
                        newvalue = (e.Delta < 0) ? Toolz.GetAvailableKeyIndexPrev(newvalue) : Toolz.GetAvailableKeyIndexPost(newvalue);
                        this.Cuenta.Dal.AutoSpot.SetValue(prop, Toolz.AvailableKeys[newvalue]);
                        break;
                    case DAL.AutoSpotConfig.DataTypes.Time:
                        newvalue = (e.Delta < 0) ? Toolz.GetAvailableTimeIndexPrev((int?)value ?? 0) : Toolz.GetAvailableTimeIndexPost((int?)value ?? 0);
                        this.Cuenta.Dal.AutoSpot.SetValue(prop, newvalue);
                        break;
                    case DAL.AutoSpotConfig.DataTypes.TimeMin:
                        newvalue = (e.Delta < 0) ? Toolz.GetAvailableTimeMinIndexPrev((int?)value ?? 0) : Toolz.GetAvailableTimeMinIndexPost((int?)value ?? 0);
                        this.Cuenta.Dal.AutoSpot.SetValue(prop, newvalue);
                        break;
                }
                DoDraw();
            }

            if (WinMode == FormModes.OpenAutoAssist && area.Name.StartsWith("AutoAssist_"))
            {
                var prop = area.Name.Substring("AutoAssist_".Length);
                var value = this.Cuenta.Dal.AutoAssist.GetValue(prop);
                int newvalue = 0;
                switch (DAL.AutoAssistConfig.GetDataType(prop))
                {
                    case DAL.AutoAssistConfig.DataTypes.Key:
                        newvalue = Toolz.AvailableKeys.Where(p => p.Value == (string)value).Select(p => p.Key).First();
                        newvalue = (e.Delta < 0) ? Toolz.GetAvailableKeyIndexPrev(newvalue) : Toolz.GetAvailableKeyIndexPost(newvalue);
                        this.Cuenta.Dal.AutoAssist.SetValue(prop, Toolz.AvailableKeys[newvalue]);
                        break;
                    case DAL.AutoAssistConfig.DataTypes.Time:
                        newvalue = (e.Delta < 0) ? Toolz.GetAvailableTimeIndexPrev((int?)value ?? 0) : Toolz.GetAvailableTimeIndexPost((int?)value ?? 0);
                        this.Cuenta.Dal.AutoAssist.SetValue(prop, newvalue);
                        break;
                    case DAL.AutoAssistConfig.DataTypes.OrdenInParty:
                        newvalue = (e.Delta < 0) ? Toolz.GetAvailableOrdenInPartyIndexPrev((int)value) : Toolz.GetAvailableOrdenInPartyIndexPost((int)value);
                        this.Cuenta.Dal.AutoAssist.SetValue(prop, newvalue);
                        break;
                }
                DoDraw();
            }
        }

        private void CuentaForm_MouseDown(object sender, MouseEventArgs e)
        {
            WinMovePosition = new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);
            WinMoveMover = true;
        }

        private void CuentaForm_MouseUp(object sender, MouseEventArgs e)
        {
            WinMoveMover = false;
            PendingChanges = true;
        }

        private void CuentaForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (WinMoveMover)
                this.Location = new Point(Cursor.Position.X - WinMovePosition.X, Cursor.Position.Y - WinMovePosition.Y);
        }
        
        private void CuentaForm_Click(object sender, EventArgs e)
        {
            var area = Toolz.Areas.GetByCoords(WinMovePosition.X, WinMovePosition.Y);
            if (area == null)
                return;

            // Menu
            if (area == Toolz.Areas.Menu)
            {
                if (this.WinMode != FormModes.Compact)
                {
                    var selected = this.MenuOptionSelected;
                    ShowForm(FormModes.Compact);
                    this.MenuOptionSelected = selected;
                }

                switch (this.MenuOptionSelected)
                {
                    case "Show Info":
                        ShowForm(FormModes.OpenShowInfo);
                        break;
                    case "Stop All":
                        this.Cuenta.StopAll();
                        break;
                    /*case "Auto Pick":
                        ShowForm(FormModes.OpenAutoPick);
                        break;*/
                    case "Auto Key":
                        ShowForm(FormModes.OpenAutoKey);
                        break;
                    case "Auto Spot":
                        ShowForm(FormModes.OpenAutoSpot);
                        break;
                    case "Auto Assist":
                        ShowForm(FormModes.OpenAutoAssist);
                        break;
                }
                this.MenuOptionSelected = null;
            }

            // AutoKey
            if (WinMode == FormModes.OpenAutoKey && area.Name.StartsWith("AutoKey_"))
            {
                var key = (Keys)Enum.Parse(typeof(Keys), area.Name.Substring("AutoKey_".Length));
                this.Cuenta.SetAutoKey(key, this.Cuenta.Dal.AutoKey.GetValue(key), !this.Cuenta.IsAutoKeyRunning(key));
            }

            DoDraw(true);
        }
                
        private void ShowForm(FormModes mode)
        {
            if (this.WinMode != mode)   // hubo cambio
            {
                // Sale del estado
                switch (this.WinMode)
                {
                    case FormModes.Minimize:
                        this.Show();
                        HideIcon.Visible = false;
                        break;
                    case FormModes.OpenAutoKey:
                        Toolz.Areas.AutoKeyWin.Enabled = false;
                        break;
                    case FormModes.OpenAutoSpot:
                        Toolz.Areas.AutoSpotWin.Enabled = false;
                        break;
                    case FormModes.OpenAutoAssist:
                        Toolz.Areas.AutoAssistWin.Enabled = false;
                        break;
                }

                // Entra al Estado
                switch(mode)
                {
                    case FormModes.Minimize:
                        this.Hide();
                        var img = (Bitmap)this.Cuenta.Config.TypeImg;
                        HideIcon.Icon = System.Drawing.Icon.FromHandle(img.GetHicon());
                        HideIcon.Text = this.Cuenta.Config.Name ?? this.Cuenta.Config.Login;
                        HideIcon.Visible = true;
                        break;
                    case FormModes.Compact:
                        this.MenuOptionSelected = null;
                        //this.Width = 36;
                        //this.Height = 56;
                        break;
                    case FormModes.OpenAutoKey:
                        Toolz.Areas.AutoKeyWin.Enabled = true;
                        break;
                    case FormModes.OpenAutoSpot:
                        Toolz.Areas.AutoSpotWin.Enabled = true;
                        break;
                    case FormModes.OpenAutoAssist:
                        Toolz.Areas.AutoAssistWin.Enabled = true;
                        break;
                }
            }

            this.WinMode = mode;
        }

        private void DoDraw(bool forceFullDraw = false, Graphics g = null)
        {
            var fullDraw = forceFullDraw || g != null || (this.Cuenta?.Config?.ShowInfo ?? false);
            
            try
            {
                g = g ?? this.CreateGraphics();
            } catch { return; }

            if (fullDraw)
                g.Clear(this.TransparencyKey);

            // menu
            if (fullDraw)
                g.DrawImage(this.Cuenta.Config.TypeImg, Toolz.Areas.Menu.Rect);


            // Menu Option Selected
            if (!fullDraw)
                g.FillRectangle(new SolidBrush(this.TransparencyKey), Toolz.Areas.MenuOption.Rect);
            g.DrawString($"{this.MenuOptionSelected}", this.Font, Brushes.Yellow, Toolz.Areas.MenuOption.Rect);


            // Circuo de Estado
            var pen = new Pen(this.TransparencyKey) { Width = 3 };  // Default: Desconectado - Transparente
            if (this.Cuenta.IsPJLoaded)
                pen.Color = Toolz.GetStatusColor();
            g.DrawEllipse(pen, Toolz.Areas.Menu.Rect);


            // ShowInfo - FIJA
            if (this.Cuenta.Config.ShowInfo ?? false)
                Toolz.DrawShowInfo(this, g, Toolz.Areas.ShowInfoWin.Rect.X * -1, Toolz.Areas.ShowInfoWin.Rect.Y * -1 + 62);


            // DATOS DE MEMORIA
            if (this.Cuenta.IsPJLoaded)
            {
                var pjinfo = this.Cuenta.PJInfoData;

                // BARRA DE HP
                g.FillRectangle(Brushes.Black, Toolz.Areas.PJInfo.HP.Rect);
                if (pjinfo.MaxHP > 0)
                {
                    var pixels = Convert.ToInt32(pjinfo.CurrentHP * Toolz.Areas.PJInfo.HP.Rect.Width / pjinfo.MaxHP);
                    g.FillRectangle(Brushes.Red, new Rectangle(Toolz.Areas.PJInfo.HP.Rect.X, Toolz.Areas.PJInfo.HP.Rect.Y, Toolz.Areas.PJInfo.HP.Rect.X + pixels, Toolz.Areas.PJInfo.HP.Rect.Height));
                }

                // BARRA DE MP
                g.FillRectangle(Brushes.Black, Toolz.Areas.PJInfo.MP.Rect);
                if (pjinfo.MaxMP > 0)
                {
                    var pixels = Convert.ToInt32(pjinfo.CurrentMP * Toolz.Areas.PJInfo.MP.Rect.Width / pjinfo.MaxMP);
                    g.FillRectangle(Brushes.Cyan, new Rectangle(Toolz.Areas.PJInfo.MP.Rect.X, Toolz.Areas.PJInfo.MP.Rect.Y, Toolz.Areas.PJInfo.MP.Rect.X + pixels, Toolz.Areas.PJInfo.MP.Rect.Height));
                }
            }

            switch(this.WinMode)
            {
                case FormModes.OpenAutoKey:
                    Toolz.DrawAutoKey(this, g);
                    break;
                case FormModes.OpenAutoSpot:
                    Toolz.DrawAutoSpot(this, g);
                    break;
                case FormModes.OpenShowInfo:
                    Toolz.DrawShowInfo(this, g, 0, 0);
                    break;
                case FormModes.OpenAutoAssist:
                    Toolz.DrawAutoAssist(this, g, 0, 0);
                    break;
            }
        }
        
        private void SaveChanges()
        {
            this.Cuenta.Dal.ScreenX = this.Location.X;
            this.Cuenta.Dal.ScreenY = this.Location.Y;

            this.Cuenta.Dal.Save(this.Cuenta);
        }
    }
}
