using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.Common.Connector.DTO.VEP.Request
{
    public class CancelarRequest
    {
        public Guid Id { get; set; }
        public string Numero { get; set; }
    }
}
