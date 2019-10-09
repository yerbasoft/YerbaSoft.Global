using SIR.Common.Batch;
using SIR.Common.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.BcoCiudad.BLL.DTO.File
{
    public class FileDependencia : ISplitted
    {
        public const string Index = "10";

        [Split(2, 3)]
        public int NroDependencia { get; set; }
        [Split(5, 10)]
        public long Referencia { get; set; }
        [Split(15, 6)]
        public int NroLote { get; set; }
        [Split(21, 6, DateTimeFormat = "yyMMdd")]
        public DateTime FechaAcreditacion { get; set; }
        [Split(27, 1)]
        public int MarcaProceso { get; set; }
        [Split(28, 17)]
        public long _ImporteAcreditadoOriginal { get; set; }
        public decimal ImporteAcreditado
        {
            get => this._ImporteAcreditadoOriginal / 100.0m;
            set { this._ImporteAcreditadoOriginal = Convert.ToInt64(Math.Round(value * 100, 0)); }
        }
        [Split(28, 17)]
        public long _ImporteComisionOriginal { get; set; }
        public decimal ImporteComision
        {
            get => this._ImporteComisionOriginal / 100.0m;
            set { this._ImporteComisionOriginal = Convert.ToInt64(Math.Round(value * 100, 0)); }
        }
        [Split(56, 6)]
        public int CantidadTalones { get; set; }
        [Split(62, 12)]
        public string DenominaCodIntegrador { get; set; }
        [Split(74, 1)]
        public int MarcaGrabacion { get; set; }
        [Split(75, 10)]
        public int NroCuenta { get; set; }
        [Split(117, 4)]
        public int CodTransaccion { get; set; }
        [Split(121, 4)]
        public int CodIntegrador { get; set; }

        public Response IsValidRow(string row)
        {
            if (row?.Length < 125)
                return new Response($"La línea no cumple con el length mínimo de 125. row: '{row}'");

            return new Response(true);
        }
    }
}
