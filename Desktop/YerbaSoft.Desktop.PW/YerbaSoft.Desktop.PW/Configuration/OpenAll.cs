using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Desktop.PW.Configuration
{
    public class OpenAll
    {
        [Direct]
        public string Name { get; set; }

        [Direct]
        public string Cuentas { get; set; }
    }
}
