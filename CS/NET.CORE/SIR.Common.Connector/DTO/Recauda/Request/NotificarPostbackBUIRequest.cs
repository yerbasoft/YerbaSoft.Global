using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.Common.Connector.DTO.Recauda.Request
{
    public class NotificarPostbackBUIRequest
    {
        public Guid IdCobro { get; set; }
        public Guid IdPostback { get; set; }
        public string NroBUI { get; set; }
        public DateTime FechaPago { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
    }
}
