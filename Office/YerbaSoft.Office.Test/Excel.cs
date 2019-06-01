using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Office.Test
{
    public class Excel
    {

        public void BasicTest()
        {
            using (var excel = new YerbaSoft.Office.Excel.App())
            {
                var workbook = excel.CreateNewWorkbook();

                var libro = excel.Libros[0];
                var hoja = libro.Hojas[0];
                hoja.Name = "Nueva Hoja";

                var sMonthTitle = new Office.Excel.DTO.Styles() { BackColor = System.Drawing.Color.Gray, FontColor = System.Drawing.Color.White, FontBold = true, Borders = new Office.Excel.DTO.StyleBorders().SetGrid() };
                var sCredito = new Office.Excel.DTO.Styles() { BackColor = System.Drawing.Color.LightGreen, Borders = new Office.Excel.DTO.StyleBorders().SetGrid() };
                var sCreditoTotal = new Office.Excel.DTO.Styles() { BackColor = System.Drawing.Color.Green, Borders = new Office.Excel.DTO.StyleBorders().SetGrid() };
                var sDebito = new Office.Excel.DTO.Styles() { BackColor = System.Drawing.Color.LightYellow, Borders = new Office.Excel.DTO.StyleBorders().SetGrid() };
                var sDebitoTotal = new Office.Excel.DTO.Styles() { BackColor = System.Drawing.Color.Yellow, Borders = new Office.Excel.DTO.StyleBorders().SetGrid() };

                var info = new Office.Excel.DTO.DataInfo()
                    .AddRow(new Office.Excel.DTO.Row(1, sMonthTitle))
                    .AddRow(new Office.Excel.DTO.Row(2, sCredito))
                    .AddRow(new Office.Excel.DTO.Row(3, sCredito))
                    .AddRow(new Office.Excel.DTO.Row(4, sCredito))
                    .AddRow(new Office.Excel.DTO.Row(5, sCredito))
                    .AddRow(new Office.Excel.DTO.Row(6, sCreditoTotal))
                    .AddRow(new Office.Excel.DTO.Row(7, sDebito))
                    .AddRow(new Office.Excel.DTO.Row(8, sDebito))
                    .AddRow(new Office.Excel.DTO.Row(9, sDebito))
                    .AddRow(new Office.Excel.DTO.Row(10, sDebito))
                    .AddRow(new Office.Excel.DTO.Row(11, sDebito))
                    .AddRow(new Office.Excel.DTO.Row(12, sDebito))
                    .AddRow(new Office.Excel.DTO.Row(13, sDebitoTotal))

                    .AddCell(new Office.Excel.DTO.Cell("D1", "'feb-2018"))
                    .AddCell(new Office.Excel.DTO.Cell("E1", "'mar-2018"))
                    .AddCell(new Office.Excel.DTO.Cell("F1", "'abr-2018"));

                hoja.SetInfo(info);

                /*
                libro.Save(@"W:\test.xlsx");
                libro.Close();
                */

                excel.ShowProgram();
            }
        }

    }
}
