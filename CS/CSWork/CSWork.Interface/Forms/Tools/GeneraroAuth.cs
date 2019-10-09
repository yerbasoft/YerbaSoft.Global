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
    public partial class GeneraroAuth : Form
    {
        public GeneraroAuth()
        {
            InitializeComponent();
            this.Icon = Resources.keys;
        }

        private void BOk_Click(object sender, EventArgs e)
        {
            byte[] encodedBytes = ASCIIEncoding.ASCII.GetBytes(tUser.Text + ":" + tPass.Text);
            var text = Convert.ToBase64String(encodedBytes);
            lResult.Text = text;
            Clipboard.SetText(text);
        }
    }
}
