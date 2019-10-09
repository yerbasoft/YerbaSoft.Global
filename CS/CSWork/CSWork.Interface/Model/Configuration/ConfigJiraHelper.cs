using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSWork.Interface.Model.Configuration
{
    public class ConfigJiraHelper : ConfigBase
    {
        private TextBox tJiraUser => GetControl<TextBox>("pJiraAutenticacion", "tJiraUser");
        private Button bJiraDisconnect => GetControl<Button>("pJiraAutenticacion", "bJiraDisconnect");
        private Button bJiraLogin => GetControl<Button>("pJiraAutenticacion", "bJiraLogin");
        
        public ConfigJiraHelper(Forms.Configuration form, Control container) : base(form, container)
        {
            bJiraDisconnect.Click += OnDisconnect_Click;
            bJiraLogin.Click += OnLogin_Click;

            ReLoad();
        }

        private void OnLogin_Click(object sender, EventArgs e)
        {
            new Forms.Login().ShowDialog();
            this.Form.Result.ReValidUser = true;
            ReLoad();
        }

        private void OnDisconnect_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ésta Acción desconectará al usuario actual y reiniciará el sistema. ¿Desea continuar?", "Desconectar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Config.Global.Jira.User = null;
                Config.Global.Jira.Token = null;
                Config.SaveGlobal();
                this.Form.Result.ReValidUser = true;
                this.Form.Close();
            }
        }

        private void ReLoad()
        {
            tJiraUser.Text = BLL.Factory.Config.Global.Jira.User;
        }

    }
}
