using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsHelper.Interfaces;

namespace WindowsHelper.Forms
{
    public partial class MainForm : Form, Interfaces.ILoggeable
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void Log(string text)
        {
            try
            { 
                this.txtLog.Text += text + Environment.NewLine;
                this.txtLog.SelectionStart = this.txtLog.TextLength;
                this.txtLog.ScrollToCaret();
            }
            catch (InvalidOperationException ex)
            {
                // error de Threads
            }
            catch (Exception ex)
            {
                Global.Log(ex);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Global.IsDebugMode)
                WinIcon.Icon = Properties.Resources.debug_into;

            UpdateMenu(sender, e);
        }

        private void Update_Click(object sender, EventArgs e)
        {
            UpdateMenu(sender, e);
        }

        private void WinIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.None || e.CloseReason == CloseReason.UserClosing)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                e.Cancel = true;
            }
            else
            {
                Application.Exit();
            }
        }

        private void UpdateMenu(object sender, EventArgs e)
        {
            var items = Global.RaiseOnCreateMenu();

            MainMenuContext.Items.Clear();

            // top
            MainMenuContext.Items.Add(new ToolStripMenuItem("Windows Helper", Common.Properties.Resources.WindowsHelper.ToBitmap()));
            MainMenuContext.Items.Add(new ToolStripSeparator());

            //var i = 2;
            foreach (var m in items)
                MainMenuContext.Items.Add(m);

            // bottom
            MainMenuContext.Items.Add(new ToolStripSeparator());
            var update = new ToolStripMenuItem("Update", Common.Properties.Resources.update.ToBitmap(), UpdateMenu);
            MainMenuContext.Items.Add(update);
        }

    }
}
