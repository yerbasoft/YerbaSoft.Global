using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.BcoCiudad.Common.Entities
{
    public class RegistroError
    {
        public virtual Guid Id { get; set; }

        public virtual DateTime Fecha { get; set; }
        public virtual int? Codigo { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string Archivo { get; set; }
        public virtual int? Linea { get; set; }
        public virtual string Excepcion { get; set; }
        public virtual string UnidadProceso { get; set; }
    }
}
