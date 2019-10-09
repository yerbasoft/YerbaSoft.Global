using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.Common.Connector.Http
{
    /// <summary>
    /// Estructura para la utilización de Basic Authentification
    /// </summary>
    public class BasicAuthorization
    {
        /// <summary>
        /// Usuario a utilizar
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// Password del usuario
        /// </summary>
        public string Pass { get; set; }

        /// <summary>
        /// Crea una nueva instancia estableciendo el usuario y contraseña
        /// </summary>
        public BasicAuthorization(string user, string pass)
        {
            this.User = user;
            this.Pass = pass;
        }
    }
}
