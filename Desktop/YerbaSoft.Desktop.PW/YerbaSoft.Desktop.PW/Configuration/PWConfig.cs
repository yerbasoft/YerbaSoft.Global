using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Desktop.PW.Configuration
{
    public class PWConfig
    {
        [Direct]
        public string AppPath { get; set; }

        [SubList("Cuenta")]
        public List<Cuenta> Cuentas { get; set; }

        [SubList("OpenAll")]
        public List<OpenAll> OpenAlls { get; internal set; }
    }
}
