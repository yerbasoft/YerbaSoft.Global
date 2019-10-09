using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.Common.DAL.Configuration
{
    /// <summary>
    /// Interfaz para objetos DAO que indica que el DAO contendrá las propiedades y métodos necesarios para la obtención de la configuración del sistema
    /// </summary>
    public interface IDAOConfig
    {
        /// <summary>
        /// Servicio de acceso a la Configuración
        /// </summary>
        IConfigService Config { get; }
    }
}
