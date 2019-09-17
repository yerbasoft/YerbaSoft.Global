using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Desktop.PW.DTO.Data
{
    public class MapPoint : YerbaSoft.DAL.Repositories.XmlSimpleClass
    {
        [Direct] public string Name { get; set; }
        [Direct] public string Type { get; set; }
        [Direct] public float X { get; set; }
        [Direct] public float Z { get; set; }
    }
}
