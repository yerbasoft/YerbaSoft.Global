using System;
using System.Collections.Generic;
using System.Linq;

namespace YerbaSoft.DTO.Exceptions
{
    public abstract class ExceptionConvertTemplateBase
    {
        /// <summary>
        /// Formato del Template para la Excepcion
        /// </summary>
        protected abstract string Template { get; }
        /// <summary>
        /// Formato de Template para la Inner Exception
        /// </summary>
        protected abstract string TemplateInner { get; }

        /// <summary>
        /// Cantidad de Tabs a utilizar para las inner Exceptions (0: ninguno)
        /// </summary>
        protected abstract int TabsForInnerException { get; }
        /// <summary>
        /// Indica si se utilizarán 2 espacios vacíos en lugar de Tabs
        /// </summary>
        protected abstract bool Use2SpaceInTabsForInnerException { get; }

        /// <summary>
        /// Devuelve la descripción completa de la Excepción
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        internal string GetFullDescription(System.Exception ex, Dictionary<string, object> values)
        {
            var cf = new YerbaSoft.Dynamic.CustomFormat.CustomFormat();
            cf.OnResolveExpression += CustomFormat_OnResolveExpression;

            values = values ?? new Dictionary<string, object>();
            var vals = values.ToDictionary(k => k.Key, v => v.Value); // clono el objeto
            vals.Add("ex", ex);
            var result = cf.Resolve(this.Template, vals);

            return result;
        }

        protected virtual string CustomFormat_OnResolveExpression(Dictionary<string, object> values, string fullexpression, string mode, string expression, string valorCalculado)
        {
            switch (fullexpression.ToUpper())
            {
                case "INNEREXCEPTION":

                    var vals = values.ToDictionary(k => k.Key, v => v.Value); // clono el objeto
                    vals["ex"] = ((Exception)vals["ex"]).InnerException;    // piso "ex" con su inner

                    if (vals["ex"] != null)   // Si hay una inner Exception
                    {
                        var cf = new YerbaSoft.Dynamic.CustomFormat.CustomFormat();
                        cf.OnResolveExpression += CustomFormat_OnResolveExpression;
                        var text = cf.Resolve(this.TemplateInner, vals);

                        return text.Replace(System.Environment.NewLine, System.Environment.NewLine + Math.Repeat(this.Use2SpaceInTabsForInnerException ? "  " : "\t", this.TabsForInnerException));
                    }
                    else
                    {
                        return valorCalculado;
                    }
                default:
                    return valorCalculado;
            }
        }
    }
}
