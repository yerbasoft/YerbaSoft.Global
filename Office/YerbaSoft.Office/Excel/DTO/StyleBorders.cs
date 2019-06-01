using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace YerbaSoft.Office.Excel.DTO
{
    public class StyleBorders
    {
        public List<StyleBorder> Borders { get; set; }

        public StyleBorders()
        {
            this.Borders = new List<StyleBorder>();
        }


        public StyleBorders Update(Action<StyleBorders> action)
        {
            action.Invoke(this);
            return this;
        }

        public StyleBorders Add(StyleBorder obj)
        {
            this.Borders.Add(obj);
            return this;
        }

        public StyleBorders AddRange(IEnumerable<StyleBorder> objs)
        {
            this.Borders.AddRange(objs);
            return this;
        }

        public StyleBorders SetRectangle()
        {
            return SetRectangle(System.Drawing.Color.Black, StyleBorder.LineStyle.xlContinuous, StyleBorder.BorderWeight.xlThin);
        }
        public StyleBorders SetRectangle(System.Drawing.Color color)
        {
            return SetRectangle(color, StyleBorder.LineStyle.xlContinuous, StyleBorder.BorderWeight.xlThin);
        }
        public StyleBorders SetRectangle(System.Drawing.Color color, StyleBorder.BorderWeight border)
        {
            return SetRectangle(color, StyleBorder.LineStyle.xlContinuous, border);
        }
        public StyleBorders SetRectangle(System.Drawing.Color color, StyleBorder.LineStyle style, StyleBorder.BorderWeight border)
        {
            Borders.Add(new StyleBorder(StyleBorder.BorderSide.xlEdgeTop, color, style, border));
            Borders.Add(new StyleBorder(StyleBorder.BorderSide.xlEdgeBottom, color, style, border));
            Borders.Add(new StyleBorder(StyleBorder.BorderSide.xlEdgeLeft, color, style, border));
            Borders.Add(new StyleBorder(StyleBorder.BorderSide.xlEdgeRight, color, style, border));

            return this;
        }

        public StyleBorders SetGrid()
        {
            return SetGrid(System.Drawing.Color.Black, StyleBorder.LineStyle.xlContinuous, StyleBorder.BorderWeight.xlThin);
        }
        public StyleBorders SetGrid(System.Drawing.Color color)
        {
            return SetGrid(color, StyleBorder.LineStyle.xlContinuous, StyleBorder.BorderWeight.xlThin);
        }
        public StyleBorders SetGrid(System.Drawing.Color color, StyleBorder.BorderWeight border)
        {
            return SetGrid(color, StyleBorder.LineStyle.xlContinuous, border);
        }
        public StyleBorders SetGrid(System.Drawing.Color color, StyleBorder.LineStyle style, StyleBorder.BorderWeight border)
        {
            Borders.Add(new StyleBorder(StyleBorder.BorderSide.xlEdgeTop, color, style, border));
            Borders.Add(new StyleBorder(StyleBorder.BorderSide.xlEdgeBottom, color, style, border));
            Borders.Add(new StyleBorder(StyleBorder.BorderSide.xlEdgeLeft, color, style, border));
            Borders.Add(new StyleBorder(StyleBorder.BorderSide.xlEdgeRight, color, style, border));
            Borders.Add(new StyleBorder(StyleBorder.BorderSide.xlInsideHorizontal, color, style, border));
            Borders.Add(new StyleBorder(StyleBorder.BorderSide.xlInsideVertical, color, style, border));

            return this;
        }


        public StyleBorders SetColumns()
        {
            return SetColumns(System.Drawing.Color.Black, StyleBorder.LineStyle.xlContinuous, StyleBorder.BorderWeight.xlThin);
        }
        public StyleBorders SetColumns(System.Drawing.Color color)
        {
            return SetColumns(color, StyleBorder.LineStyle.xlContinuous, StyleBorder.BorderWeight.xlThin);
        }
        public StyleBorders SetColumns(System.Drawing.Color color, StyleBorder.BorderWeight border)
        {
            return SetColumns(color, StyleBorder.LineStyle.xlContinuous, border);
        }
        public StyleBorders SetColumns(System.Drawing.Color color, StyleBorder.LineStyle style, StyleBorder.BorderWeight border)
        {
            Borders.Add(new StyleBorder(StyleBorder.BorderSide.xlEdgeLeft, color, style, border));
            Borders.Add(new StyleBorder(StyleBorder.BorderSide.xlEdgeRight, color, style, border));

            return this;
        }

        public StyleBorders SetRows()
        {
            return SetRows(System.Drawing.Color.Black, StyleBorder.LineStyle.xlContinuous, StyleBorder.BorderWeight.xlThin);
        }
        public StyleBorders SetRows(System.Drawing.Color color)
        {
            return SetRows(color, StyleBorder.LineStyle.xlContinuous, StyleBorder.BorderWeight.xlThin);
        }
        public StyleBorders SetRows(System.Drawing.Color color, StyleBorder.BorderWeight border)
        {
            return SetRows(color, StyleBorder.LineStyle.xlContinuous, border);
        }
        public StyleBorders SetRows(System.Drawing.Color color, StyleBorder.LineStyle style, StyleBorder.BorderWeight border)
        {
            Borders.Add(new StyleBorder(StyleBorder.BorderSide.xlEdgeTop, color, style, border));
            Borders.Add(new StyleBorder(StyleBorder.BorderSide.xlEdgeBottom, color, style, border));

            return this;
        }
        
        internal void Apply(Range range)
        {
            foreach (var border in Borders)
                border.Apply(range);
        }
    }
}
