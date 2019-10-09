using SIR.Common.Batch;
using SIR.Common.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.BcoCiudad.BLL.DTO.File
{
    public class FileDetalle : ISplitted
    {
        public const string Index = "12";

        [Split(2, 3)]
        public int NroDependencia { get; set; }
        [Split(5, 4)]
        public int CodEmpresa { get; set; }
        [Split(9, 6, DateTimeFormat = "yyMMdd")]
        public DateTime FechaRecaudacion { get; set; }
        [Split(15, 6)]
        public int NroLote { get; set; }
        [Split(21, 6, DateTimeFormat = "yyMMdd")]
        public DateTime FechaAcreditacion { get; set; }
        [Split(27, 1)]
        public int MarcaProceso { get; set; }
        [Split(28, 2)]
        public int TipoPago { get; set; }
        [Split(30, 1)]
        public int MarcaCaptura { get; set; }
        [Split(31, 1)]
        public int MarcaTurno { get; set; }
        [Split(32, 3)]
        public int NroOperador { get; set; }

        [Split(28, 57)]
        public string NumeroBoleta { get; set; }    // válido cuando NroDependencia IN ( CodigosConBUI )
        [Split(35, 60)]
        public string CodigoDeBarras { get; set; }    // válido cuando NroDependencia NOT IN ( CodigosConBUI )

        [Split(95, 13)]
        public long _Importe { get; set; }
        public decimal Importe
        {
            get => this._Importe / 100.0m;
            set { this._Importe = Convert.ToInt64(Math.Round(value * 100, 0)); }
        }
        [Split(108, 10)]
        public long NroComprobante { get; set; }
        [Split(118, 1)]
        public int MarcaRechazo { get; set; }
        [Split(119, 1)]
        public int MotivoRechazo { get; set; }
        [Split(120, 1)]
        public string AperturaSistema { get; set; }
        [Split(121, 4)]
        public int CodIntegrador { get; set; }
        
        public Response IsValidRow(string row)
        {
            if (row?.Length < 125)
                return new Response($"La línea no cumple con el length mínimo de 125. row: '{row}'");

            int aux;
            if (int.TryParse(row.Substring(9, 2), out aux))
            {
                if (aux > 60)
                    return new Response($"Caracteres 10 y 11 correspondientes al año de la Fecha de Recaudación corresponden a un año ambiguo. row: {row}");
            }
            else
            {
                return new Response($"Caracteres 10 y 11 correspondientes al año de la Fecha de Recaudación no son números válidos. row: {row}");
            }

            if (int.TryParse(row.Substring(21, 2), out aux))
            {
                if (aux > 60)
                    return new Response($"Caracteres 22 y 23 correspondientes al año de la Fecha de Acreditación corresponden a un año ambiguo. row: {row}");
            }
            else
            {
                return new Response($"Caracteres 22 y 23 correspondientes al año de la Fecha de Acreditación no son números válidos. row: {row}");
            }

            return new Response(true);
        }
    }
}
