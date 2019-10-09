using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.Common.Connector.DTO.VEP.Request
{
    public class NotificarPagoRequest
    {
        public string Numero { get; set; }
        public string Barcode { get; set; }
        public bool AConfirmar { get; set; }
        public Guid Traza { get; set; }
    }
}
