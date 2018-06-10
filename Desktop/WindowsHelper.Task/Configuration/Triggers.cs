using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using YerbaSoft.DTO;

namespace WindowsHelper.Task.Configuration
{
    public class Triggers : YerbaSoft.DTO.Mapping.IExtraMapping
    {
        public List<Trigger.TriggerType> Trigger { get; set; }

        public void ExtraMappingWhenGet(object ori, object info)
        {
            var items = new List<Trigger.TriggerType>();
            var node = (XmlNode)ori;
            var types = typeof(Trigger.TriggerType).Assembly.DefinedTypes.Where(t => typeof(Trigger.TriggerType).IsAssignableFrom(t) && !t.IsAbstract).ToArray();
            foreach (var n in node.SubNodes())
            {
                var obj = (Trigger.TriggerType)types.Single(p => p.Name == n.Name).GetConstructor(new Type[] { }).Invoke(new object[] { });
                YerbaSoft.DTO.Mapping.Map.CopyTo(n, obj);

                if (typeof(YerbaSoft.DTO.Mapping.IExtraMapping).IsAssignableFrom(obj.GetType()))
                    ((YerbaSoft.DTO.Mapping.IExtraMapping)obj).ExtraMappingWhenGet(n, this);

                items.Add(obj);
            }
            this.Trigger = items;
        }
    }
}