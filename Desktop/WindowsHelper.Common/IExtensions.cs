using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsHelper
{
    public static class IExtensions
    {
        public static ToolStripMenuItem SetItems(this ToolStripMenuItem obj, IEnumerable<ToolStripItem> items)
        {
            obj.DropDownItems.AddRange(items.ToArray());
            return obj;
        }
    }
}
