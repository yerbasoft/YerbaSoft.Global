using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Dynamic.CustomFormat
{
    public abstract class CustomFormatBase
    {
        internal delegate string _OnResolveExpression(Dictionary<string, object> values, string fullexpression, string mode, string expression, string valorCalculado);
        internal event _OnResolveExpression OnResolveExpression;

        protected abstract string BlockIni { get; }
        protected abstract string BlockFin { get; }
        protected abstract string ModeSeparator { get; }
        protected abstract bool OnlyEventWhenError { get; }

        internal string Resolve(string format, Dictionary<string, object> values)
        {
            var ini = 0;
            var fin = 0;
            while ((ini = format.IndexOf(this.BlockIni, ini)) >= 0)
            {
                fin = format.IndexOf(this.BlockFin, ini);
                var fullExpression = format.Substring(ini + 1, fin - ini - 1);

                var modeIndex = fullExpression.IndexOf(this.ModeSeparator);
                var mode = "";
                var expression = "";
                var replace = "";

                if (modeIndex > 0)
                {
                    mode = fullExpression.Substring(0, modeIndex);
                    expression = fullExpression.Substring(mode.Length + this.ModeSeparator.Length);

                    var r = Dynamic.Exec(mode, "return " + expression + ";", values);
                    replace = r == null ? null : r.ToString();
                }
                
                // Llamo al evento si corresponde
                if (OnResolveExpression != null &&
                    (!this.OnlyEventWhenError || (this.OnlyEventWhenError && string.IsNullOrEmpty(mode))))  //  parámetro "OnlyEventWhenError"
                {
                    replace = OnResolveExpression(values, fullExpression, mode, expression, replace);
                }
                
                format = format.Substring(0, ini) + replace + format.Substring(fin + 1);
                ini += replace.Length;
            }
            return format;
        }

    }
}