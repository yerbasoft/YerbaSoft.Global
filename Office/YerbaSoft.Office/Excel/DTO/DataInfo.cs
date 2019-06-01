using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Office.Excel.DTO
{
    public class DataInfo
    {
        public List<Ranges> Ranges { get; private set; } = new List<Ranges>();

        public DataInfo AddCell(Cell obj) { this.Ranges.Add(obj); return this; }
        public DataInfo AddRow(Row obj) { this.Ranges.Add(obj); return this; }
        public DataInfo AddColumn(Column obj) { this.Ranges.Add(obj); return this; }
        public DataInfo AddRange(Ranges obj) { this.Ranges.Add(obj); return this; }
    }
}
