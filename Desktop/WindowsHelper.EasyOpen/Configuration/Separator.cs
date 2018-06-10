using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsHelper.EasyOpen.Configuration
{
    internal class Separator : EasyOpenType
    {
        internal override string TypeName => "Separator";

        internal override void Run()
        {
        }

        internal override ToolStripItem GetMenu()
        {
            return new ToolStripSeparator();
        }
    }
}
