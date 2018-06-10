using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using YerbaSoft.DTO;

namespace WindowsHelper.EasyOpen.Configuration
{
    internal class SubMenu : EasyOpenType, YerbaSoft.DTO.Mapping.IExtraMapping
    {
        internal override string TypeName => "SubMenu";
        public IEnumerable<EasyOpenType> Items { get; set; }

        internal override void Run() { }

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

        internal override ToolStripItem GetMenu()
        {
            var m = new ToolStripMenuItem(this.Name);
            m.Tag = this;
            m.Image = this.Image;

            foreach (var link in this.Items)
                m.DropDownItems.Add(link.GetMenu());
            
            return m;
        }
    }
}