using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Office.Excel
{
    public class App : IDisposable
    {
        Application iApp;

        public List<Libro> Libros { get; } = new List<Libro>();

        public App()
        {
            this.iApp = new Application();
        }


        /// <summary>
        /// Abre un archivo Excel existente
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Libro OpenWorkbook(string fileName)
        {
            var iWorkbook = this.iApp.Workbooks.Open(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            var oWorkbook = new Libro(iWorkbook);
            this.Libros.Add(oWorkbook);
            return oWorkbook;
        }

        /// <summary>
        /// Crea un nuevo archivo Excel
        /// </summary>
        /// <returns></returns>
        public Libro CreateNewWorkbook()
        {
            var iWorkbook = this.iApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            var oWorkbook = new Libro(iWorkbook);
            this.Libros.Add(oWorkbook);
            return oWorkbook;
        }


        /// <summary>
        /// Muestra u Oculta el Programa Excel
        /// </summary>
        /// <param name="show"></param>
        public void ShowProgram(bool show = true)
        {
            this.iApp.Visible = show;
        }
        
        public void Dispose()
        {
            foreach (var libro in this.Libros)
                libro.Dispose();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(this.iApp);
            this.iApp = null;
        }
    }
}
