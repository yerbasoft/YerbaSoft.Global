using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.BcoCiudad.Common.Entities
{
    public class Dependencia
    {
        public virtual Guid Id { get; set; }

        public Encabezado Encabezado { get; set; }

        public virtual int NroDependencia { get; set; }
        public virtual long Referencia { get; set; }
        public virtual int NroLote { get; set; }
        public virtual DateTime FechaAcreditacion { get; set; }
        public virtual int MarcaProceso { get; set; }
        public virtual decimal ImporteAcreditado { get; set; }
        public virtual double ImporteComision { get; set; }
        public virtual int CantidadTalones { get; set; }
        public virtual string DenominaCodIntegrador { get; set; }
        public virtual int MarcaGrabacion { get; set; }
        public virtual long NroCuenta { get; set; }
        public virtual int CodTransaccion { get; set; }
        public virtual int CodIntegrador { get; set; }
    }
}
