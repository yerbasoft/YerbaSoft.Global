using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace YerbaSoft.Office.Excel.DTO
{
    public class Ranges
    {
        protected string RangeValue { get; set; }

        public Styles Style { get; protected set; }

        internal Ranges(string range) : this(range, null) { }
        internal Ranges(string range, Styles style)
        {
            this.Style = style ?? new Styles();
            this.RangeValue = range;
        }

        internal virtual Range GetRange(Worksheet sheet)
        {
            return sheet.Range[this.RangeValue];
        }

        internal virtual void Apply(Worksheet sheet)
        {
            this.Style.ApplyStyle(GetRange(sheet));
        }

        public static string GetRange(int x, int y)
        {
            var letters = ",A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z".Split(',');

            string letter = null;
            if (x <= letters.Length)
            {
                letter = letters[x];
            }
            else
            {
                var a1 = (int)Math.Floor(1.0 * letters.Length / x);
                var a2 = x - (a1 * letters.Length);
                letter = $"{letters[a1]}{letters[a2]}";
            }

            return $"{letter}{y}";
        }
    }
}
