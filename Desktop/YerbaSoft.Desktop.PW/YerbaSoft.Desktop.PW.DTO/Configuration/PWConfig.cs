using System.Collections.Generic;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Desktop.PW.DTO.Configuration
{
    public class PWCuentaConfig
    {
        [Direct]
        public string AppPath { get; set; }

        [Direct]
        public string AppIcon { get; set; }

        [SubList("Cuenta")]
        public List<Cuenta> Cuentas { get; set; }

        [SubList("OpenAll")]
        public List<OpenAll> OpenAlls { get; internal set; }
    }
}
