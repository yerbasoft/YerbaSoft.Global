using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Desktop.PW.DTO.Configuration.WinModes
{
    public class Win : YerbaSoft.DAL.Repositories.XmlSimpleClass
    {
        [Direct] public string Cuenta { get; set; }

        [Direct] public int Left { get; set; }
        [Direct] public int Top { get; set; }
        [Direct] public int Width { get; set; }
        [Direct] public int Height { get; set; }
    }
}
