using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSWork.DTO.GlobalConfigs
{
    public class Ambiente
    {
        public string Name { get; set; }
        public string WebServerIP { get; set; }
        public bool AllowExplorer { get; set; } = true;
        public bool AllowRemote { get; set; } = true;
        public bool UseCustomUser { get; set; }
        public string CustomUser { get; set; }
        public string CustomPass { get; set; }

        public List<AmbienteWeb> Webs { get; set; } = new List<AmbienteWeb>();

        public override string ToString()
        {
            return this.Name;
        }

        public string GetCmdExplorer(GCBARed global)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"cmdkey /delete:{WebServerIP}");
            sb.AppendLine($"cmdkey /add:{WebServerIP} /user:\"{(UseCustomUser ? CustomUser : global.User)}\" /pass:\"{(UseCustomUser ? CustomPass : global.Pass)}\"");
            sb.AppendLine($"C:\\Windows\\explorer.exe \"\\\\{WebServerIP}\"");

            return sb.ToString();
        }

        public string GetCmdRemoteDesktop(GCBARed global)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"cmdkey /delete:{WebServerIP}");
            sb.AppendLine($"cmdkey /add:{WebServerIP} /user:\"{(UseCustomUser ? CustomUser : global.User)}\" /pass:\"{(UseCustomUser ? CustomPass : global.Pass)}\"");
            sb.AppendLine($"mstsc /v:{WebServerIP} /admin /f");

            return sb.ToString();
        }
    }
}
