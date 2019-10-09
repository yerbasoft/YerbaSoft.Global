using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.Sync.DTO.StoredProcedures
{
    public class Pendiente
    {
        public Guid Id { get; set; }
        public string Numero { get; set; }
        public Guid IdCobro { get; set; }
        public bool AConfirmar { get; set; }
    }
}
