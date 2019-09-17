using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using YerbaSoft.Desktop.PW.Properties;

namespace YerbaSoft.Desktop.PW.Forms
{
    public partial class MainForm : Form
    {
        private BLL.PWClient LastCuentaCreated;

        public MainForm()
        {
            InitializeComponent();
            this.Hide();

            notifyIcon1.Icon = (System.Drawing.Icon)Resources.ResourceManager.GetObject(BLL.ClientManager.AppIcon);

            // ATTACH
            asociarAPWAbiertoToolStripMenuItem.DropDownItems.AddRange(
                BLL.ClientManager.Config.Cuentas.Select(p =>
                    new ToolStripMenuItem(p.Name ?? p.Login, BLL.ClientManager.GetIcon(p.Type), OnAttach) { Tag = p }
                ).ToArray()
            );
            asociarAPWAbiertoToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
            asociarAPWAbiertoToolStripMenuItem.DropDownItems.AddRange(
                BLL.ClientManager.Config.OpenAlls.Select(p =>
                    new ToolStripMenuItem("Attach " + p.Name, Resources.application_add.ToBitmap(), OnAttachAll) { Tag = p }
                ).ToArray()
            );

            // OPEN
            abrirNuevoToolStripMenuItem.DropDownItems.AddRange(
                BLL.ClientManager.Config.Cuentas.Select(p =>
                    new ToolStripMenuItem(p.Name ?? p.Login, BLL.ClientManager.GetIcon(p.Type), OnAbrirNuevo) { Tag = p }
                ).ToArray()
            );
            abrirNuevoToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
            abrirNuevoToolStripMenuItem.DropDownItems.AddRange(
                BLL.ClientManager.Config.OpenAlls.Select(p =>
                    new ToolStripMenuItem("Open " + p.Name, Resources.application_add.ToBitmap(), OnOpenAll) { Tag = p }
                ).ToArray()
            );

            // Party
            bPartys.DropDownItems.AddRange(
                BLL.DataManager.Partys.Select(p =>
                    new ToolStripMenuItem(p.Name, Resources.cd_add.ToBitmap(), (sender, e) => {
                        // busco el lider de party
                        var client = BLL.ClientManager.Cuentas.SingleOrDefault(c => c.Config.Name == p.Lider);
                        if (client == null) return;

                        var party = BLL.ClientManager.CreateParty(client);
                        party.Invite(new string[] { p.Member1, p.Member2, p.Member3, p.Member4, p.Member5 }, true, true);
                    }) { Tag = p }
                ).ToArray()
            );

            // KEYBOARD
            Windows.API.ProcessManager.OnKeyboard(IntPtr.Zero, Keys.Shift | Keys.F12, (sender, e) =>
            {
                foreach (var cuenta in BLL.ClientManager.Cuentas)
                    cuenta.Auto.StopAll();
            });

            Windows.API.ProcessManager.OnKeyboard(IntPtr.Zero, Keys.Shift | Keys.F9, (sender, e) =>
            {
                foreach (var cuenta in BLL.ClientManager.Cuentas)
                    cuenta.Auto.SetAutoFollow(!cuenta.Auto.IsAutoFollowRunning);
            });

            // Win Modes
            RefreshWinModes();

            BLL.ClientManager.OnPartyCreated += (sender, party) => WinManager.AddParty(party);
            BLL.ClientManager.OnPartyDeleted += (sender, party) => WinManager.RemoveParty(party);
        }

        private void OnOpenAll(object sender, EventArgs e)
        {
            var openall = (DTO.Configuration.OpenAll)((ToolStripMenuItem)sender).Tag;
            var cuentas = BLL.ClientManager.Config.Cuentas.Where(p => openall.Cuentas.Split(',').Contains(p.Name));

            var menus = abrirNuevoToolStripMenuItem.DropDownItems.OfType<ToolStripMenuItem>().Where(p => cuentas.Contains(p.Tag));
            foreach (var menu in menus)
            {
                OnAbrirNuevo(menu, e);
                //LastCuentaCreated.DoLogin(true);
            }
        }

        private void OnAttachAll(object sender, EventArgs e)
        {
            var openall = (DTO.Configuration.OpenAll)((ToolStripMenuItem)sender).Tag;
            var cuentas = BLL.ClientManager.Config.Cuentas.Where(p => openall.Cuentas.Split(',').Contains(p.Name));

            var menus = abrirNuevoToolStripMenuItem.DropDownItems.OfType<ToolStripMenuItem>().Where(p => cuentas.Contains(p.Tag));
            foreach (var menu in menus)
                OnAttach(menu, e);
        }

        private void OnAttach(object sender, EventArgs e)
        {
            var cCuenta = (DTO.Configuration.Cuenta)((ToolStripMenuItem)sender).Tag;

            var cuenta = BLL.ClientManager.AttachPW(cCuenta);
            if (cuenta != null)
                WinManager.AddClient(cuenta);

            LastCuentaCreated = cuenta;
        }

        private void OnAbrirNuevo(object sender, EventArgs e)
        {
            var cCuenta = (DTO.Configuration.Cuenta)((ToolStripMenuItem)sender).Tag;

            var cuenta = BLL.ClientManager.OpenPW(cCuenta);
            cuenta.Action.Global.DoLogin(true);
            if (cuenta != null)
                WinManager.AddClient(cuenta);

            LastCuentaCreated = cuenta;
        }

        private void CerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BAutoFollow_Click(object sender, EventArgs e)
        {
            foreach (var cuenta in BLL.ClientManager.Cuentas)
                cuenta.Auto.SetAutoFollow(true);
        }

        private void BAutoSpot_Click(object sender, EventArgs e)
        {
            foreach (var cuenta in BLL.ClientManager.Cuentas)
                cuenta.Auto.SetAutoSpot(true);
        }

        private void BStopAll_Click(object sender, EventArgs e)
        {
            foreach (var cuenta in BLL.ClientManager.Cuentas)
                cuenta.Auto.StopAll();
        }

        private void RefreshWinModes()
        {
            foreach (var m in bWinModes.DropDownItems.OfType<ToolStripMenuItem>().Where(p => p.Text != "- Agregar -").ToArray())
                bWinModes.DropDownItems.Remove(m);

            foreach (var m in new BLL.DataManager().WinModes.Find())
                bWinModes.DropDownItems.Add(m.Name, Resources.element_replace.ToBitmap(), OnWinMode_Click).Tag = m;
        }

        private void BWinModeAdd_Click(object sender, EventArgs e)
        {
            var dal = new BLL.DataManager().WinModes;
            var winmode = dal.GetNew();
            winmode.Name = $"Modo {dal.Count() + 1}";
            winmode.Wins = new List<DTO.Configuration.WinModes.Win>();
            foreach (var cuenta in BLL.ClientManager.Cuentas)
            {
                var rect = cuenta.Manager.GetWindowRect();
                winmode.Wins.Add(new DTO.Configuration.WinModes.Win()
                {
                    Cuenta = cuenta.Config.Name,
                    Left = rect.X,
                    Top = rect.Y,
                    Width = rect.Width,
                    Height = rect.Height
                });
            }
            dal.UpsertEntity(winmode);
            dal.Commit();
            RefreshWinModes();
        }

        private void OnWinMode_Click(object sender, EventArgs e)
        {
            var config = (DTO.Configuration.WinModes.WinMode)((ToolStripMenuItem)sender).Tag;

            foreach (var w in config.Wins)
            {
                var cuenta = BLL.ClientManager.Cuentas.SingleOrDefault(p => w.Cuenta == p.Config.Name);
                if (cuenta != null)
                    cuenta.Manager.SetWindowRect(w.Left, w.Top, w.Width, w.Height);
            }
        }

        private void BPartyNew_Click(object sender, EventArgs e)
        {
            new PartyForm().Show();
        }

        private void StartVillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var cuenta in BLL.ClientManager.Cuentas)
                cuenta.Auto.SetVilla(true);
        }
    }
}
