using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Office.Excel.DTO
{
    public class StyleBorder
    {
        public enum BorderSide
        {
            xlDiagonalDown = 5,
            xlDiagonalUp = 6,
            xlEdgeLeft = 7,
            xlEdgeTop = 8,
            xlEdgeBottom = 9,
            xlEdgeRight = 10,
            xlInsideVertical = 11,
            xlInsideHorizontal = 12
        }

        public enum LineStyle
        {
            xlLineStyleNone = -4142,
            xlDouble = -4119,
            xlDot = -4118,
            xlDash = -4115,
            xlContinuous = 1,
            xlDashDot = 4,
            xlDashDotDot = 5,
            xlSlantDashDot = 13
        }

        public enum BorderWeight
        {
            xlMedium = -4138,
            xlHairline = 1,
            xlThin = 2,
            xlThick = 4
        }

        public BorderSide Side { get; set; }
        public System.Drawing.Color? Color { get; set; }
        public LineStyle? Style { get; set; }
        public BorderWeight? Border { get; set; }

        public StyleBorder(BorderSide side) : this(side, System.Drawing.Color.Black, LineStyle.xlContinuous, BorderWeight.xlThin) { }
        public StyleBorder(BorderSide side, System.Drawing.Color color) : this(side, color, LineStyle.xlContinuous, BorderWeight.xlThin) { }
        public StyleBorder(BorderSide side, System.Drawing.Color color, BorderWeight border) : this(side, color, LineStyle.xlContinuous, border) { }
        public StyleBorder(BorderSide side, System.Drawing.Color color, LineStyle style, BorderWeight border)
        {
            this.Side = side;
            this.Color = color;
            this.Style = style;
            this.Border = border;
        }

        internal void Apply(Range range)
        {
            var index = (XlBordersIndex)Enum.Parse(typeof(XlBordersIndex), ((int)this.Side).ToString());

            if (this.Color.HasValue)
                range.Borders[index].Color = this.Color.Value;
            if (this.Style.HasValue)
                range.Borders[index].LineStyle = (int)this.Style.Value;
            if (this.Border.HasValue)
                range.Borders[index].Weight = (int)this.Border.Value;
        }
    }
}
