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

namespace CSWork.Interface.Forms.Tools
{
    public partial class GenerarPasswordWeb : Form
    {
        public GenerarPasswordWeb()
        {
            InitializeComponent();
            this.Icon = Resources.key1;
        }

        private void BOk_Click(object sender, EventArgs e)
        {
            var text = SLM.Encryptor.EncryptPass(tUser.Text, tPass.Text);
            lResult.Text = text;
            Clipboard.SetText(text);
        }
    }
}
