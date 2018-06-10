using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsHelper.Visual
{
    public partial class Detector : Form
    {
        int SizeMin = 30;
        int SizeMax = 300;
        int SizeValue = 0;

        public Detector()
        {
            InitializeComponent();
            animation.Tag = 0;
            SizeValue = SizeMin;
        }

        private void Detector_MouseEnter(object sender, EventArgs e)
        {
            animation.Tag = 8;
            animation.Enabled = true;
        }

        private void Detector_MouseLeave(object sender, EventArgs e)
        {
            animation.Tag = -8;
            animation.Enabled = true;
        }

        private void Detector_Load(object sender, EventArgs e)
        {

        }

        private void Detector_Paint(object sender, PaintEventArgs e)
        {
            this.SuspendLayout();
            System.Drawing.Graphics formGraphics = this.CreateGraphics();

            if ((int)animation.Tag < 0)
                formGraphics.Clear(this.BackColor);

            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(255, 0, 0, 0));
            formGraphics.FillEllipse(myBrush, new Rectangle(this.SizeValue/-2, this.SizeValue/-2, this.SizeValue, this.SizeValue));
            myBrush.Dispose();

            System.Drawing.Pen myBrushB = new System.Drawing.Pen(System.Drawing.Color.DarkSalmon, 3);
            formGraphics.DrawEllipse(myBrushB, new Rectangle(this.SizeValue / -2, this.SizeValue / -2, this.SizeValue, this.SizeValue));
            myBrushB.Dispose();
            
            if (SizeValue == SizeMax)
            {
                var iPos = new Rectangle(30, 130, 34, 34);
                var dCircle = Convert.ToInt32(Math.Round(Math.Sqrt(iPos.Width * iPos.Width + iPos.Height * iPos.Height), 0));
                var iCircle = new Rectangle(iPos.X - (dCircle - iPos.Width) / 2, iPos.Y - (dCircle - iPos.Height) / 2, dCircle, dCircle);
                
                myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(255, 0, 0, 0));
                formGraphics.FillEllipse(myBrush, iCircle);
                myBrush.Dispose();

                formGraphics.DrawIcon(System.Drawing.Icon.FromHandle(Properties.Resources.GCBA.GetHicon()), iPos);

                var pen = new System.Drawing.Pen(System.Drawing.Color.DarkSalmon, 2);
                formGraphics.DrawEllipse(pen, iCircle);
                pen.Dispose();


                myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(255, 0, 0, 0));
                formGraphics.FillEllipse(myBrush, new Rectangle(75, 100, 32, 32));
                myBrush.Dispose();
                formGraphics.DrawIcon(System.Drawing.Icon.FromHandle(Properties.Resources.NACION.GetHicon()), new Rectangle(75, 100, 32, 32));
            }

            formGraphics.Dispose();

            this.Opacity = 10;
            this.ResumeLayout();
        }

        private void animation_Tick(object sender, EventArgs e)
        {
            var plus = Convert.ToInt32(animation.Tag);
            SizeValue = SizeValue + plus;

            ShowHideControls(false);

            if (SizeValue < SizeMin) { SizeValue = SizeMin; animation.Enabled = false; }
            if (SizeValue > SizeMax) { SizeValue = SizeMax; animation.Enabled = false; ShowHideControls(true); }

            this.RaisePaintEvent(null, null);
        }

        private void ShowHideControls(bool visible)
        {
            //pictureBox1.Visible = visible;
            //pictureBox2.Visible = visible;
        }

    }
}
