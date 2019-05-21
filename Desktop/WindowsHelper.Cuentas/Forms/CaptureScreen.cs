using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsHelper.Cuentas.Forms
{
    public partial class CaptureScreen : Form
    {
        public Bitmap Output { get; set; } = null;

        Point posicionVentana;
        bool mover = false;
        public CaptureScreen()
        {
            InitializeComponent();

            this.Opacity = .2;
            this.TransparencyKey = Color.Turquoise;
            this.ControlBox = false;
            this.Text = "";
        }

        private void CaptureScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C || e.KeyCode == Keys.Enter) CapturarPantalla();
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void CapturarPantalla()
        {
            this.Visible = false;
            Application.DoEvents();

            var bitmap = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppArgb);
            var rec = Screen.FromControl(this).Bounds;
            var grap = Graphics.FromImage(bitmap);
            grap.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, rec.Size);
            this.Output = bitmap;

            this.Close();
            //Clipboard.SetImage(bitmap);
        }

        private void CaptureScreen_MouseDown(object sender, MouseEventArgs e)
        {
            posicionVentana = new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);
            mover = true;
        }

        private void CaptureScreen_MouseUp(object sender, MouseEventArgs e)
        {
            mover = false;
        }

        private void CaptureScreen_MouseMove(object sender, MouseEventArgs e)
        {
            if (mover)
                this.Location = new Point(Cursor.Position.X - posicionVentana.X, Cursor.Position.Y - posicionVentana.Y);
        }
    }
}
