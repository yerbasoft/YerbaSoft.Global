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
    public partial class SelectMonitor : Form
    {
        public Screen Result;

        private List<PictureBox> Wins { get; set; }
        private Screen Selected { get; set; }

        public SelectMonitor(Screen selected = null)
        {
            InitializeComponent();
            this.Icon = Resources.window;

            this.Result = selected;
            this.Selected = selected ?? Screen.PrimaryScreen;

            this.Resize += (sender, e) => { ReDraw(); };

            ReDraw();
        }

        private void ReDraw()
        {
            if (this.Wins == null)
            {
                this.Wins = new List<PictureBox>();
                foreach (var screen in Screen.AllScreens)
                {
                    var pic = new PictureBox()
                    {
                        Image = this.Selected.DeviceName == screen.DeviceName ? Resources.win_sel : Resources.win,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Tag = screen
                    };
                    pic.Click += (sender, e) =>
                    {
                        this.Selected = (Screen)((Control)sender).Tag;
                        foreach (var p in Wins)
                            p.Image = ((Screen)p.Tag).DeviceName == this.Selected.DeviceName ? Resources.win_sel : Resources.win;
                    };

                    Wins.Add(pic);
                    Canvas.Controls.Add(pic);
                }
            }

            var screens = Wins.Select(p => (Screen)p.Tag).ToArray();

            var minTop = screens.Select(p => p.Bounds.Top).Min();
            var maxBot = screens.Select(p => p.Bounds.Bottom).Max();
            var minLeft = screens.Select(p => p.Bounds.Left).Min();
            var maxRight = screens.Select(p => p.Bounds.Right).Max();

            var hRate = 1d * (Canvas.Width - 20) / (maxRight - minLeft);
            var vRate = 1d * (Canvas.Height - 20) / (maxBot - minTop);

            var rate = Math.Min(hRate, vRate);

            var totalW = (maxRight - minLeft) * rate;
            var totalH = (maxBot - minTop) * rate;

            var offsetX = -(minLeft * rate) + ((Canvas.Width - totalW) / 2);
            var offsetY = -(minTop * rate) + ((Canvas.Height - totalH) / 2);

            foreach (var pic in Wins)
            {
                var screen = (Screen)pic.Tag;
                var x = Convert.ToInt32(offsetX + (screen.Bounds.Left * rate));
                var y = Convert.ToInt32(offsetY + (screen.Bounds.Top * rate));

                var w = Convert.ToInt32(screen.Bounds.Width * rate);
                var h = Convert.ToInt32(screen.Bounds.Height * rate);
                pic.Location = new Point(x, y);
                pic.Size = new Size(w, h);
            }

        }

        private void BOk_Click(object sender, EventArgs e)
        {
            this.Result = this.Selected;
            this.Close();
        }

        private void BUsePrincipal_Click(object sender, EventArgs e)
        {
            this.Result = null;
            this.Close();
        }
    }
}
