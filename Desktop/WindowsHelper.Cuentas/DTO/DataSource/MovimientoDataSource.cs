using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHelper.Cuentas.DTO.DataSource
{
    internal class MovimientoDataSource
    {
        public Movimiento Movimiento { get; set; }
        public Concepto Concepto { get; set; }

        public Guid Id => this.Movimiento.Id;
        public DateTime Fecha => this.Movimiento.Fecha;
        public decimal Monto => this.Movimiento.Monto;
        public string Observaciones => this.Movimiento.Observaciones;
        public string FileRef => this.Movimiento.FileRef;
        public DateTime CreaFecha => this.Movimiento.CreaFecha;

        public string ConceptoName => Concepto?.Name;

        public MovimientoDataSource() { }
        public MovimientoDataSource(Movimiento mov, Concepto con)
        {
            this.Movimiento = mov;
            this.Concepto = con;
        }
    }
}
