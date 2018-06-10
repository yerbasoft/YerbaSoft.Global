using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WindowsHelper.Configuration
{
    [YerbaSoft.DTO.Mapping.AutoMapping()]
    public class App : YerbaSoft.DTO.Mapping.IExtraMapping
    {
        [YerbaSoft.DTO.Mapping.Direct]
        public string Name { get; set; }

        [YerbaSoft.DTO.Mapping.Direct]
        public string IAppClass { get; set; }

        [YerbaSoft.DTO.Mapping.Direct]
        public string AssemblyName { get; set; }

        public XmlNode XmlNode { get; set; }

        public void ExtraMappingWhenGet(object ori, object info)
        {
            XmlNode = (XmlNode)ori;
        }
    }
}
