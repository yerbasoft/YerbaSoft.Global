using SIR.Common.Log;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.BcoCiudad.BLL
{
    public class NotificationService : Common.Interfaces.INotificacionService
    {
        private Logger Logger;

        public NotificationService(Logger log, Common.DTO.Config.Application config)
        {
            this.Logger = log;
        }

        public void ProcesarNotificaciones()
        {
            throw new NotImplementedException();
        }
    }
}
