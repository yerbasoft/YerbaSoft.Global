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
    public partial class Add : Form
    {
        private DTO.Concepto ConceptoSelected { get; set; }
        private Bitmap ImagenTaked { get; set; }

        public Add()
        {
            InitializeComponent();
        }

        private void Add_Load(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void CmbCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ConceptoSelected = (DTO.Concepto)cmbCodigo.SelectedItem;
            lConceptoObs.Text = this.ConceptoSelected.Observaciones;
        }

        private void BScreenShot_Click(object sender, EventArgs e)
        {
            var capture = new CaptureScreen();
            this.Hide();
            capture.ShowDialog(this);

            if (capture.Output != null)
                ImagenTaked = capture.Output;

            if (ImagenTaked != null)
                txtFile.Text = "ScreenShot";
            
            this.Show();
            Application.DoEvents();
        }

        private void ResetForm()
        {
            dtFecha.Value = DateTime.Now;

            cmbCodigo.Items.Clear();
            cmbCodigo.Items.AddRange(DAL.Session.Conceptos.Find(p => !p.BajaFecha.HasValue).OrderBy(p => !p.EsCredito).ThenBy(p => p.Name).ToArray());
            ConceptoSelected = null;
            lConceptoObs.Text = "";

            txtMonto.Text = "";

            txtFile.Text = "";
            ImagenTaked = null;

            txtObs.Text = "";
        }

        private void TxtMonto_TextChanged(object sender, EventArgs e)
        {
            ValidMonto();
        }

        private void TxtMonto_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !ValidMonto();
        }

        private bool ValidMonto()
        {
            var regex = new Regex("^[0-9]{1,7}(.[0-9]{1,2}|)$");
            var valid = regex.IsMatch(txtMonto.Text);

            txtMonto.ForeColor = valid ? Color.Black : Color.Red;
            lMonto.ForeColor = valid ? Color.Black : Color.Red;

            return valid;
        }

        private void BFindFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                txtFile.Text = openFileDialog1.FileName;
        }

        private void BAddPlus_Click(object sender, EventArgs e)
        {
            var mov = GetMovimiento();
            if (mov == null)
                return;

            SaveMovimiento(mov);
            ResetForm();
        }

        private void BAddAndClose_Click(object sender, EventArgs e)
        {
            var mov = GetMovimiento();
            if (mov == null)
                return;

            SaveMovimiento(mov);
            this.Close();
        }

        private DTO.Movimiento GetMovimiento()
        {
            if (ConceptoSelected == null)
            {
                MessageBox.Show("Debe seleccionar un Concepto");
                return null;
            }

            decimal monto;
            if (!ValidMonto() || !decimal.TryParse(txtMonto.Text, System.Globalization.NumberStyles.Currency, System.Globalization.CultureInfo.InvariantCulture, out monto))
            {
                MessageBox.Show("Ingrese un monto válido");
                return null;
            }

            var fileref = txtFile.Text;
            if (ImagenTaked != null)
            {
                var saved = false;
                var i = 0;
                while (!saved)
                {
                    i++;
                    fileref = System.IO.Path.Combine(@"Z:\Mios\Banco\Movimientos", $"{DateTime.Now:yyyyMMdd} {ConceptoSelected.Name}{(i > 1 ? $" ({i})" : "")}.png");

                    if (!System.IO.File.Exists(fileref))
                    {
                        ImagenTaked.Save(fileref, System.Drawing.Imaging.ImageFormat.Png);
                        saved = true;
                    }
                }
            }

            return new DTO.Movimiento()
            {
                Id = Guid.NewGuid(),
                CreaFecha = DateTime.Now,
                Fecha = dtFecha.Value,
                IdConcepto = ConceptoSelected.Id,
                Monto = monto,
                FileRef = fileref,
                Observaciones = txtObs.Text
            };
        }

        private void SaveMovimiento(DTO.Movimiento mov)
        {
            DAL.Session.Movimientos.UpsertEntity(mov);
            DAL.Session.Movimientos.Commit();
        }
    }
}
