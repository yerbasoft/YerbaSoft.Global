using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsHelper.Memory.Configuration
{
    internal class ToClipBoard : Base, YerbaSoft.DTO.Mapping.IExtraMapping
    {
        internal override string TypeName => "ToClipBoard";
        public string Content { get; set; }

        public void ExtraMappingWhenGet(object ori, object info)
        {
            var node = (XmlNode)ori;

            this.Content = node.InnerText;
        }

        internal override void Run()
        {
            if (!string.IsNullOrEmpty(this.Content))
                Clipboard.SetText(this.Content);
        }
    }
}
