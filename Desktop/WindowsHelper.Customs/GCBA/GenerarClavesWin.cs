using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsHelper.Customs.GCBA
{
    public partial class GenerarClavesWin : Form
    {
        public GenerarClavesWin()
        {
            InitializeComponent();
        }

        private void bogenerar_Click(object sender, EventArgs e)
        {
            var text = SLM.Encryptor.EncryptPass(bologin.Text, bopass.Text);
            text = $"Login {bologin.Text} Pass {bopass.Text} Encripted {text}{Environment.NewLine}";
            bolog.Text += text;
        }

        private void buauth_Click(object sender, EventArgs e)
        {
            byte[] encodedBytes = ASCIIEncoding.ASCII.GetBytes(bulogin.Text + ":" + bupass.Text);
            var text = Convert.ToBase64String(encodedBytes);
            text = $"Login {bulogin.Text} Pass {bupass.Text} Encripted {text}{Environment.NewLine}";
            bulog.Text = bulog.Text + text;
        }
    }
}
