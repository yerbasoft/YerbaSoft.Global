using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using YerbaSoft.DTO;

namespace WindowsHelper.EasyOpen.Configuration
{
    internal class EasyOpenConfig : YerbaSoft.DTO.Mapping.IExtraMapping
    {
        public IEnumerable<EasyOpenType> Items { get; set; }

        public void ExtraMappingWhenGet(object ori, object info)
        {
            var items = new List<EasyOpenType>();
            var node = (XmlNode)ori;
            var types = typeof(EasyOpenType).Assembly.DefinedTypes.Where(t => typeof(EasyOpenType).IsAssignableFrom(t) && !t.IsAbstract).ToArray();
            foreach (var n in node.SubNodes())
            {
                var obj = (EasyOpenType)types.Single(p => p.Name == n.Name).GetConstructor(new Type[] { }).Invoke(new object[] { });
                YerbaSoft.DTO.Mapping.Map.CopyTo(n, obj);

                if (typeof(YerbaSoft.DTO.Mapping.IExtraMapping).IsAssignableFrom(obj.GetType()))
                    ((YerbaSoft.DTO.Mapping.IExtraMapping)obj).ExtraMappingWhenGet(n, this);

                items.Add(obj);
            }
            this.Items = items;
        }
    }
}
