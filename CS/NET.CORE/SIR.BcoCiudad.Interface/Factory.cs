using SIR.BcoCiudad.BLL;
using SIR.BcoCiudad.Common.DTO.Config;
using SIR.BcoCiudad.Common.Interfaces;
using SIR.Common.Log;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.BcoCiudad.Interface
{
    public static class Factory
    {
        public static IBcoCiudadService GetBcoCiudadService(Logger logger, Application config)
        {
            return new BcoCiudadService(logger, config);
        }
        public static INotificacionService GetNotificacionService(Logger logger, Application config)
        {
            return new NotificationService(logger, config);
        }
    }
}
