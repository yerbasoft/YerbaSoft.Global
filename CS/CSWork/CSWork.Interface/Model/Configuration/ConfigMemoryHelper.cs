using CSWork.DTO.GlobalConfigs;
using CSWork.Interface.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSWork.Interface.Model.Configuration
{
    public class ConfigMemoryHelper : ConfigBase
    {
        private DTO.GlobalConfigs.Memory SelectedItem;
        private bool PendingChanges;

        // Filters
        private ComboBox cbMemoryFilterGroup => GetControl<ComboBox>("pMemoryFilter", "cbMemoryFilterGroup");
        private TextBox tMemoryFilterKey => GetControl<TextBox>("pMemoryFilter", "tMemoryFilterKey");

        // Grid
        private DataGridView gMemoryData => GetControl<DataGridView>("pMemoryData", "gMemoryData");
        private BindingSource gMemoryDataSource => (BindingSource)gMemoryData.DataSource;

        // Edit
        private ComboBox cbMemoryEntityGroup => GetControl<ComboBox>("pMemoryEdit", "cbMemoryEntityGroup");
        private TextBox tMemoryEntityKey => GetControl<TextBox>("pMemoryEdit", "tMemoryEntityKey");
        private TextBox tMemoryEntityValue => GetControl<TextBox>("pMemoryEdit", "tMemoryEntityValue");
        private Button bMemoryAddNew => GetControl<Button>("pMemoryEdit", "bMemoryAddNew");
        private Button bMemoryDelete => GetControl<Button>("pMemoryEdit", "bMemoryDelete");
        private Button bMemorySaveChanges => GetControl<Button>("pMemoryEdit", "bMemorySaveChanges");

        public ConfigMemoryHelper(Forms.Configuration form, Control container) : base(form, container)
        {
            bMemoryAddNew.Image = Resources.add.ToBitmap().ZoomForControl(bMemoryAddNew);
            bMemoryDelete.Image = Resources.delete2.ToBitmap().ZoomForControl(bMemoryDelete);
            bMemorySaveChanges.Image = Resources.note_edit.ToBitmap().ZoomForControl(bMemorySaveChanges);

            // Filter - events
            cbMemoryFilterGroup.TextChanged += (sender, e) => ReLoadData(false);
            tMemoryFilterKey.TextChanged += (sender, e) => ReLoadData(false);

            // Grid - events
            gMemoryData.SelectionChanged += OnGridSelectedChanged;

            // Edit - events
            cbMemoryEntityGroup.TextChanged += (sender, e) => { this.PendingChanges = true; };
            tMemoryEntityKey.TextChanged += (sender, e) => { this.PendingChanges = true; };
            tMemoryEntityValue.TextChanged += (sender, e) => { this.PendingChanges = true; };

            bMemoryAddNew.Click += OnAddNew;
            bMemoryDelete.Click += OnDelete;
            bMemorySaveChanges.Click += (sender, e) => SaveChanges();            

            ReLoadData(true);
        }

        private void OnDelete(object sender, EventArgs e)
        {
            if (this.SelectedItem == null)
                return;

            if (Config.Global.Memory.Contains(this.SelectedItem))
                Config.Global.Memory.Remove(this.SelectedItem);

            Config.SaveGlobal();
            ReLoadData(true);
            this.Form.Result.ReLoadMemoryMenu = true;

            this.PendingChanges = false;
        }

        private void OnAddNew(object sender, EventArgs e)
        {
            SetEdit(new DTO.GlobalConfigs.Memory());
        }

        private void SetEdit(Memory entity)
        {
            if (PendingChanges)
            {
                // preguntar si se está seguro?
            }

            this.SelectedItem = entity;

            cbMemoryEntityGroup.Text = this.SelectedItem.Group;
            tMemoryEntityKey.Text = this.SelectedItem.Key;
            tMemoryEntityValue.Text = this.SelectedItem.Value;

            this.PendingChanges = false;
        }

        private void SaveChanges()
        {
            if (this.SelectedItem == null)
                return;

            if (string.IsNullOrEmpty(cbMemoryEntityGroup.Text))
            {
                MessageBox.Show("No se ha ingresado el nombre del Grupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(tMemoryEntityKey.Text))
            {
                MessageBox.Show("No se ha ingresado el nombre del elemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(tMemoryEntityValue.Text))
            {
                MessageBox.Show("No se ha ingresado un valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Config.Global.Memory.Contains(this.SelectedItem))
                Config.Global.Memory.Add(this.SelectedItem);

            this.SelectedItem.Group = cbMemoryEntityGroup.Text;
            this.SelectedItem.Key = tMemoryEntityKey.Text;
            this.SelectedItem.Value = tMemoryEntityValue.Text;

            Config.SaveGlobal();
            ReLoadData(true);
            this.Form.Result.ReLoadMemoryMenu = true;

            this.PendingChanges = false;
        }

        private void ReLoadData(bool refreshCmb)
        {
            gMemoryDataSource.DataSource = Config.Global.Memory.Where(p => p.Group.Contains(cbMemoryFilterGroup.Text) && p.Key.Contains(tMemoryFilterKey.Text)).OrderBy(p => p.Group).ThenBy(p => p.Key).ToArray();

            if (refreshCmb)
            {
                var groups = Config.Global.Memory.Select(p => p.Group).Distinct().ToArray();
                cbMemoryFilterGroup.Items.Clear();
                cbMemoryFilterGroup.Items.AddRange(groups);
                cbMemoryEntityGroup.Items.Clear();
                cbMemoryEntityGroup.Items.AddRange(groups);
            }
        }

        private void OnGridSelectedChanged(object sender, EventArgs e)
        {
            var selected = new DTO.GlobalConfigs.Memory();
            if (gMemoryData.SelectedRows.Count > 0)
                selected = (DTO.GlobalConfigs.Memory)gMemoryData.SelectedRows[0].DataBoundItem;

            SetEdit(selected);
        }

    }
}
