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
    public partial class PopUpForm : Form
    {
        public struct PopUpCoords
        {
            public bool IsAttach;
            public bool IsPinned;
            public int X;
            public int Y;

            public PopUpCoords(bool isPinned, bool isAttach, int x, int y)
            {
                this.IsAttach = isAttach;
                this.IsPinned = isPinned;
                this.X = x;
                this.Y = y;
            }
        }

        private ClientForm ClientForm;
        private PopUpCoords Coords;

        // Draw / Controls
        private Point WinMovePosition = Point.Empty;
        private bool WinMoveMover = false;
        private bool WinMoveMoved = false;
        private bool Closeable = false;

        protected virtual string Title { get; }
        protected virtual void CoordsChanges(PopUpCoords coords) { }

        public PopUpForm() { }
        public PopUpForm(ClientForm parent, PopUpCoords initial)
        {
            InitializeComponent();
            this.lTitle.Text = this.Title;

            this.ClientForm = parent;
            this.Coords = initial;

            this.Deactivate += (sender, e) => this.SetShow(false);
            this.Activated += (sender, e) => { CalculatePosition(); ReDraw(); this.Closeable = true; };
            this.ClientForm.OnCustomMove += (sender, e) => CalculatePosition();

            // Windows Move
            this.MouseDown += (sender, e) =>
            {
                WinMovePosition = new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);
                WinMoveMover = true;
                WinMoveMoved = false;
            };
            this.MouseMove += (sender, e) => { if (WinMoveMover) { this.Location = new Point(Cursor.Position.X - WinMovePosition.X, Cursor.Position.Y - WinMovePosition.Y); WinMoveMoved = true; } };
            this.MouseUp += (sender, e) =>
            {
                WinMoveMover = false;
                if (WinMoveMoved)
                {
                    this.Coords.IsAttach = false;
                    this.Coords.X = this.Location.X;
                    this.Coords.Y = this.Location.Y;
                    CoordsChanges(this.Coords);
                    ReDraw();
                }
            };
        }

        public void SetShow(bool visible)
        {
            if (visible)
            {
                this.Closeable = false;
                this.Show();
                this.Activate();
            }
            else
            {
                if (!this.Coords.IsPinned && this.Closeable)
                    this.Hide();
            }
        }

        public void ReDraw()
        {
            pAttachParent.Visible = !this.Coords.IsAttach;
            pPinned.Image = this.Coords.IsPinned ? Resources.pin_blue.ToBitmap() : Resources.pin_grey.ToBitmap();
        }

        private void PAttachParent_Click(object sender, EventArgs e)
        {
            this.Coords.IsAttach = true;
            CoordsChanges(this.Coords);
            CalculatePosition();
            ReDraw();
        }

        private void PPinned_Click(object sender, EventArgs e)
        {
            this.Coords.IsPinned = !this.Coords.IsPinned;
            CoordsChanges(this.Coords);
            ReDraw();
        }

        private void CalculatePosition()
        {
            if (this.Coords.IsAttach)
            {
                var point = new Point(this.ClientForm.Location.X + 40, this.ClientForm.Location.Y);
                this.Location = point;

                if (point.X != this.Coords.X || point.Y != this.Coords.Y)
                {
                    this.Coords.X = point.X;
                    this.Coords.Y = point.Y;
                    CoordsChanges(this.Coords);
                }
            }
            else
            {
                this.Location = new Point(this.Coords.X, this.Coords.Y);
            }
        }
    }
}
