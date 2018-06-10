using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHelper.Configuration
{
    public class WindowsHelper
    {
        [YerbaSoft.DTO.Mapping.Direct]
        public string Version { get; set; }

        [YerbaSoft.DTO.Mapping.SubClass]
        public Applications Applications { get; set; }
    }
}
