using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.Office.Excel;
using YerbaSoft.Office.Excel.DTO;

namespace WindowsHelper.Cuentas.BLL
{
    internal class ExcelHelper
    {
        public void BuildExcelAnual(DateTime desde)
        {
            desde = new DateTime(desde.Year, desde.Month, 1);
            using (var excel = new App())
            {
                var libro = excel.CreateNewWorkbook();
                var hoja = libro.Hojas[0];
                hoja.Name = "Anual";

                BuildAnual(hoja, desde);

                hoja.Select();

                excel.ShowProgram(true);
            }
        }

        public void BuildExcelMensual(DateTime month)
        {
            month = new DateTime(month.Year, month.Month, 1);
            using (var excel = new App())
            {
                var libro = excel.CreateNewWorkbook();
                var hoja = libro.Hojas[0];
                hoja.Name = $"{month:MMM-yyyy}";
                BuildMensual(hoja, month);

                var anterior = libro.CreateNewHoja($"{month.AddMonths(-1):MMM-yyyy}");
                BuildMensual(anterior, month.AddMonths(-1));

                hoja.Select();

                excel.ShowProgram(true);
            }
        }

        private void BuildAnual(Hoja hoja, DateTime iniDate)
        {
            var sMonthTitle = new Styles() { BackColor = Color.Gray, FontColor = Color.White, FontBold = true }.Update(s => s.Borders.SetGrid());
            var sCredito = new Styles() { BackColor = Color.FromArgb(200, 255, 200) }.Update(s => s.Borders.SetGrid());
            var sCreditoTotal = new Styles() { BackColor = Color.FromArgb(100, 255, 100), FontBold = true }.Update(s => s.Borders.SetGrid());
            var sDebito = new Styles() { BackColor = Color.FromArgb(255,230,230) }.Update(s => s.Borders.SetGrid());
            var sDebitoTotal = new Styles() { BackColor = Color.FromArgb(255, 200, 200), FontBold = true }.Update(s => s.Borders.SetGrid());


            var movimientos = DAL.Session.Movimientos.Find(p => p.Fecha >= iniDate);
            var listaIdConceptosUsados = movimientos.Select(p => p.IdConcepto).Distinct();

            var conceptos = DAL.Session.Conceptos.Find(p => listaIdConceptosUsados.Contains(p.Id)).OrderBy(p => p.Name);
            var conceptosCredito = conceptos.Where(p => p.EsCredito).Select(p => p.Id).ToArray();
            var conceptosDebito = conceptos.Where(p => !p.EsCredito).Select(p => p.Id).ToArray();

            var data = new DataInfo();

            // HEADER
            var rowNum = 1;
            data.AddRow(new Row(rowNum, sMonthTitle));
            var i = 0;
            var currentDate = iniDate;
            do
            {
                var colNum = 3 + i;
                currentDate = iniDate.AddMonths(i);
                var range = Ranges.GetRange(colNum, rowNum);
                data.AddColumn(new Column(colNum).Update(a => { a.Width = 11; a.Style.DataNumberFormat = "$ #,##0.00"; }));
                data.AddCell(new Cell(range, new Styles() { DataNumberFormat = "mmm-yyyy" }, $"'{currentDate:MMM-yyyy}"));
                i++;
            } while ( currentDate.Month != DateTime.Now.Month || currentDate.Year != DateTime.Now.Year );
            rowNum++;

            // Separador
            data.AddRow(new Row(rowNum).Update(a => a.Height = 3));
            rowNum++;

            // Lista Conceptos
            var conceptoRow = new Dictionary<Guid, int>();

            data.AddColumn(new Column(1) { Width = 30 });
            data.AddColumn(new Column(2) { Width = 0.3 });
            foreach (var idConcepto in conceptosCredito)
            {
                var coord = $"A{rowNum}";
                var oConcepto = conceptos.Single(p => p.Id == idConcepto);
                data.AddRow(new Row(rowNum, sCredito));
                data.AddCell(new Cell(coord, oConcepto.Name));
                conceptoRow.Add(oConcepto.Id, rowNum);
                rowNum++;
            }

            data.AddRow(new Row(rowNum, sCreditoTotal));
            var subTotalCreditoRow = rowNum;
            rowNum++; // subtotales

            // Separador
            data.AddRow(new Row(rowNum).Update(a => a.Height = 3));
            rowNum++;

            foreach (var idConcepto in conceptosDebito)
            {
                var coord = $"A{rowNum}";
                var oConcepto = conceptos.Single(p => p.Id == idConcepto);
                data.AddRow(new Row(rowNum, sDebito));
                data.AddCell(new Cell(coord, oConcepto.Name));
                conceptoRow.Add(oConcepto.Id, rowNum);
                rowNum++;
            }
            data.AddRow(new Row(rowNum, sDebitoTotal));
            var subTotalDebitoRow = rowNum;
            rowNum++;

            // Separador
            data.AddRow(new Row(rowNum).Update(a => a.Height = 3));

            // Fill DATA
            i = 0;
            currentDate = iniDate;
            do
            {
                currentDate = iniDate.AddMonths(i);
                var c = 3 + i;

                decimal totalCredito = 0;
                decimal totalDebito = 0;
                foreach (var concepto in conceptoRow)
                {
                    var monto = movimientos.Where(p => p.IdConcepto == concepto.Key && p.Fecha.Month == currentDate.Month && p.Fecha.Year == currentDate.Year).Sum(p => p.Monto);
                    if (monto != 0)
                    {
                        var coords = Ranges.GetRange(c, concepto.Value);
                        data.AddCell(new Cell(coords, Convert.ToDouble(monto)));
                    }

                    if (conceptos.Single(p => p.Id == concepto.Key).EsCredito)
                        totalCredito += monto;
                    else
                        totalDebito += monto;
                }

                data.AddCell(new Cell(Ranges.GetRange(c, subTotalCreditoRow), Convert.ToDouble(totalCredito)));
                data.AddCell(new Cell(Ranges.GetRange(c, subTotalDebitoRow), Convert.ToDouble(totalDebito)));
                i++;
            } while (currentDate.Month != DateTime.Now.Month || currentDate.Year != DateTime.Now.Year );

            hoja.SetInfo(data);
        }


        private void BuildMensual(Hoja hoja, DateTime desde, DateTime? hasta = null)
        {
            hasta = hasta ?? desde.AddMonths(1);
            var dbMovimientos = DAL.Session.Movimientos.Find(p => p.Fecha >= desde && p.Fecha < hasta).OrderBy(p => p.Fecha);
            var dbConceptos = DAL.Session.Conceptos.Find().ToArray();

            // Estilos a usar
            var colCurrency = new Styles() { DataNumberFormat = "$ #,##0.00;[Red]$ #,##0.00" };

            var rowHeaderStyle = new Styles() { FontBold = true, BackColor = Color.Gray };

            var cellStyle = new Styles() { }.Update(a => a.Borders.SetRectangle());

            // Datos
            var data = new DataInfo();

            data.AddColumn(new Column(1) { Width = 10 })
                .AddColumn(new Column(2) { Width = 45 })
                .AddColumn(new Column(3, colCurrency) { Width = 13 })
                .AddColumn(new Column(4, colCurrency) { Width = 13 })
                .AddColumn(new Column(5, colCurrency) { Width = 13 })
                .AddColumn(new Column(6) { Width = 85 })

                .AddRow(new Row(1, rowHeaderStyle))
                .AddCell(new Cell("A1", cellStyle, "Fecha"))
                .AddCell(new Cell("B1", cellStyle, "Concepto"))
                .AddCell(new Cell("C1", cellStyle, "Crédito"))
                .AddCell(new Cell("D1", cellStyle, "Débito"))
                .AddCell(new Cell("E1", cellStyle, "Saldo"))
                .AddCell(new Cell("F1", cellStyle, "Observaciones"));

            var row = 1;
            decimal saldo = 0;
            foreach(var dbMovimiento in dbMovimientos)
            {
                row++;
                var dbConcepto = dbConceptos.Single(p => p.Id == dbMovimiento.IdConcepto);

                saldo += (dbConcepto.EsCredito ? 1 : -1) * dbMovimiento.Monto;
                data.AddCell(new Cell($"A{row}", new Styles() { BackColor = Color.LightCyan }.Update(a => a.Borders.SetRectangle()), $"'{dbMovimiento.Fecha:dd/MM/yyyy}"))
                    .AddCell(new Cell($"B{row}", new Styles() { BackColor = Color.LightCyan }.Update(a => a.Borders.SetRectangle()), dbConcepto.Name))
                    .AddCell(new Cell($"C{row}", new Styles() { BackColor = Color.LightGreen }.Update(a => a.Borders.SetRectangle()), dbConcepto.EsCredito ? Convert.ToDouble(dbMovimiento.Monto) : (object)""))
                    .AddCell(new Cell($"D{row}", new Styles() { BackColor = Color.LightSalmon }.Update(a => a.Borders.SetRectangle()), !dbConcepto.EsCredito ? Convert.ToDouble(dbMovimiento.Monto) : (object)""))
                    .AddCell(new Cell($"E{row}", new Styles() { BackColor = Color.LightSkyBlue }.Update(a => a.Borders.SetRectangle()), saldo))
                    .AddCell(new Cell($"F{row}", new Styles() { BackColor = Color.LightCyan }.Update(a => a.Borders.SetRectangle()), dbMovimiento.Observaciones));
            }

            hoja.SetInfo(data);
        }

    }
}
