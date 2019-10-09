using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSWork.Interface.Forms
{
    public partial class Notification : Form
    {
        private static List<Notification> Notifications { get; set; } = new List<Notification>();

        public class NotificationAction
        {
            public Image Image { get; set; }
            public string Text { get; set; }
            public Event<NotificationAction> OnClick { get; set; }
            public object Tag { get; set; }

            public bool ClickCloseWindows { get; set; } = true;
        }

        public class NotificationType
        {
            public string Header { get; set; }
            public string Body { get; set; }
            public Image Image { get; set; }
            public bool ShowCloseButton { get; set; } = true;
            public int? TimerToClose { get; set; } = null;
            public Event<NotificationType> OnClose;

            public List<NotificationAction> Actions { get; set; } = new List<NotificationAction>();
        }

        private void CalculatePosition()
        {
            this.FormClosed += (sender, e) => { lock (Notifications) { Notifications.Remove((Notification)sender); } };
            
            // último abierto
            Notification last = null;
            lock (Notifications)
            {
                last = Notifications.OrderByDescending(p => p.Location.Y).FirstOrDefault();
            }

            int x;
            int y;
            if (last == null)
            {
                // primera notificación
                var screen = Screen.PrimaryScreen;
                x = screen.WorkingArea.Right - this.Width - 140;
                y = screen.WorkingArea.Top;
            }
            else
            {
                x = last.Left;
                y = last.Location.Y + last.Size.Height;
            }

            this.Location = new Point(x, y);

            lock (Notifications)
            {
                Notifications.Add(this);
            }
        }

        private NotificationType Info { get; set; }
        private Model.Utils Utils { get; set; }

        public Notification(NotificationType info, Model.Utils utils)
        {
            InitializeComponent();

            this.Utils = utils;
            this.Info = info;
            CalculatePosition();

            lHeader.Text = info.Header;
            lBody.Text = info.Body;
            iIcon.Image = info.Image;

            if (!info.ShowCloseButton)
            {
                iClose.Visible = false;
                lHeader.Width = this.Width - lHeader.Location.X - 12;
            }
            else
            {
                iClose.Click += (sender, e) => this.Close();
            }

            if ((info.TimerToClose ?? 0) > 0)
            {
                tAutoClose.Interval = info.TimerToClose.Value;
                tAutoClose.Tick += (sender, e) => this.Utils.Animation.AnimationOpacity(this, 0, (sender2, e2) => { this.Utils.Safe(this, () => { this.Close(); }); }, 0.04, 20);
                tAutoClose.Start();
            }

            BuildButtons(info.Actions);

            this.Activated += (sender, e) => this.Utils.Animation.AnimationOpacity(this, .95, null, 0.04, 40);
            this.FormClosed += (sender, e) => this.Info.OnClose?.Invoke(this.Info);
        }

        private void BuildButtons(List<NotificationAction> actions)
        {
            var count = actions.Count;
            if (count == 0)
            {
                this.Height = 122;
                return;
            }

            var index = 0;
            var widthBlock = (this.Width / count);

            Panel panel = null;
            foreach (var action in actions)
            {
                panel = new Panel() { Size = new Size(70, 60) };
                var image = new PictureBox() { Tag = action.Tag, Image = action.Image, SizeMode = PictureBoxSizeMode.Zoom, Size = new Size(36, 36) };
                var label = new Label() { Tag = action.Tag, Text = action.Text, ForeColor = Color.LightSkyBlue, AutoSize = false, TextAlign = ContentAlignment.MiddleCenter };

                panel.Controls.Add(image);
                panel.Controls.Add(label);

                image.Location = new Point((panel.Size.Width / 2) - (image.Size.Width / 2), 0);
                label.Location = new Point(0, image.Size.Height);
                label.Size = new Size(panel.Width, panel.Height - label.Location.Y);

                if (action.OnClick != null)
                {
                    image.Click += (sender, e) => { action.OnClick?.Invoke(action); if (action.ClickCloseWindows) { this.Close(); } };
                    label.Click += (sender, e) => { action.OnClick?.Invoke(action); if (action.ClickCloseWindows) { this.Close(); } };
                }

                this.Controls.Add(panel);

                var offset = (widthBlock * index);
                var x = (widthBlock / 2) - (panel.Size.Width / 2);
                panel.Location = new Point(offset + x, 120);

                index++;
            }

            this.Height = panel.Location.Y + panel.Size.Height + 12;
        }
    }
}
