using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace YerbaSoft.Office.Excel.DTO
{
    public class Cell : Ranges
    {
        public object Value { get; set; }

        public Cell(string cell, object value) : this(cell, null, value) { }
        public Cell(string cell, Styles style, object value) : base(cell, style)
        {
            this.Value = value;
        }
        
        internal override void Apply(Worksheet sheet)
        {
            base.Apply(sheet);
            var range = GetRange(sheet);

            range.Value2 = this.Value;
        }
    }
}
