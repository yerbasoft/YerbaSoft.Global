using SIR.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIR.Common.Batch
{
    public class Split : Attribute
    {
        /// <summary>
        /// Indica la posición de inicio (base 0)
        /// </summary>
        public int Offset { get; set; }
        /// <summary>
        /// Indica el largo del campo
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// Indica el formato de conversión de un tipo DateTime
        /// </summary>
        public string DateTimeFormat { get; set; } = "yyyyMMdd";

        public delegate void AfterParse(string row, object value);
        public AfterParse DoAfterParse { get; set; }

        /// <summary>
        /// Atributo de configuración de Batch Splitter
        /// </summary>
        public Split() { }
        /// <summary>
        /// Atributo de configuración de Batch Splitter
        /// </summary>
        /// <param name="offset">Indica la posición de inicio (base 0)</param>
        /// <param name="size">Indica el largo del campo</param>
        public Split(int offset, int size)
        {
            this.Offset = offset;
            this.Size = size;
        }

        /// <summary>
        /// Devuelve un dato ya formateado
        /// </summary>
        /// <param name="row"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        internal Response<object> GetValue(string row, Type type)
        {
            try
            {
                var str = row.Substring(this.Offset, this.Size);

                return new Response<object>(true).SetData(Reflection.ConvertTo(str, type, this.DateTimeFormat));
            }
            catch (Exception ex)
            {
                return new Response<object>(ex);
            }
        }
    }
}
