using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsHelper.EasyOpen.Configuration
{
    internal class Exe : EasyOpenType
    {
        internal override string TypeName => "Exe";
        
        [YerbaSoft.DTO.Mapping.Direct]
        public string Path { get; set; }
        
        [YerbaSoft.DTO.Mapping.Direct]
        public string OpenWith { get; set; }

        [YerbaSoft.DTO.Mapping.Direct]
        public string Params { get; set; }

        internal override ToolStripItem GetMenu()
        {
            var m = base.GetMenu();

            m.ToolTipText = OpenWith.Substring(OpenWith.LastIndexOf("\\")) + " " + Params;

            return m;
        }

        internal override void Run()
        {
            var openwith = string.IsNullOrEmpty(this.OpenWith) ? this.Path : this.OpenWith;
            var pi = new ProcessStartInfo(openwith)
            {
                WorkingDirectory = string.IsNullOrEmpty(this.Path) ? System.IO.Path.GetDirectoryName(this.OpenWith) : System.IO.Path.GetDirectoryName(this.Path),
                Arguments = string.IsNullOrEmpty(this.Params) ? System.IO.Path.GetFileName(this.Path) : this.Params,
                UseShellExecute = true
            };
            Process.Start(pi);
        }
    }
}
