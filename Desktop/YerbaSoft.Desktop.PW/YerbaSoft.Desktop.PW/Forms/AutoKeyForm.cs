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
    public partial class AutoKeyForm : PopUpForm
    {
        protected override string Title => "Auto Key";

        private BLL.PWClient Client;

        private Helper.InputValues Values = new Helper.InputValues();

        public AutoKeyForm() : base() { }
        public AutoKeyForm(ClientForm parent, BLL.PWClient client) : base(parent, new PopUpCoords(client.dbConfig.AutoKey.WinPinned, client.dbConfig.AutoKey.WinShowAttachParent, client.dbConfig.AutoKey.ScreenX, client.dbConfig.AutoKey.ScreenY))
        {
            InitializeComponent();
            this.Client = client;

            this.Client.Auto.OnAutoKeyStatusChange += (sender, e) => DoDrawStatus();

            DoDrawControls();
        }

        private void DoDrawStatus()
        {
            //this.Client.dbConfig.AutoKey.Keys
            foreach (var ctrl in this.Controls.OfType<PictureBox>().Where(p => p.Tag != null).ToList())
            {
                var cfg = (DAL.KeyValueConfig)ctrl.Tag;
                var running = this.Client.Auto.IsAutoKeyRunning(cfg.Key.GetKey());

                ctrl.Image = running ? Resources.media_play_green.ToBitmap() : Resources.delete.ToBitmap();
            }
        }

        protected void DoDrawControls()
        {
            // elimino los labels preexistentes
            foreach (var ctrl in this.Controls.OfType<Label>().Where(p => p.Tag != null))
                this.Controls.Remove(ctrl);
            foreach (var ctrl in this.Controls.OfType<PictureBox>().Where(p => p.Tag != null))
                this.Controls.Remove(ctrl);

            // agrego los labels
            var y = 46;
            Label lbl;
            PictureBox pic;
            foreach (var key in this.Client.dbConfig.AutoKey.Keys)
            {
                this.Controls.Add(pic = new PictureBox() { Image = Resources.delete.ToBitmap(), SizeMode = PictureBoxSizeMode.Zoom, Tag = key, Left = 9, Top = y, Height = 14, Width = 14 });
                pic.Click += OnDeleteKey;
                this.Controls.Add(lbl = new Label() { Text = "Key: " + Values.GetAllKeyText(key.Key), Tag = key, Left = 30, Top = y, Height = 18, AutoSize = true });
                lbl.MouseWheel += OnMouseWheel;
                lbl.Click += OnClick;
                this.Controls.Add(lbl = new Label() { Text = "Time: " + Values.GetTimesText(key.Time), Tag = key, Left = 110, Top = y, Height = 18, AutoSize = true });
                lbl.MouseWheel += OnMouseWheel;
                lbl.Click += OnClick;
                y += 20;
            }

            this.Controls.Add(lbl = new Label() { Text = "Seleccione...", Tag = new DAL.KeyValueConfig(), Left = 9, Top = y });
            lbl.MouseWheel += OnMouseWheel;
            lbl.Click += OnClick;
            y += 20;

            this.Height = y;

            DoDrawStatus();
        }
        
        private void OnClick(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            var cfg = (DAL.KeyValueConfig)lbl.Tag;
            if (lbl.Text == "Seleccione...")
            {
                this.Controls.Remove(lbl);
                var exclude = this.Client.dbConfig.AutoKey.Keys.Select(p => p.Key).ToList();
                this.Client.dbConfig.AutoKey.Keys.Add(new DAL.KeyValueConfig() { Key = Values.GetAllKeyFirst(exclude), Time = Values.GetTimesFirst() });
                DoDrawControls();
            }
            else if (lbl.Text.StartsWith("Key") || lbl.Text.StartsWith("Time"))
            {
                // prendo / apago la tecla
                this.Client.Auto.SetAutoKey(cfg.Key.GetKey(), cfg.Time, !this.Client.Auto.IsAutoKeyRunning(cfg.Key.GetKey()));
            }
        }

        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
            var lbl = (Label)sender;
            var cfg = (DAL.KeyValueConfig)lbl.Tag;
            if (lbl.Text == "Seleccione...")
            {
                this.Controls.Remove(lbl);
                var exclude = this.Client.dbConfig.AutoKey.Keys.Select(p => p.Key).ToList();
                this.Client.dbConfig.AutoKey.Keys.Add(new DAL.KeyValueConfig() { Key = Values.GetAllKeyFirst(exclude), Time = Values.GetTimesFirst() });
                DoDrawControls();
            }
            else if (lbl.Text.StartsWith("Key"))
            {
                var exclude = this.Client.dbConfig.AutoKey.Keys.Where(p => p.Key != cfg.Key).Select(p => p.Key).ToList();
                cfg.Key = e.Delta > 0 ? Values.GetAllKeyPost(cfg.Key, false, exclude) : Values.GetAllKeyPrev(cfg.Key, false, exclude);
                this.Client.dbConfig.PendingChanges = true;
                lbl.Text = $"Key: {Values.GetAllKeyText(cfg.Key)}";
            }
            else if (lbl.Text.StartsWith("Time"))
            {
                cfg.Time = e.Delta > 0 ? Values.GetTimesPost(cfg.Time) : Values.GetTimesPrev(cfg.Time);
                this.Client.dbConfig.PendingChanges = true;
                lbl.Text = $"Time: {Values.GetTimesText(cfg.Time)}";
            }
        }

        private void OnDeleteKey(object sender, EventArgs e)
        {
            var pic = (PictureBox)sender;
            var cfg = (DAL.KeyValueConfig)pic.Tag;

            if (!this.Client.Auto.IsAutoKeyRunning(cfg.Key.GetKey()))
            {
                foreach (var ctrl in this.Controls.OfType<Label>().Where(p => p.Tag == cfg).ToArray())
                    this.Controls.Remove(ctrl);
                this.Controls.Remove(pic);

                this.Client.dbConfig.AutoKey.Keys.Remove(cfg);
                this.Client.dbConfig.PendingChanges = true;

                DoDrawControls();
            }
        }

        protected override void CoordsChanges(PopUpCoords coords)
        {
            if (this.Client != null)
            {
                this.Client.dbConfig.AutoKey.WinPinned = coords.IsPinned;
                this.Client.dbConfig.AutoKey.WinShowAttachParent = coords.IsAttach;
                this.Client.dbConfig.AutoKey.ScreenX = coords.X;
                this.Client.dbConfig.AutoKey.ScreenY = coords.Y;
                this.Client.dbConfig.PendingChanges = true;
            }
        }
    }
}
