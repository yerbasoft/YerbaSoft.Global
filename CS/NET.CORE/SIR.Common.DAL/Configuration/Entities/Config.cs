using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.Common.DAL.Configuration.Entities
{
    public class Config
    {
        public virtual Guid Id { get; set; }
        public virtual string ModuleId { get; set; }
        public virtual string Key { get; set; }
        public virtual string Value { get; set; }
        public virtual int Debug { get; set; }

        /// <summary>
        /// Devuelve el valor de la configuración convertido al tipo especificado
        /// </summary>
        /// <typeparam name="T">Tipo de valor de retorno</typeparam>
        /// <returns></returns>
        public T Convert<T>(string datetimeFormat = null)
        {
            return Reflection.ConvertTo<T>(this.Value, datetimeFormat);
        }
    }
}
