using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;


namespace YerbaSoft.Office.Excel
{
    public class Libro : IDisposable
    {
        private Workbook iWorkbook;
        public List<Hoja> Hojas { get; } = new List<Hoja>();

        internal Libro(Workbook workbook)
        {
            this.iWorkbook = workbook;

            this.Hojas.AddRange(this.iWorkbook.Sheets.OfType<Worksheet>().Select(p => new Hoja(p)));
        }

        public Hoja CreateNewHoja(string name)
        {
            var ultimahoja = this.iWorkbook.Sheets.OfType<Worksheet>().LastOrDefault();
            var iWorksheet = this.iWorkbook.Sheets.Add(ultimahoja ?? Type.Missing, Type.Missing, Type.Missing, XlSheetType.xlWorksheet);
            var oHoja = new Hoja(iWorksheet);
            oHoja.Name = name;
            this.Hojas.Add(oHoja);
            return oHoja;
        }

        public void DeleteHoja(Hoja hoja)
        {
            hoja.Delete();
            this.Hojas.Remove(hoja);
        }

        /// <summary>
        /// Guarda el archivo
        /// </summary>
        /// <param name="fileName"></param>
        public void Save(string fileName)
        {
            iWorkbook.SaveAs(fileName, XlFileFormat.xlWorkbookDefault, null, null, false, false, XlSaveAsAccessMode.xlShared, false, false, null, null, null);
        }

        public void Close()
        {
            this.iWorkbook.Close(Type.Missing, Type.Missing, Type.Missing);
        }

        public void Dispose()
        {
            foreach (var hoja in this.Hojas)
                hoja.Dispose();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(this.iWorkbook);
            this.iWorkbook = null;
        }
    }
}
