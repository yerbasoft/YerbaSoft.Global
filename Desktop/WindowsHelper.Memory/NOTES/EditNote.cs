using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsHelper.Memory.NOTES
{
    public partial class EditNote : Form
    {
        /// <summary>
        /// Indica si el control está bloqueado al usuario
        /// </summary>
        private bool ReadOnly { get { return bLock.Checked; } set { OnReadOnlyChange(value); } }

        private Notes Manager { get; set; }
        private NoteDTO Entity { get; set; }

        public EditNote(Notes manager, NoteDTO entity)
        {
            InitializeComponent();
            this.Manager = manager;
            this.Entity = entity;
            if (!Entity.Id.HasValue)
                this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void EditNote_Load(object sender, EventArgs e)
        {
            this.ReadOnly = Entity.Id.HasValue;
            if (Entity.Id.HasValue)
            {
                this.SetDesktopLocation(Entity.FormX, Entity.FormY);
                this.Width = Entity.FormWidth;
                this.Height = Entity.FormHeight;
                this.rtf.Rtf = Entity.Content;
                this.rtf.BackColor = Color.FromArgb(Entity.BackColor);
                this.bAutoOpen.Checked = Entity.AutoOpen;
                this.Text = Entity.Title;
            }

            cbFonts.Items.AddRange(System.Drawing.FontFamily.Families.Select(p => p.Name).Where(p => !string.IsNullOrWhiteSpace(p)).ToArray());
        }

        private void EditNote_SizeChanged(object sender, EventArgs e)
        {
            OnChange();
        }

        private void OnChange()
        {
            Entity.FormX = this.DesktopLocation.X;
            Entity.FormY = this.DesktopLocation.Y;
            Entity.FormWidth = this.Width;
            Entity.FormHeight = this.Height;
            Entity.Content = this.rtf.Rtf;
            Entity.BackColor = this.rtf.BackColor.ToArgb();

            Manager.Save(Entity);
        }

        #region Events

        private void bBold_Click(object sender, EventArgs e)
        {
            if (rtf.SelectionFont.Bold)
                rtf.SelectionFont = new Font(rtf.SelectionFont, (FontStyle)(rtf.SelectionFont.Style - FontStyle.Bold));
            else
                rtf.SelectionFont = new Font(rtf.SelectionFont, FontStyle.Bold);

            OnChange();
        }

        private void bItalic_Click(object sender, EventArgs e)
        {
            if (rtf.SelectionFont.Italic)
                rtf.SelectionFont = new Font(rtf.SelectionFont, (FontStyle)(rtf.SelectionFont.Style - FontStyle.Italic));
            else
                rtf.SelectionFont = new Font(rtf.SelectionFont, FontStyle.Italic);

            OnChange();
        }

        private void bUnderline_Click(object sender, EventArgs e)
        {
            if (rtf.SelectionFont.Underline)
                rtf.SelectionFont = new Font(rtf.SelectionFont, (FontStyle)(rtf.SelectionFont.Style - FontStyle.Underline));
            else
                rtf.SelectionFont = new Font(rtf.SelectionFont, FontStyle.Underline);

            OnChange();
        }

        private void bFontSizeUp_Click(object sender, EventArgs e)
        {
            rtf.SelectionFont = new Font(rtf.SelectionFont.FontFamily, rtf.SelectionFont.Size + 1, rtf.SelectionFont.Style);

            OnChange();
        }

        private void bFontSizeDown_Click(object sender, EventArgs e)
        {
            rtf.SelectionFont = new Font(rtf.SelectionFont.FontFamily, rtf.SelectionFont.Size - 1, rtf.SelectionFont.Style);

            OnChange();
        }

        private void bFontColor_Click(object sender, EventArgs e)
        {
            bFontColor.Checked = !bFontColor.Checked;
            pColors.Tag = "FontColor";
            pColors.Visible = bFontColor.Checked;
        }

        private void bBackColor_Click(object sender, EventArgs e)
        {
            bBackColor.Checked = !bBackColor.Checked;
            pColors.Tag = "BackColor";
            pColors.Visible = bBackColor.Checked;
        }

        private void cbFonts_Click(object sender, EventArgs e)
        {
            if (cbFonts.SelectedItem != null)
            {                
                rtf.SelectionFont = new Font((string)cbFonts.SelectedItem, rtf.SelectionFont.Size, rtf.SelectionFont.Style);

                OnChange();
            }
        }

        private void OnColor_Click(object sender, EventArgs e)
        {
            var sel = ((Control)sender).BackColor;
            var reference = ((Control)sender).Parent.Tag.ToString();
            switch (reference)
            {
                case "FontColor":
                    rtf.SelectionColor = sel;
                    bFontColor.Checked = false;
                    pColors.Hide();
                    break;
                case "BackColor":
                    rtf.BackColor = sel;
                    bBackColor.Checked = false;
                    pColors.Hide();
                    break;
            }
            OnChange();
        }

        private void rtf_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void EditNote_ClientSizeChanged(object sender, EventArgs e)
        {
            OnChange();
        }

        private void bLock_Click(object sender, EventArgs e)
        {
            this.ReadOnly = !this.ReadOnly;
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            Manager.Delete(Entity);
            this.Close();
        }

        private void bSetTitle_EnabledChanged(object sender, EventArgs e)
        {
            txtTitle.Hide();
        }

        private void bSetTitle_Click(object sender, EventArgs e)
        {
            txtTitle.Text = Entity.Title ?? "Nota Sin Título";
            txtTitle.Show();
            txtTitle.Focus();
        }

        private void txtTitle_Leave(object sender, EventArgs e)
        {
            txtTitle.Hide();
        }

        private void txtTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (Convert.ToInt32(e.KeyChar))
            {
                case (int)Keys.Enter:
                    Entity.Title = txtTitle.Text;
                    this.Text = Entity.Title;
                    txtTitle.Hide();
                    OnChange();
                    break;
                case (int)Keys.Escape:
                    txtTitle.Hide();
                    break;
            }
        }

        private void bAutoOpen_Click(object sender, EventArgs e)
        {
            bAutoOpen.Checked = !bAutoOpen.Checked;
            Entity.AutoOpen = bAutoOpen.Checked;
            OnChange();
        }

        #endregion

        private void OnReadOnlyChange(bool newstatus)
        {
            bLock.Checked = newstatus;
            rtf.ReadOnly = newstatus;
            if (newstatus)
                bLock.Image = Properties.Resources.unlock;
            else
                bLock.Image = Properties.Resources._lock;

            bSetTitle.Enabled = !newstatus;
            bBold.Enabled = !newstatus;
            bItalic.Enabled = !newstatus;
            bUnderline.Enabled = !newstatus;
            cbFonts.Enabled = !newstatus;
            bFontSizeUp.Enabled = !newstatus;
            bFontSizeDown.Enabled = !newstatus;
            bFontColor.Enabled = !newstatus;
        }

        private void rtf_TextChanged(object sender, EventArgs e)
        {
            OnChange();
        }
    }
}
