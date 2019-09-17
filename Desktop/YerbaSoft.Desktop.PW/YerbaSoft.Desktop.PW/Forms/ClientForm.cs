using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YerbaSoft.Desktop.PW.BLL;
using YerbaSoft.Desktop.PW.Properties;

namespace YerbaSoft.Desktop.PW.Forms
{
    public partial class ClientForm : Form
    {
        public BLL.PWClient Client { get; set; }
        private Helper.FormTools Tools { get; set; }

        // Draw / Controls
        private Point WinMovePosition = Point.Empty;
        private bool WinMoveMover = false;

        // Options
        private Dictionary<int, string> MenuOptions;
        private string MenuOptionSelected { get; set; }
        private ShowInfoForm ShowInfoForm { get; set; }
        private AutoAssistForm AutoAssistForm { get; set; }
        private AutoSpotForm AutoSpotForm { get; set; }
        private AutoKeyForm AutoKeyForm { get; set; }

        internal Rectangle IconArea = new Rectangle(2, 6, 32, 32);

        public event EventHandler<Point> OnCustomMove;

        public ClientForm(BLL.PWClient client)
        {
            InitializeComponent();
            // EVENTS
            this.Paint += (sender, e) => DoDraw(e.Graphics);
            this.Load += (sender, e) => { if (this.WinMovePosition != Point.Empty) this.Location = this.WinMovePosition; };
            this.MouseWheel += ClientForm_MouseWheel;
            this.Click += ClientForm_Click;
            this.Activated += (sender, e) => { this.Location = new Point(this.Client.dbConfig.ScreenX, this.Client.dbConfig.ScreenY); };
            this.Deactivate += (sender, e) => { HideAll(); };
            this.tmrSave.Tick += (sender, e) => { this.Client.dbConfig.Save(this.Client.Manager.GetWindowRect()); };

            this.DoubleClick += (sender, e) => { this.Client.Action.Global.Test(); };

            // Windows Move
            this.MouseDown += (sender, e) =>
            {
                WinMovePosition = new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);
                WinMoveMover = true;
            };
            this.MouseMove += (sender, e) => {
                if (WinMoveMover)
                {
                    var x = Convert.ToInt32(Math.Round((Cursor.Position.X - WinMovePosition.X) / 20.0) * 20);
                    var y = Convert.ToInt32(Math.Round((Cursor.Position.Y - WinMovePosition.Y) / 20.0) * 20);

                    this.Location = new Point(x, y);
                    OnCustomMove?.Invoke(this, this.Location);
                }
            };
            this.MouseUp += (sender, e) =>
            {
                WinMoveMover = false;
                this.Client.dbConfig.ScreenX = this.Location.X;
                this.Client.dbConfig.ScreenY = this.Location.Y;
                this.Client.dbConfig.PendingChanges = true;
            };

            // Menu
            bLogin.Click += (sender, e) => { this.Client.Action.Global.DoLogin(); };
            bClose.Click += (sender, e) => { this.Client.dbConfig.Save(this.Client.Manager.GetWindowRect()); this.Client.Dispose(); this.Close(); };
            bCloseClient.Click += (sender, e) => {
                this.Client.dbConfig.Save(this.Client.Manager.GetWindowRect());
                var mgr = this.Client.Manager;
                WinManager.RemoveClient(this.Client);
                this.Client.Dispose();
                mgr.CloseApp();
                this.Close();
            };
            bAntiFreeze.Click += (sender, e) => { this.Client.Config.AntiFreeze = !(this.Client.Config.AntiFreeze ?? true); };
            bAutoKey.Click += (sender, e) => { this.Client.Auto.SetAutoKeyAll(!this.Client.Auto.IsAnyAutoKeyRunning); };
            bAutoFollow.Click += (sender, e) => { this.Client.Auto.SetAutoFollow(!this.Client.Auto.IsAutoFollowRunning); };
            bAutoSpot.Click += (sender, e) => { this.Client.Auto.SetAutoSpot(!this.Client.Auto.IsAutoSpotRunning); };
            bAutoAssist.Click += (sender, e) => { this.Client.Auto.SetAutoAssist(!this.Client.Auto.IsAutoAssistRunning); };
            bAutoVilla.Click += (sender, e) => { this.Client.Auto.SetVilla(!this.Client.Auto.IsVillaRunning); };
            bStopAll.Click += (sender, e) => { this.Client.Auto.StopAll(); };
            bPartyMenu.DropDownOpening += (sender, e) => RefreshPartyMenu();
            bPartyCreateNew.Click += (sender, e) => BLL.ClientManager.CreateParty(this.Client);
            bShowWinChat.Click += (sender, e) => this.Client.dbConfig.HideWinChat = !this.Client.dbConfig.HideWinChat;
            bShowWins.DropDownOpening += (sender, e) =>
            {
                bShowWinChat.Checked = !this.Client.dbConfig.HideWinChat;
            };

            this.Client = client;

            // Menu - Key Events
            this.Client.Manager.OnKeyboard(Keys.F12, (sender, e) => { this.Client.Auto.StopAll(); });
            this.Client.Manager.OnKeyboard(Keys.F9, (sender, e) => { this.Client.Auto.SetAutoFollow(!this.Client.Auto.IsAutoFollowRunning); });
            this.Client.Manager.OnKeyboard(Keys.Control | Keys.S, (sender, e) => { this.Client.Auto.SetAutoSpot(!this.Client.Auto.IsAutoSpotRunning); });
            this.Client.Manager.OnKeyboard(Keys.Control | Keys.A, (sender, e) => { this.Client.Auto.SetAutoAssist(!this.Client.Auto.IsAutoAssistRunning); });
            this.Client.Manager.OnKeyboard(Keys.Control | Keys.K, (sender, e) => { this.Client.Auto.SetAutoKeyAll(!this.Client.Auto.IsAnyAutoKeyRunning); });

            // Client events
            this.Client.Auto.OnAutoKeyStatusChange += (sender, e) => { bAutoKey.Checked = this.Client.Auto.IsAnyAutoKeyRunning; };
            this.Client.Auto.OnAutoFollowStatusChange += (sender, e) => { bAutoFollow.Checked = e; };
            this.Client.Auto.OnAutoSpotStatusChange += (sender, e) => { bAutoSpot.Checked = e; };
            this.Client.Auto.OnAutoAssistStatusChange += (sender, e) => { bAutoAssist.Checked = e; };
            this.Client.Auto.OnVillaStatusChange += (sender, e) => { this.Tools.MultiThreadSafe(this.Menu, () => { bAutoVilla.Checked = this.Client.Auto.IsVillaRunning; }); };

            this.Tools = new Helper.FormTools(this, this.Client);
            this.AutoKeyForm = new AutoKeyForm(this, this.Client);
            this.AutoSpotForm = new AutoSpotForm(this, this.Client);
            this.AutoAssistForm = new AutoAssistForm(this, this.Client);
            this.ShowInfoForm = new ShowInfoForm(this, this.Client);

            LoadInitialValues();
        }

        private void HideAll()
        {
            this.AutoAssistForm.SetShow(false);
            this.AutoKeyForm.SetShow(false);
            this.AutoSpotForm.SetShow(false);
            this.ShowInfoForm.SetShow(false);
        }

        private void ClientForm_Click(object sender, EventArgs e)
        {
            switch (this.MenuOptionSelected)
            {
                case "Show Info":
                    this.ShowInfoForm.SetShow(true);
                    break;
                case "Stop All":
                    this.Client.Auto.StopAll();
                    break;
                case "Auto Key":
                    AutoKeyForm.SetShow(true);
                    break;
                case "Auto Spot":
                    AutoSpotForm.SetShow(true);
                    break;
                case "Auto Assist":
                    AutoAssistForm.SetShow(true);
                    break;
            }

            this.MenuOptionSelected = null;
            DoDraw();
        }

        private void ClientForm_MouseWheel(object sender, MouseEventArgs e)
        {
            var order = this.MenuOptions.Single(p => p.Value == this.MenuOptionSelected).Key;

            if (e.Delta < 0)
            {
                var ant = this.MenuOptions.Where(p => p.Key < order).Select(p => (int?)p.Key).OrderByDescending(p => p).FirstOrDefault();
                if (ant != null)
                    this.MenuOptionSelected = this.MenuOptions[ant.Value];
            } else if (e.Delta > 0)
            {
                var post = this.MenuOptions.Where(p => p.Key > order).Select(p => (int?)p.Key).OrderBy(p => p).FirstOrDefault();
                if (post != null)
                    this.MenuOptionSelected = this.MenuOptions[post.Value];
            }

            DoDraw();
        }

        private void LoadInitialValues()
        {
            this.WinMovePosition = new Point(this.Client.dbConfig.ScreenX, this.Client.dbConfig.ScreenY);

            this.MenuOptions = new Dictionary<int, string>()
            {
                { -2, "Show Info" }, { -1, "Stop All" },
                { 0, null },
                { 1, "Auto Key" }, { 2, "Auto Spot" }, { 3, "Auto Assist" }
            };

            foreach(var type in BLL.DataManager.GoTo.Select(p => p.Type).Distinct().OrderBy(p => p))
            {
                ToolStripMenuItem m;
                bGoTo.DropDownItems.Add(m = new ToolStripMenuItem(type, bGoTo.Image));

                m.DropDownItems.AddRange(
                    BLL.DataManager.GoTo.Where(p => p.Type == type).OrderBy(p => p.Name).Select(p => new ToolStripMenuItem(p.Name, bGoTo.Image) { Tag = p }.Do((e) => { e.Click += OnGoTo; })).ToArray()
                );
            }
            
        }

        private void OnGoTo(object sender, EventArgs e)
        {
            var p = (DTO.Data.MapPoint)((ToolStripMenuItem)sender).Tag;
            this.Client.Auto.StopAll();
            this.Client.Action.Move.GoTo(true, p.X, p.Z, 63, false, false);
        }

        private void DoDraw(Graphics g = null)
        {
            try { g = g ?? this.CreateGraphics(); } catch { return; }

            // ícono
            Rectangle rect;
            g.DrawImage(BLL.ClientManager.GetIcon(this.Client.Config.Type), rect = IconArea);

            // Menu Option Selected
            g.FillRectangle(new SolidBrush(this.TransparencyKey), rect = new Rectangle(0, 42, 100, 20));
            g.DrawString(this.MenuOptionSelected, this.Font, Brushes.Yellow, rect);

            /*
            // HIERROS
            if ((this.Cuenta?.BaseMem?.Barco1?.PJInfo?.HieroHP.Internal ?? 0) > 0)
            {
                // BARRA DE HP
                var maxhp = 600000;
                var hp = this.Cuenta.BaseMem.Barco1.PJInfo.HieroHP.Value;
                g.FillRectangle(Brushes.Black, Toolz.Areas.PJInfo.HP.Rect);
                var pixels = Convert.ToInt32(hp * Toolz.Areas.PJInfo.HP.Rect.Width / maxhp);
                g.FillRectangle(Brushes.Red, new Rectangle(Toolz.Areas.PJInfo.HP.Rect.X, Toolz.Areas.PJInfo.HP.Rect.Y, Toolz.Areas.PJInfo.HP.Rect.X + pixels, Toolz.Areas.PJInfo.HP.Rect.Height));
            }
            if ((this.Cuenta?.BaseMem?.Barco1?.PJInfo?.HieroMP.Internal ?? 0) > 0)
            {
                // BARRA DE MP
                var maxmp = 900000;
                var mp = this.Cuenta.BaseMem.Barco1.PJInfo.HieroMP.Value;
                g.FillRectangle(Brushes.Black, Toolz.Areas.PJInfo.MP.Rect);
                var pixels = Convert.ToInt32(mp * Toolz.Areas.PJInfo.MP.Rect.Width / maxmp);
                g.FillRectangle(Brushes.Cyan, new Rectangle(Toolz.Areas.PJInfo.MP.Rect.X, Toolz.Areas.PJInfo.MP.Rect.Y, Toolz.Areas.PJInfo.MP.Rect.X + pixels, Toolz.Areas.PJInfo.MP.Rect.Height));
            }
            */
        }

        private void RefreshPartyMenu()
        {
            foreach (var m in bPartyMenu.DropDownItems.OfType<ToolStripMenuItem>().Where(p => p != bPartyCreateNew).ToArray())
                bPartyMenu.DropDownItems.Remove(m);

            foreach(var party in BLL.ClientManager.Partys)
            {
                var img = Resources.cd_into.ToBitmap();
                if (party.Cuentas.Contains(this.Client))
                    img = Resources.cd_delete.ToBitmap();

                var m = new ToolStripMenuItem(party.ToString(), img, (sender, e) => { ((PWParty)((ToolStripMenuItem)sender).Tag).ToggleCuenta(this.Client); });
                m.Tag = party;
                bPartyMenu.DropDownItems.Add(m);
            }
        }
    }
}
