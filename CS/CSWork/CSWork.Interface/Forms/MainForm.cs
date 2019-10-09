using CSWork.Interface.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSWork.Interface.Forms
{
    public partial class MainForm : Form
    {
        private Login fLogin = null;
        private Configuration fConfiguration = null;

        private Model.Utils Utils { get; set; }
        private Model.MenuBuilder MenuBuilder { get; set; }
        private Model.AlertManager AlertManager { get; set; }

        public MainForm()
        {
            InitializeComponent();

            this.Icon = AreaIcon.Icon = Resources.bookmarks;
            if (Application.ExecutablePath.Contains("\\bin\\Debug"))
                AreaIcon.Icon = Resources.bookmarks_preferences;
            AreaIconMenuDisconnected.Icon = Resources.bookmark_delete;

            this.Utils = new Model.Utils(this);
            this.MenuBuilder = new Model.MenuBuilder(AreaIconMenu, this.Utils);
            this.AlertManager = new Model.AlertManager(this.Utils);

            ReValidUser();
        }

        public void ReValidUser()
        {
            var validuser = BLL.Factory.Jira.Config.IsLogon();
            AreaIcon.Visible = validuser;
            AreaIconMenuDisconnected.Visible = !validuser;

            bCurrentUser.Text = (BLL.Factory.Jira.Config.User ?? "").Split('@')[0];
        }

        #region Menu Events

        private void MLogIn_Click(object sender, EventArgs e)
        {
            if (fLogin == null)
            {
                (fLogin = new Login()).ShowDialog();
                ReValidUser();
                fLogin = null;
            }
        }

        private void AreaIconMenuDisconnected_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                MLogIn_Click(sender, null);
        }

        private void BLogout_Click(object sender, EventArgs e)
        {
            BLL.Factory.Jira.SetJiraConnection(null, null, null);
            ReValidUser();
            MLogIn_Click(sender, e);
        }

        private void BObtenerTokenJira_Click(object sender, EventArgs e)
        {   
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(BLL.Factory.GetTokenUrl) { UseShellExecute = true, Verb = "OPEN" });
        }

        private void MRegisterTask_Click(object sender, EventArgs e)
        {
            new Forms.Tools.RegisterWork(null).ShowDialog();
        }

        private void MToolGenerarPasswordWeb_Click(object sender, EventArgs e)
        {
            new Tools.GenerarPasswordWeb().Show();
        }

        private void MToolGeneraroAuth_Click(object sender, EventArgs e)
        {
            new Tools.GeneraroAuth().Show();
        }

        private void MClose_Click(object sender, EventArgs e)
        {
            BLL.Factory.Dispose();  //  Libero todos los recursos
            this.Close();
            Application.Exit();
        }

        private void MConfiguration_Click(object sender, EventArgs e)
        {
            OpenConfiguration(Configuration.ConfigurationTabs.General);
        }

        #endregion

        private void MMemoryConfig_Click(object sender, EventArgs e)
        {
            OpenConfiguration(Configuration.ConfigurationTabs.Memory, true);
        }

        private void MAmbientesConfig_Click(object sender, EventArgs e)
        {
            OpenConfiguration(Configuration.ConfigurationTabs.GCBA, true);
        }

        private void OpenConfiguration(Configuration.ConfigurationTabs tab, bool exclusive = false)
        {
            if (fConfiguration == null)
            {
                fConfiguration = new Configuration();
                fConfiguration.SetTab(tab, exclusive);
                fConfiguration.ShowDialog();

                if (fConfiguration.Result.ReValidUser)
                    ReValidUser();

                if (fConfiguration.Result.ReLoadMemoryMenu)
                    this.MenuBuilder.ReloadMemoryMenu();

                if (fConfiguration.Result.ReLoadAmbientesMenu)
                    this.MenuBuilder.ReloadAmbientesMenu();

                if (fConfiguration.Result.ReLoadAlarmaMenu)
                    this.MenuBuilder.ReloadAlarmasMenu();

                if (fConfiguration.Result.ReLoadWorkMenu)
                    this.MenuBuilder.ReloadWorkMenu();

                if (fConfiguration.Result.ReLoadLinksMenu)
                    this.MenuBuilder.ReloadLinkMenu();

                fConfiguration = null;
            }
        }

        private void MStartWorkSearch_Click(object sender, EventArgs e)
        {
            Utils.Work.FindIssue();
        }
    }
}
