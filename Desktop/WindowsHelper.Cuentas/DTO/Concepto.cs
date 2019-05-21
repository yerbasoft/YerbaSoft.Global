using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;

namespace WindowsHelper.Cuentas.DTO
{
    internal class Concepto : YerbaSoft.DAL.Repositories.XmlSimpleClass
    {
        [Direct]
        public Guid Id { get; set; }

        [Direct]
        public string Name { get; set; }

        [Direct]
        public bool EsCredito { get; set; }

        [Direct]
        public string Observaciones { get; set; }

        [Direct]
        public DateTime CreaFecha { get; set; }

        [Direct]
        public DateTime? BajaFecha { get; set; }

        public override string ToString()
        {
            return $"{Name} ({(EsCredito ? "Crédito" : "Débito")})";
        }
    }
}
