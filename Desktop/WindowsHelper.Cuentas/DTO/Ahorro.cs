using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;

namespace WindowsHelper.Cuentas.DTO
{
    public class Ahorro : YerbaSoft.DAL.Repositories.XmlSimpleClass
    {
        public enum TipoAhorros
        {
            PlazoFijo,
            Dolares
        }

        public Ahorro() { }
        public Ahorro(TipoAhorros tipo)
        {
            this.TipoAhorro = tipo;
            this.CreaFecha = DateTime.Now;
            this.FechaDesde = DateTime.Now;

            if (tipo == TipoAhorros.PlazoFijo)
                this.FechaHasta = DateTime.Now;
        }

        [Direct]
        public Guid Id { get; set; }

        [Direct]
        public TipoAhorros TipoAhorro { get; set; }

        [Direct]
        public string Entidad { get; set; }

        [Direct]
        public string Observaciones { get; set; }

        [Direct]
        public DateTime FechaDesde { get; set; }

        [Direct]
        public DateTime? FechaHasta { get; set; }

        [Direct]
        public decimal Monto { get; set; }

        [Direct]
        public decimal? TazaAnual { get; set; }

        [Direct]
        public DateTime CreaFecha { get; set; }

        [Direct]
        public DateTime? BajaFecha { get; set; }

        public int Dias => ((FechaHasta ?? DateTime.Now) - FechaDesde).Days;

        public decimal? InteresEstimado => TazaAnual.HasValue ? ( Monto * ( Dias * TazaAnual / 365 ) / 100) : (decimal?)null;
    }
}
