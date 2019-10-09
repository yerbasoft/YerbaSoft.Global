using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.BcoCiudad.Common.Entities
{
    public class Encabezado
    {
        public virtual Guid Id { get; protected set; }
        public virtual string Banco { get; set; }
        public virtual DateTime FechaProceso { get; set; }
        public virtual long? CierreZ { get; set; }
        public virtual bool EsConsistente { get; set; }
        public virtual Guid? Traza { get; set; }
        public virtual bool Transmitido { get; set; }
        public virtual DateTime FechaCreacion { get; set; }
        public virtual DateTime? FechaModificacion { get; set; }

        public virtual RegistroError RegistroError { get; set; }
    }
}
