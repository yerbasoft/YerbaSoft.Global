using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;

namespace WindowsHelper.Cuentas.DTO
{
    public class Movimiento : YerbaSoft.DAL.Repositories.XmlSimpleClass
    {
        [Direct]
        public Guid Id { get; set; }

        [Direct]
        public Guid IdConcepto { get; set; }

        [Direct]
        public DateTime Fecha { get; set; }

        [Direct]
        public decimal Monto { get; set; }

        [Direct]
        public string Observaciones { get; set; }

        [Direct]
        public string FileRef { get; set; }

        [Direct]
        public DateTime CreaFecha { get; set; }
    }
}
