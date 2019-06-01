using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace YerbaSoft.Office.Excel
{
    public class Hoja : IDisposable
    {
        Worksheet iWorksheet;

        public Hoja(Worksheet worksheet)
        {
            this.iWorksheet = worksheet;
        }

        /// <summary>
        /// Nombre de la hoja
        /// </summary>
        public string Name { get { return this.iWorksheet.Name; } set { this.iWorksheet.Name = value; } }

        /// <summary>
        /// Selecciona la hoja
        /// </summary>
        public void Select()
        {
            this.iWorksheet.Select();
        }

        /// <summary>
        /// establece lños datos y formatos a la hoja
        /// </summary>
        /// <param name="info"></param>
        public void SetInfo(DTO.DataInfo info)
        {
            foreach (var range in info.Ranges)
                range.Apply(this.iWorksheet);
        }
        
        public void Dispose()
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(this.iWorksheet);
            this.iWorksheet = null;
        }

        internal void Delete()
        {
            this.iWorksheet.Delete();
            this.Dispose();
        }
    }
}
