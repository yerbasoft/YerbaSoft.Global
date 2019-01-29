using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsHelper.Customs.JIRA
{
    public partial class OpenUrl : Form
    {
        OpenUrlData Data;

        public OpenUrl(OpenUrlData data)
        {
            InitializeComponent();
            this.Data = data;
            VarTextChanged(null, null);

            var y = 0;
            foreach(var v in this.Data.Vars)
            {
                var lb = new Label() { AutoSize = true, Text = v.Text, Tag = v.Replace, Size = new Size(35, 13) };
                lb.Location = new Point(12, (y*50) + 18);
                this.Controls.Add(lb);

                var txt = new TextBox() { Tag = v.Replace, Size = new Size(300, 20) };
                txt.Location = new Point(70, (y * 50) + 18);
                txt.TextChanged += VarTextChanged;
                v.Control = txt;
                v.Control.TabIndex = y;
                this.Controls.Add(txt);

                y++;
                lbUrl.Top += 50;
                btOpen.Top += 50;
            }

            if (this.Data.Vars.Count > 0)
                this.Data.Vars[0].Control.Focus();

            this.Height = 91 + (this.Data.Vars.Count * 50);
        }

        private void VarTextChanged(object sender, EventArgs e)
        {
            var url = this.Data.Url;
            foreach(var v in this.Data.Vars)
                url = url.Replace(v.Replace, v.Control?.Text);

            this.lbUrl.Text = url;
        }

        private void OpenUrl_Load(object sender, EventArgs e)
        {

        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            var pi = new ProcessStartInfo(this.Data.ExplorerPath)
            {
                WorkingDirectory = System.IO.Path.GetDirectoryName(this.Data.ExplorerPath),
                Arguments = this.lbUrl.Text,
                UseShellExecute = true
            };
            Process.Start(pi);
            this.Close();
        }
    }

    public class OpenUrlData
    {
        public class VarStr
        {
            public string Text { get; set; }
            public string Replace { get; set; }
            internal TextBox Control { get; set; }
        }

        public string Url { get; set; }
        public string ExplorerPath { get; set; }
        public List<VarStr> Vars { get; set; } = new List<VarStr>();

        public OpenUrlData(string url, BLL.Explorers explorer)
        {
            this.Url = url;
            this.ExplorerPath = BLL.ExplorersManager.Get(explorer);
        }

        public OpenUrlData AddVar(string text, string replace = null)
        {
            this.Vars.Add(new VarStr() { Text = text, Replace = replace ?? ("{" + text + "}")});
            return this;
        }
    }
}
