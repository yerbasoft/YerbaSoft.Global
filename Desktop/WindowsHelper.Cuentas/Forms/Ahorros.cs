using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsHelper.Cuentas.Forms
{
    public partial class Ahorros : Form
    {
        private DTO.Ahorro Ahorro { get; set; }

        public Ahorros()
        {
            InitializeComponent();
        }

        private void Ahorros_Load(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            ahorroBindingSource.DataSource = DAL.Session.Ahorros.Find().OrderByDescending(p => p.CreaFecha).ToArray();

            cmbTipo.Items.Clear();
            cmbTipo.Items.AddRange(Enum.GetNames(typeof(DTO.Ahorro.TipoAhorros)));

            this.Ahorro = new DTO.Ahorro(DTO.Ahorro.TipoAhorros.PlazoFijo);
            RefreshAhorroData();
        }

        private void RefreshAhorroData()
        {
            cmbTipo.SelectedItem = this.Ahorro.TipoAhorro.ToString();
            txtEntidad.Text = this.Ahorro.Entidad;
            dtFechaDesde.Value = this.Ahorro.FechaDesde;
            if (dtFechaHasta.Checked = this.Ahorro.FechaHasta.HasValue)
                dtFechaHasta.Value = this.Ahorro.FechaHasta.Value;
            txtObs.Text = this.Ahorro.Observaciones;
            txtMonto.Text = this.Ahorro.Monto.ToString();
            txtTaza.Text = this.Ahorro.TazaAnual.ToString();

            bDel.Enabled = this.Ahorro.Id != Guid.Empty;
        }

        private void BNew_Click(object sender, EventArgs e)
        {
            this.Ahorro = new DTO.Ahorro(DTO.Ahorro.TipoAhorros.PlazoFijo);
            RefreshAhorroData();
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            if (Grid.SelectedRows.Count > 0)
            {
                this.Ahorro = (DTO.Ahorro)Grid.SelectedRows[0].DataBoundItem;
                RefreshAhorroData();
            }
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            decimal monto = 0;
            decimal taza = 0;
            if (!ValidMonto(txtMonto, lMonto) || !decimal.TryParse(txtMonto.Text, System.Globalization.NumberStyles.Currency, System.Globalization.CultureInfo.InvariantCulture, out monto))
            {
                MessageBox.Show("Debe ingresar un monto válido");
                return;
            }

            if (!string.IsNullOrEmpty(txtTaza.Text))
            {
                if (!ValidMonto(txtTaza, lTaza) || !decimal.TryParse(txtTaza.Text, System.Globalization.NumberStyles.Currency, System.Globalization.CultureInfo.InvariantCulture, out taza))
                {
                    MessageBox.Show("Debe ingresar una taza válida");
                    return;
                }
            }

            this.Ahorro.TipoAhorro = (DTO.Ahorro.TipoAhorros)Enum.Parse(typeof(DTO.Ahorro.TipoAhorros), (string)cmbTipo.SelectedItem);
            this.Ahorro.Entidad = txtEntidad.Text;
            this.Ahorro.Monto = monto;
            this.Ahorro.TazaAnual = string.IsNullOrEmpty(txtTaza.Text) ? (decimal?)null : taza;
            this.Ahorro.FechaDesde = dtFechaDesde.Value;
            this.Ahorro.FechaHasta = dtFechaHasta.Checked ? dtFechaHasta.Value : (DateTime?)null;
            this.Ahorro.Observaciones = txtObs.Text;
            if (this.Ahorro.Id == Guid.Empty)
                this.Ahorro.Id = Guid.NewGuid();

            DAL.Session.Ahorros.UpsertEntity(this.Ahorro);
            DAL.Session.Ahorros.Commit();

            ResetForm();
        }

        private bool ValidMonto(TextBox textbox, Label label)
        {
            var regex = new Regex("^[0-9]{1,7}(.[0-9]{1,2}|)$");
            var valid = regex.IsMatch(textbox.Text);

            textbox.ForeColor = valid ? Color.Black : Color.Red;
            label.ForeColor = valid ? Color.Black : Color.Red;

            return valid;
        }

        private void TxtTaza_TextChanged(object sender, EventArgs e)
        {
            ValidMonto(txtTaza, lTaza);
        }

        private void TxtMonto_TextChanged(object sender, EventArgs e)
        {
            ValidMonto(txtMonto, lMonto);
        }
    }
}
