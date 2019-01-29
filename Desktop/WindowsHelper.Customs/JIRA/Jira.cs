using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHelper.Customs.JIRA
{
    public class Jira
    {
        private const string JIRAUrl = "https://cardinalconsulting.atlassian.net/browse/{type}{Nro}";
        
        internal static void OpenJira(object sender, EventArgs e)
        {
            OpenSIR("");
        }

        internal static void OpenSIRE(object sender, EventArgs e)
        {
            OpenSIR("SIRE-");
        }

        internal static void OpenSIRP(object sender, EventArgs e)
        {
            OpenSIR("SIRP-");
        }

        internal static void OpenSIRN(object sender, EventArgs e)
        {
            OpenSIR("SIRN-");
        }

        private static void OpenSIR(string type)
        {
            var url = JIRAUrl.Replace("{type}", type);
            var f = new OpenUrl(new OpenUrlData(url, BLL.Explorers.Chrome).AddVar("Nro"));
            f.Show();
            WindowsHelper.Common.WinAPI.SetFocusWin(f.Handle);
        }
    }
}
