using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YerbaSoft.Desktop.PW.Properties;

namespace YerbaSoft.Desktop.PW.Forms
{
    public partial class PartyForm : Form
    {
        public BLL.PWParty Party { get; set; }

        // Draw / Controls
        private Point WinMovePosition = Point.Empty;
        private bool WinMoveMover = false;

        public PartyForm() { }
        public PartyForm(BLL.PWParty party)
        {
            InitializeComponent();
            this.Party = party;

            this.Paint += (sender, e) => DoDraw(e.Graphics);
            
            // Windows Move
            this.MouseDown += (sender, e) => { WinMovePosition = new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y); WinMoveMover = true; };
            this.MouseMove += (sender, e) => { if (WinMoveMover) this.Location = new Point(Convert.ToInt32(Math.Round((Cursor.Position.X - WinMovePosition.X) / 20.0) * 20), Convert.ToInt32(Math.Round((Cursor.Position.Y - WinMovePosition.Y) / 20.0) * 20)); };
            this.MouseUp += (sender, e) => { WinMoveMover = false; };
        }

        public void DoDraw(Graphics g)
        {
            try
            {
                g = g ?? this.CreateGraphics();

                g.FillRectangle(Brushes.Black, new Rectangle(12, 16, 14, 14));
                g.DrawImage(Resources.cd_1.ToBitmap(), new Rectangle(1, 5, 36, 36));
            }
            catch { }
        }
    }
}
