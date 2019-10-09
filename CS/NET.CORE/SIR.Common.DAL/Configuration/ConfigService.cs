using System.Linq;
using System.Collections.Generic;
using System.Text;
using SIR.Common.DTO;
using SIR.Common.DAL.Configuration.Entities;
using SIR.Common.Log;

namespace SIR.Common.DAL.Configuration
{
    internal class ConfigService : IConfigService
    {
        private string Module;
        private IRepository<Entities.Config> Configs;

        internal ConfigService(string module, IRepository<Entities.Config> repository)
        {
            this.Module = module;
            this.Configs = repository;
        }

        /// <summary>
        /// Obtiene una configuración
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Response<Config> Get(string key)
        {
            var configs = this.Configs.Find(p => p.ModuleId == this.Module && p.Key == key);

            if (configs.Count() == 0)
                return new Response<Config>(new KeyNotFoundException($"No se encontró la Key: '{key}' para el ModuleId:'{this.Module}'."));

#if DEBUG
            // DEBUG: Me sirve cualquier KEY (prioridad a DEBUG = 1)
            return new Response<Config>(configs.OrderByDescending(p => p.Debug).First());
#else
            // RELEASE: Sólo es válida la KEY donde DEBUG=0
            if (configs.Where(p => p.Debug == 0).Count() != 1)
                return new Response<Config>(new KeyNotFoundException($"No se encontró la Key: '{key}' para el ModuleId:'{this.Module}' para el modo Release."));
            else
                return new Response<Config>(configs.OrderBy(p => p.Debug).First());
#endif
        }

        public Config Get(string key, Logger logger)
        {
            return logger.Log(Get(key)).Data;
        }
    }
}
