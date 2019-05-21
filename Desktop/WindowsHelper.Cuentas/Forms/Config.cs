using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsHelper.Cuentas.Forms
{
    public partial class Config : Form
    {
        private DTO.Concepto Editting;

        public Config()
        {
            InitializeComponent();
        }

        private void Config_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            if (Grid.SelectedRows.Count > 0)
                RefreshEditPanel((DTO.Concepto)Grid.SelectedRows[0].DataBoundItem);
        }

        private void RefreshData()
        {
            var conceptos = DAL.Session.Conceptos.Find(p => cbIncluyeEliminados.Checked || !p.BajaFecha.HasValue);
            conceptoBindingSource.DataSource = conceptos.OrderBy(p => !p.EsCredito).ThenBy(p => p.Name);

            RefreshEditPanel(new DTO.Concepto());
        }

        private void RefreshEditPanel(DTO.Concepto concepto)
        {
            this.Editting = concepto;
            txtName.Text = this.Editting.Name;
            txtObservaciones.Text = this.Editting.Observaciones;
            cbEsCredito.Checked = this.Editting.EsCredito;
            bOk.Text = this.Editting.Id == Guid.Empty ? "Agregar" : "Guardar";
            bOk.Enabled = false;

            bDel.Enabled = this.Editting.Id != Guid.Empty && !this.Editting.BajaFecha.HasValue;
        }

        private void BOk_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (DAL.Session.Conceptos.Any(p => p.Name == txtName.Text && p.Id != this.Editting.Id))
            {
                MessageBox.Show("Ya existe un Concepto con el mismo Nombre");
                return;
            }

            // Se arma el objeto
            if (this.Editting.Id == Guid.Empty)
            {
                this.Editting.Id = Guid.NewGuid();
                this.Editting.CreaFecha = DateTime.Now;
            }
            this.Editting.Name = txtName.Text;
            this.Editting.Observaciones = txtObservaciones.Text;
            this.Editting.EsCredito = cbEsCredito.Checked;
            
            DAL.Session.Conceptos.UpsertEntity(this.Editting);
            DAL.Session.Conceptos.Commit();

            RefreshData();
        }

        private void BNew_Click(object sender, EventArgs e)
        {
            RefreshEditPanel(new DTO.Concepto());
        }

        private void BDel_Click(object sender, EventArgs e)
        {
            this.Editting.BajaFecha = DateTime.Now;
            DAL.Session.Conceptos.UpsertEntity(this.Editting);
            DAL.Session.Conceptos.Commit();

            RefreshData();
        }

        private void OnDataChanged(object sender, EventArgs e)
        {
            bOk.Enabled = true;
        }

        private void CbIncluyeEliminados_CheckedChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
