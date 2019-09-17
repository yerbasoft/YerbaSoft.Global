using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Desktop.PW.DTO.Configuration.Villa
{
    public class Villa
    {
        [Direct(UseComplexConvert = true)]
        public bool FreezeDuringFly { get; set; }

        [SubList]
        public List<VillaPoint> VillaPoint { get; set; }
    }
}
