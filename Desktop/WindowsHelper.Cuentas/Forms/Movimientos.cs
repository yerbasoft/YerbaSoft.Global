using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsHelper.Cuentas.Forms
{
    public partial class Movimientos : Form
    {
        private DTO.DataSource.MovimientoDataSource MovimientoSelected;
        private Bitmap ImagenTaked { get; set; }

        public Movimientos()
        {
            InitializeComponent();
        }

        private void Movimientos_Load(object sender, EventArgs e)
        {
            ReloadData();
        }

        public void ReloadData()
        {
            var conceptos = DAL.Session.Conceptos.Find().OrderBy(p => !p.EsCredito).ThenBy(p => p.Name).ToArray();
            cbConcepto.Items.AddRange(conceptos);
            var datasource = DAL.Session.Movimientos.Find().Select(p => new DTO.DataSource.MovimientoDataSource(p, conceptos.SingleOrDefault(c => c.Id == p.IdConcepto))).OrderByDescending(p => p.CreaFecha);

            movimientoDataSourceBindingSource.DataSource = datasource;

            LoadInfo(this.MovimientoSelected = datasource.First());
        }

        private void LoadInfo(DTO.DataSource.MovimientoDataSource mov)
        {
            dtFecha.Value = mov.Fecha;
            cbConcepto.SelectedItem = mov.Concepto;
            txtMonto.Text = mov.Monto.ToString(CultureInfo.InvariantCulture);
            txtObs.Text = mov.Observaciones;
            txtRef.Text = mov.FileRef;
        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            if (Grid.SelectedRows.Count > 0)
                LoadInfo(this.MovimientoSelected = (DTO.DataSource.MovimientoDataSource)Grid.SelectedRows[0].DataBoundItem);
        }


        private bool ValidMonto(TextBox textbox, Label label)
        {
            var regex = new Regex("^[0-9]{1,7}(.[0-9]{1,2}|)$");
            var valid = regex.IsMatch(textbox.Text);

            textbox.ForeColor = valid ? Color.Black : Color.Red;
            label.ForeColor = valid ? Color.Black : Color.Red;

            return valid;
        }

        private void TxtMonto_TextChanged(object sender, EventArgs e)
        {
            ValidMonto(txtMonto, lMonto);
        }

        private void BDelete_Click(object sender, EventArgs e)
        {
            DAL.Session.Movimientos.DeleteEntity(this.MovimientoSelected.Movimiento);
            DAL.Session.Movimientos.Commit();

            ReloadData();
        }

        private void BOk_Click(object sender, EventArgs e)
        {
            if (!ValidMonto(txtMonto, lMonto) || !decimal.TryParse(txtMonto.Text, NumberStyles.Currency, CultureInfo.InvariantCulture, out decimal monto))
                return;

            var concepto = (DTO.Concepto)cbConcepto.SelectedItem;
            this.MovimientoSelected.Movimiento.Fecha = dtFecha.Value;
            this.MovimientoSelected.Movimiento.IdConcepto = concepto.Id;
            this.MovimientoSelected.Movimiento.Monto = monto;
            this.MovimientoSelected.Movimiento.Observaciones = txtObs.Text;

            if (txtRef.Text == "ScreenShot")
            {
                var fileref = "";
                var saved = false;
                var i = 0;
                while (!saved)
                {
                    i++;
                    fileref = System.IO.Path.Combine(@"Z:\Mios\Banco\Movimientos", $"{DateTime.Now:yyyyMMdd} {concepto.Name}{(i > 1 ? $" ({i})" : "")}.png");

                    if (!System.IO.File.Exists(fileref))
                    {
                        ImagenTaked.Save(fileref, System.Drawing.Imaging.ImageFormat.Png);
                        saved = true;
                    }
                }
                this.MovimientoSelected.Movimiento.FileRef = fileref;
            }

            DAL.Session.Movimientos.UpsertEntity(this.MovimientoSelected.Movimiento);
            DAL.Session.Movimientos.Commit();

            ReloadData();
        }

        private void BFindFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                txtRef.Text = openFileDialog1.FileName;
        }

        private void BScreenShot_Click(object sender, EventArgs e)
        {
            var capture = new CaptureScreen();
            this.Hide();
            capture.ShowDialog(this);

            if (capture.Output != null)
                ImagenTaked = capture.Output;

            if (ImagenTaked != null)
                txtRef.Text = "ScreenShot";

            this.Show();
            Application.DoEvents();
        }

        private void BRemoveRef_Click(object sender, EventArgs e)
        {
            txtRef.Text = "";
        }

        private void BOpenRef_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRef.Text) || txtRef.Text == "ScreenShot")
                return;

            var pi = new System.Diagnostics.ProcessStartInfo(txtRef.Text)
            {
                WorkingDirectory = System.IO.Path.GetDirectoryName(txtRef.Text),
                Arguments = this.txtRef.Text,
                UseShellExecute = true,
                Verb = "OPEN"
            };
            System.Diagnostics.Process.Start(pi);
        }
    }
}
