using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.Sync.DTO.StoredProcedures
{
    public class RendicionPagos
    {
        public string Fecha { get; set; }
        public DateTime FechaPago { get; set; }
        public string CodBarras { get; set; }
        public int NroCbte { get; set; }
        public int Pos { get; set; }
        public string RecaudadorCodigo { get; set; }
        public string TipoPagoCodigo { get; set; }
        public string TarjetaCodigo { get; set; }

        public string Canal => RecaudadorCodigo + TipoPagoCodigo + (string.IsNullOrEmpty(TarjetaCodigo) ? "00" : TarjetaCodigo);
    }
}
