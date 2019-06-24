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

namespace YerbaSoft.Desktop.PW.Forms
{
    public partial class MainForm : Form
    {
        private BLL.Cuenta LastCuentaCreated;

        public MainForm()
        {
            InitializeComponent();
            this.Hide();
            if (Global.Debug)
                notifyIcon1.Icon = Resources.debug_run;

            // ATTACH
            asociarAPWAbiertoToolStripMenuItem.DropDownItems.AddRange(
                Global.Config.Cuentas.Select(p =>
                    new ToolStripMenuItem(p.Name ?? p.Login, p.TypeImg, OnAttach) { Tag = p }
                ).ToArray()
            );
            asociarAPWAbiertoToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
            asociarAPWAbiertoToolStripMenuItem.DropDownItems.AddRange(
                Global.Config.OpenAlls.Select(p =>
                    new ToolStripMenuItem("Attach " + p.Name, Resources.application_add.ToBitmap(), OnAttachAll) { Tag = p }
                ).ToArray()
            );

            // OPEN
            abrirNuevoToolStripMenuItem.DropDownItems.AddRange(
                Global.Config.Cuentas.Select(p =>
                    new ToolStripMenuItem(p.Name ?? p.Login, p.TypeImg, OnAbrirNuevo) { Tag = p }
                ).ToArray()
            );
            abrirNuevoToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
            abrirNuevoToolStripMenuItem.DropDownItems.AddRange(
                Global.Config.OpenAlls.Select(p =>
                    new ToolStripMenuItem("Open " + p.Name, Resources.application_add.ToBitmap(), OnOpenAll) { Tag = p }
                ).ToArray()
            );
        }

        private void OnOpenAll(object sender, EventArgs e)
        {
            var openall = (Configuration.OpenAll)((ToolStripMenuItem)sender).Tag;
            var cuentas = Global.Config.Cuentas.Where(p => openall.Cuentas.Split(',').Contains(p.Name));

            var menus = abrirNuevoToolStripMenuItem.DropDownItems.OfType<ToolStripMenuItem>().Where(p => cuentas.Contains(p.Tag));
            foreach (var menu in menus)
            {
                OnAbrirNuevo(menu, e);
                LastCuentaCreated.DoLogin(true);
            }
        }

        private void OnAttachAll(object sender, EventArgs e)
        {
            var openall = (Configuration.OpenAll)((ToolStripMenuItem)sender).Tag;
            var cuentas = Global.Config.Cuentas.Where(p => openall.Cuentas.Split(',').Contains(p.Name));

            var menus = abrirNuevoToolStripMenuItem.DropDownItems.OfType<ToolStripMenuItem>().Where(p => cuentas.Contains(p.Tag));
            foreach (var menu in menus)
                OnAttach(menu, e);
        }

        private void OnAttach(object sender, EventArgs e)
        {
            var cCuenta = (Configuration.Cuenta)((ToolStripMenuItem)sender).Tag;

            var cuenta = Global.AttachPW(cCuenta);
            if (cuenta != null)
                new CuentaForm(cuenta).Show();

            LastCuentaCreated = cuenta;
        }

        private void OnAbrirNuevo(object sender, EventArgs e)
        {
            var cCuenta = (Configuration.Cuenta)((ToolStripMenuItem)sender).Tag;

            var cuenta = Global.OpenPW(cCuenta);
            if (cuenta != null)
                new CuentaForm(cuenta).Show();

            LastCuentaCreated = cuenta;
        }

        private void CerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BAutoFollow_Click(object sender, EventArgs e)
        {
            foreach (var cuenta in Global.Cuentas)
                cuenta.SetAutoFollow(true);
        }

        private void BAutoSpot_Click(object sender, EventArgs e)
        {
            foreach (var cuenta in Global.Cuentas)
                cuenta.SetAutoSpot(true);
        }

        private void BStopAll_Click(object sender, EventArgs e)
        {
            foreach (var cuenta in Global.Cuentas)
                cuenta.StopAll();
        }
    }
}
