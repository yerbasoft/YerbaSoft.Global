using CSWork.Interface.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSWork.Interface.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.Icon = Resources._lock;
            this.bObtener.BackgroundImage = Resources._lock.ToBitmap();
        }

        private void BObtener_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(BLL.Factory.GetTokenUrl) { UseShellExecute = true, Verb = "OPEN" });
        }

        private void TUser_Enter(object sender, EventArgs e)
        {
            tUser.SelectionStart = 0;
            tUser.SelectionLength = 0;
        }

        private void BOk_Click(object sender, EventArgs e)
        {
            var url = tUrl.Text;
            var user = tUser.Text;
            var token = tToken.Text;
            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(token))
            {
                MessageBox.Show("Debe completar todos los campos", "Log in Atlassian", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (BLL.Factory.Jira.SetJiraConnection(url, user, token))
            {
                MessageBox.Show("Log Exitoso!", "Log in Atlassian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al conectar con Atlassian", "Log in Atlassian", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
