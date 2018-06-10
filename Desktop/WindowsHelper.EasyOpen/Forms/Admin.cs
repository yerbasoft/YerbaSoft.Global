using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using YerbaSoft.DTO;

namespace WindowsHelper.EasyOpen.Forms
{
    public partial class Admin : Form
    {
        private EasyOpen EasyOpen { get; set; }
        private string ConfigFullFileName { get; set; }
        private bool Editing { get; set; }
        private bool Saving { get; set; }

        public Admin()
        {
            InitializeComponent();
        }

        public Admin(string configFullFileName, EasyOpen easyOpen) : base()
        {
            InitializeComponent();
            bDelete.BackgroundImage = WindowsHelper.Common.Properties.Resources.nav_delete.ToBitmap();
            ConfigFullFileName = configFullFileName;
            this.EasyOpen = easyOpen;
        }

        #region Events

        private void AdminLinks_Load(object sender, EventArgs e)
        {
            var data = new YerbaSoft.DTO.ConfigurationManager(ConfigFullFileName).GetMainElement<WindowsHelper.EasyOpen.Configuration.EasyOpenConfig>();

            lLinks.Items.Add(new Configuration.Exe() { Id = null, Name = "- NUEVO -" });
            lLinks.Items.AddRange(data.Items.ToArray());
            lLinks.SelectedIndex = 0;
        }

        private void lLinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Saving || lLinks.SelectedItem == lLinks.Tag) return;
            
            if (Editing && lLinks.SelectedItem != lLinks.Tag)
            {
                if (MessageBox.Show("Se perderán los cambios. Desea continuar?", null, MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    lLinks.SelectedItem = lLinks.Tag;
                    return;
                }
            }

            var l = (Configuration.Exe)(lLinks.Tag = lLinks.SelectedItem);
            txtName.Text = lLinks.SelectedIndex == 0 ? "" : l.Name;
            txtPath.Text = l.Path;
            txtIcono.Text = l.Icon;
            txtOpenWith.Text = l.OpenWith;
            txtParams.Text = l.Params;

            Editing = false;
            btnSave.Enabled = false;
            RefreshUpDow();
        }

        #endregion

        #region Navigation 

        private void bUp_Click(object sender, EventArgs e)
        {
            if (Editing)
            {
                MessageBox.Show("No se puede mover un elemento en edición");
                return;
            }

            var selected = (Configuration.Exe)lLinks.SelectedItem;
            var list = lLinks.Items.OfType<Configuration.Exe>().ToArray().Where(p => p != selected).ToList();

            list.Insert(lLinks.SelectedIndex - 1, selected);
            lLinks.Items.Clear();
            lLinks.Items.AddRange(list.ToArray());
            lLinks.SelectedItem = selected;

            RefreshUpDow();
            SaveToXml();
        }
        
        private void bDown_Click(object sender, EventArgs e)
        {
            if (Editing)
            {
                MessageBox.Show("No se puede mover un elemento en edición");
                return;
            }

            var selected = (Configuration.Exe)lLinks.SelectedItem;
            var list = lLinks.Items.OfType<Configuration.Exe>().ToArray().Where(p => p != selected).ToList();

            list.Insert(lLinks.SelectedIndex + 1, selected);
            lLinks.Items.Clear();
            lLinks.Items.AddRange(list.ToArray());
            lLinks.SelectedItem = selected;

            RefreshUpDow();
            SaveToXml();
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            Editing = false;

            var selected = (Configuration.Exe)lLinks.SelectedItem;
            var list = lLinks.Items.OfType<Configuration.Exe>().ToArray().Where(p => p != selected).ToList();
            lLinks.Items.Clear();
            lLinks.Items.AddRange(list.ToArray());
            lLinks.SelectedIndex = 0;

            RefreshUpDow();
            SaveToXml();
        }

        private void RefreshUpDow()
        {
            bUp.Enabled = lLinks.SelectedIndex > 1;
            bDown.Enabled = lLinks.SelectedIndex < lLinks.Items.Count - 1 && lLinks.SelectedIndex > 0;
            bDelete.Enabled = lLinks.SelectedIndex > 0;
            bUp.BackgroundImage = bUp.Enabled ? WindowsHelper.Common.Properties.Resources.nav_up_blue.ToBitmap() : WindowsHelper.Common.Properties.Resources.nav_up_red.ToBitmap();
            bDown.BackgroundImage = bDown.Enabled ? WindowsHelper.Common.Properties.Resources.nav_down_blue.ToBitmap() : WindowsHelper.Common.Properties.Resources.nav_down_red.ToBitmap();
        }

        #endregion

        #region Editing

        private void OnTextChanged(object sender, EventArgs e)
        {
            Editing = true;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Saving = true;
            var l = (Configuration.Exe)lLinks.SelectedItem;

            bool esNuevo = l.Id == null;
            if (esNuevo) l = new Configuration.Exe();

            l.Id = l.Id ?? Guid.NewGuid().ToString();
            l.Name = txtName.Text;
            l.Icon = txtIcono.Text;
            l.OpenWith = txtOpenWith.Text;
            l.Params = txtParams.Text;
            l.Path = txtPath.Text;

            if (esNuevo)
            {
                lLinks.Items.Add(l);
            }
            else
            {
                var index = lLinks.SelectedIndex;
                lLinks.Items[index] = l;
            }
            
            SaveToXml();

            Editing = false;
            btnSave.Enabled = false;
            Saving = false;
        }

        private bool SaveToXml()
        {
            try
            {
                var xml = new XmlDocument();
                xml.Load(ConfigFullFileName);

                var main = xml.DocumentElement;

                foreach (var n in ((XmlNode)main).SubNodes().ToArray())
                    main.RemoveChild(n);

                foreach (var l in lLinks.Items.Cast<Configuration.Exe>().Where(p => p.Id != null))
                    main.AppendChild(xml.CreateNode(XmlNodeType.Element, "Link", xml.NamespaceURI).SetProperties(l));

                xml.Save(ConfigFullFileName);

                EasyOpen.RefreshMenu();
                return true;
            }
            catch (Exception ex)
            {
                Global.Log(ex);
                MessageBox.Show("Ha ocurrido un error al intentar grabar los cambios", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return false;
            }
        }

        #endregion
    }
}
