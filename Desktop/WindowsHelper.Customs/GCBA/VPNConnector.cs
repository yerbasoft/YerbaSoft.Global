using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsHelper.Customs.GCBA
{
    internal class VPNConnector
    {
        public static List<IntPtr> HiddenWindows { get; set; } = new List<IntPtr>();

        internal static void OpenAll(object sender, EventArgs e)
        {
            WindowsHelper.Common.Executable.RunCmd(new string[] { "net stop \"ShrewSoft IPSEC Daemon\"", "net stop \"ShrewSoft IKE Daemon\"" }).WaitForExit();
            System.Threading.Thread.Sleep(3000);
            WindowsHelper.Common.Executable.RunCmd(new string[] { "net start \"ShrewSoft IKE Daemon\"", "net start \"ShrewSoft IPSEC Daemon\"" }).WaitForExit();
            System.Threading.Thread.Sleep(3000);
            WindowsHelper.Common.Executable.RunCmd(new string[] {
                  "C:",
                  "cd \"C:\\Program Files\\ShrewSoft\\VPN Client\"",
                  "ipsecc.exe -r \"Cardinal_VPN.PCF\" -u \"grodriguez\" -p \"Gr0dr1gu3z.r4a2\" -a"
                });
            System.Threading.Thread.Sleep(3000);

            try
            {
                // Oculto la ventanita.
                var ptr = WindowsHelper.Common.WinAPI.FindWin("VPN Connect - Cardinal_VPN.PCF", "ipsecc");
                Application.DoEvents();
                WindowsHelper.Common.WinAPI.ShowWindow(ptr, Common.WinAPI.ShoWindowOptions.SW_HIDE);
                HiddenWindows.Add(ptr);
            }
            catch (Exception ex)
            {
                Global.Log(ex);
            }
        }

        internal static void CloseAll(object sender, EventArgs e)
        {
            WindowsHelper.Common.Executable.RunCmd(new string[] { "net stop \"ShrewSoft IPSEC Daemon\"", "net stop \"ShrewSoft IKE Daemon\"" }).WaitForExit();
            Application.DoEvents();
            foreach (var w in HiddenWindows)
                WindowsHelper.Common.WinAPI.ShowWindow(w, Common.WinAPI.ShoWindowOptions.SW_SHOWNORMAL);

            HiddenWindows.Clear();
        }
    }
}
