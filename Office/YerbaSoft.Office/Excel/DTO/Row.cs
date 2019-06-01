using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace YerbaSoft.Office.Excel.DTO
{
    public class Row : Ranges
    {
        public int Nro { get; set; }
        public double? Height { get; set; }

        public Row(int row) : this(row, null) { }
        public Row(int row, Styles style) : base(string.Empty, style)
        {
            this.Nro = row;
        }

        internal override Range GetRange(Worksheet sheet)
        {
            return sheet.Rows[this.Nro, Type.Missing];
        }

        internal override void Apply(Worksheet sheet)
        {
            base.Apply(sheet);

            if (this.Height.HasValue)
                GetRange(sheet).RowHeight = this.Height.Value;
        }


        public Row Update(Action<Row> action)
        {
            action.Invoke(this);
            return this;
        }
    }
}
