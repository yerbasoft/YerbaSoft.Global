using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.Common.Connector.Http
{
    /// <summary>
    /// Clase para la configuración del conector
    /// </summary>
    public class ConnectorHeader
    {
        /// <summary>
        /// Indica si se debe especificar el uso de "application/json"
        /// </summary>
        public bool UseContentTypeJSON { get; set; }
        /// <summary>
        /// Utiliza Authentificación basica
        /// </summary>
        public BasicAuthorization BasicAuthorization { get; set; }
        /// <summary>
        /// Listado de cabeceras personalizadas
        /// </summary>
        public List<KeyValuePair<string, string>> Custom { get; } = new List<KeyValuePair<string, string>>();

        /// <summary>
        /// Crea una nueva instancia sin configuración
        /// </summary>
        public ConnectorHeader() { }
        /// <summary>
        /// Crea una nueva instancia con configuración de Authentificación Basica
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        public ConnectorHeader(string user, string pass)
        {
            this.BasicAuthorization = new BasicAuthorization(user, pass);
        }
        /// <summary>
        /// Crea una nueva instancia con una cabecera custom
        /// </summary>
        /// <param name="customs"></param>
        public ConnectorHeader(params KeyValuePair<string, string>[] customs)
        {
            this.Custom.AddRange(customs);
        }

        /// <summary>
        /// Agrega una nueva configuración Custom al header
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ConnectorHeader Add(string key, string value)
        {
            this.Custom.Add(new KeyValuePair<string, string>(key, value));
            return this;
        }

        /// <summary>
        /// Establece la propiedad UseContentTypeJSON y devuelve la misma instancia del objeto
        /// </summary>
        /// <param name="use"></param>
        /// <returns></returns>
        public ConnectorHeader SetUseContentTypeJSON(bool use)
        {
            this.UseContentTypeJSON = use;
            return this;
        }
    }
}
