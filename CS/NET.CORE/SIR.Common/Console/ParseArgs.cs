using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SIR.Common;

namespace SIR.Common.Console
{
    /// <summary>
    /// Parser de lista de argumentos
    /// </summary>
    public class ParseArgs
    {
        public readonly string[] prefix = { "-", "--", "/" };
        
        /// <summary>
        /// Devuelve un objeto con las propiedades cargadas según los argumentos recibidos
        /// </summary>
        /// <typeparam name="T">Tipo del Objeto a devolver</typeparam>
        /// <param name="args">argumentos recibidos</param>
        /// <returns></returns>
        public DTO.Response<T> Parse<T>(string[] args) where T : new()
        {
            var result = new DTO.Response<T>();
            var res = new T();

            var foundeds = new List<DTO.PropAttribute<Option>>();
            var props = Reflection.GetPropertiesWithAttribute<T, Option>();

            var pos = 0;
            while (pos < args.Length)
            {
                var arg = args[pos];

                // busco la propiedad
                var opt = props.FirstOrDefault(p => prefix.Select(x => x + p.Attr.Name).Contains(arg));
                if (opt == null)
                {
                    result.AddError($"No se reconoce el comando '{arg}'");
                    pos++;
                    continue;
                }

                if (opt.Type.IsAssignableFrom(typeof(bool)))
                {
                    // bool :: existe o no el parámetro
                    opt.Prop.SetValue(res, true);
                    foundeds.Add(opt);
                }
                else
                {
                    pos++;
                    if (pos >= args.Length)
                    {
                        result.AddError($"No se encuentra el valor para el parámetro '-{opt.Attr.Name}'");
                        continue;
                    }

                    try
                    {
                        var parsedValue = Reflection.ConvertTo(args[pos], opt.Type, opt.Attr.DateTimeFormat);
                        opt.Prop.SetValue(res, parsedValue);
                        foundeds.Add(opt);
                    }
                    catch (Exception ex)
                    {
                        result.AddError($"Error al parsear la propiedad '-{opt.Attr.Name}'.");
                        result.AddError(ex);
                    }
                }

                pos++;
            }

            // Requeridos faltantes
            foreach(var req in props.Where(r => r.Attr.Required && !foundeds.Any(f => f == r)))
            {
                result.AddError($"No se encuentra el valor para el parámetro requerido '-{req.Attr.Name}'");
            }

            return result.SetData(res);
        }

        /// <summary>
        /// Devuelve la lista de parámetros configurados en un objeto
        /// </summary>
        /// <typeparam name="T">Tipo del objeto con atributos 'Option'</typeparam>
        /// <returns></returns>
        public string GetHelpText<T>()
        {
            var sb = new StringBuilder();

            var propinfo = Reflection.GetPropertiesWithAttribute<T, Option>().Select(p => new {
                Arg = $"-{p.Attr.Name}" + (p.Type.IsAssignableFrom(typeof(DateTime)) ? $" {p.Attr.DateTimeFormat}" : ""),
                Desc = p.Attr.Descripcion
            });

            var maxsize = propinfo.Max(p => p.Arg.Length);
            foreach (var prop in propinfo)
            {
                sb.AppendLine(($"{prop.Arg}").PadRight(maxsize + 4, ' ') + prop.Desc);
            }
            return sb.ToString();
        }
    }
}
