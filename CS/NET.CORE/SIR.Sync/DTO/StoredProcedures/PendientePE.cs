using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.Sync.DTO.StoredProcedures
{
    public class PendientePE
    {
        public Guid IdPostback { get; set; }
        public Guid IdBoleta { get; set; }
        public string Numero { get; set; }
        public Guid IdCobro { get; set; }
        public DateTime Fecha { get; set; }
    }
}
