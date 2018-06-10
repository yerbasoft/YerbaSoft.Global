using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using YerbaSoft.DTO;

namespace WindowsHelper.Memory.Configuration
{
    internal class SubMenu : Base, YerbaSoft.DTO.Mapping.IExtraMapping
    {
        internal override string TypeName => "SubMenu";
        public IEnumerable<Base> Items { get; set; }

        internal override void Run() { }

        public void ExtraMappingWhenGet(object ori, object info)
        {
            var items = new List<Base>();
            var node = (XmlNode)ori;
            var types = typeof(Base).Assembly.DefinedTypes.Where(t => typeof(Base).IsAssignableFrom(t) && !t.IsAbstract).ToArray();
            foreach (var n in node.SubNodes())
            {
                var obj = (Base)types.Single(p => p.Name == n.Name).GetConstructor(new Type[] { }).Invoke(new object[] { });
                YerbaSoft.DTO.Mapping.Map.CopyTo(n, obj);

                if (typeof(YerbaSoft.DTO.Mapping.IExtraMapping).IsAssignableFrom(obj.GetType()))
                    ((YerbaSoft.DTO.Mapping.IExtraMapping)obj).ExtraMappingWhenGet(n, this);

                items.Add(obj);
            }
            this.Items = items;
        }

        internal override ToolStripMenuItem GetMenu()
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
