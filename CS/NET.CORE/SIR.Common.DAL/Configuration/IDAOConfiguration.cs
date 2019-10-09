using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.Common.DAL.Configuration
{
    public interface IDAOConfiguration
    {
        /// <summary>
        /// Servicio de acceso a la Configuración
        /// </summary>
        IConfiguration Config { get; }
    }
}
