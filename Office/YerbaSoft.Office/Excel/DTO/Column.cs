using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Office.Excel.DTO
{
    public class Column : Ranges
    {
        public int Nro { get; set; }
        public double? Width { get; set; }

        public Column(int col) : this(col, null) { }
        public Column(int col, Styles style) : base(string.Empty, style)
        {
            this.Nro = col;
        }

        internal override Range GetRange(Worksheet sheet)
        {
            return sheet.Columns[this.Nro, Type.Missing];
        }

        internal override void Apply(Worksheet sheet)
        {
            base.Apply(sheet);

            if (this.Width.HasValue)
                GetRange(sheet).ColumnWidth = this.Width.Value;
        }

        public Column Update(Action<Column> action)
        {
            action.Invoke(this);
            return this;
        }
    }
}
