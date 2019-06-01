using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Office.Excel.DTO
{
    public class Styles
    {
        public enum UnderlineType
        {
            None = -4142,
            Single = 2,
            Double = -4119
        }

        public System.Drawing.Color? BackColor { get; set; }
        public System.Drawing.Color? FontColor { get; set; }
        public bool? FontBold { get; set; }
        public bool? FontItalic { get; set; }
        public UnderlineType? FontUnderline { get; set; }
        public StyleBorders Borders { get; set; } = new StyleBorders();
        public string DataNumberFormat { get; set; }

        public Styles Update(Action<Styles> action)
        {
            action.Invoke(this);
            return this;
        }

        public void ApplyStyle(Range range)
        {
            if (this.BackColor.HasValue)
                range.Interior.Color = this.BackColor.Value;

            if (this.FontColor.HasValue)
                range.Font.Color = this.FontColor.Value;
            if (this.FontBold.HasValue)
                range.Font.Bold = this.FontBold.Value;
            if (this.FontItalic.HasValue)
                range.Font.Italic = this.FontItalic.Value;
            if (this.FontUnderline.HasValue)
                range.Font.Underline = (int)this.FontUnderline.Value;

            if (this.Borders != null)
                this.Borders.Apply(range);

            if (!string.IsNullOrEmpty(this.DataNumberFormat))
                range.NumberFormat = this.DataNumberFormat;
        }
    }
}
