using SIR.Common.DAL.Configuration.Entities;
using SIR.Common.DTO;

namespace SIR.Common.DAL.Configuration
{
    /// <summary>
    /// Servicio de acceso a la configuración
    /// </summary>
    public interface IConfigService
    {
        /// <summary>
        /// Obtiene una configuración según su Key y devuelve un Response que incluirá el error en caso de haber ocurrido alguno
        /// </summary>
        /// <param name="key">Key de la configuración</param>
        /// <returns></returns>
        Response<Config> Get(string key);

        /// <summary>
        /// Obtiene una configuración según su Key y devuelve el objeto Config con todos sus datos. En caso de ocurrir un error, el método devolverá null y logueará el error en el Logger provisto
        /// </summary>
        /// <param name="key">Key de la configuración</param>
        /// <param name="logger">Logger de la aplicación</param>
        /// <returns></returns>
        Config Get(string key, SIR.Common.Log.Logger logger);
    }
}
