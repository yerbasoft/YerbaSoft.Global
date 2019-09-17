using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Desktop.PW.DTO.Configuration.Partys
{
    public class PartyConfig : YerbaSoft.DAL.Repositories.XmlSimpleClass
    {
        [Direct] public string Name { get; set; }

        [Direct] public string Lider { get; set; }

        [Direct] public string Member1 { get; set; }
        [Direct] public string Member2 { get; set; }
        [Direct] public string Member3 { get; set; }
        [Direct] public string Member4 { get; set; }
        [Direct] public string Member5 { get; set; }
    }
}
