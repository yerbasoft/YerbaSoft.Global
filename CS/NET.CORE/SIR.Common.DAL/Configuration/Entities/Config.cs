using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.Common.DAL.Configuration.Entities
{
    /// <summary>
    /// Representa una configuración del sistema
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Id único de la configuración
        /// </summary>
        public virtual Guid Id { get; set; }
        /// <summary>
        /// Módulo al que pertenece la configuración
        /// </summary>
        public virtual string ModuleId { get; set; }
        /// <summary>
        /// Clave única de configuración relativa al módulo
        /// </summary>
        public virtual string Key { get; set; }
        /// <summary>
        /// Valor de la configuración
        /// </summary>
        public virtual string Value { get; set; }
        /// <summary>
        /// Indica si es una configuración para el modo DEBUG (1) o para el modo RELEASE (0)
        /// </summary>
        public virtual int Debug { get; set; }

        /// <summary>
        /// Devuelve el valor de la configuración convertido al tipo especificado
        /// </summary>
        /// <typeparam name="T">Tipo de valor de retorno</typeparam>
        public T Convert<T>(string datetimeFormat = null)
        {
            return Reflection.ConvertTo<T>(this.Value, datetimeFormat);
        }
    }
}
