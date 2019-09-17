using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Desktop.PW.DTO.Configuration.WinModes
{
    public class WinMode : YerbaSoft.DAL.Repositories.XmlSimpleClass
    {
        [Direct] public string Name { get; set; }

        [SubList]
        public List<Win> Wins { get; set; }
    }
}
