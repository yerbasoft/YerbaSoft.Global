using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsHelper.Common
{
    public class Executable
    {
        public static Process RunExe(string exeFullPath, string arguments)
        {
            var pi = new ProcessStartInfo(exeFullPath)
            {
                WorkingDirectory = System.IO.Path.GetDirectoryName(exeFullPath),
                Arguments = arguments
            };
            return Process.Start(pi);
        }

        public static Process RunCmd(string[] commands)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = false;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            foreach (var c in commands)
            {
                cmd.StandardInput.WriteLine(c.Trim());
                cmd.StandardInput.Flush();

                Application.DoEvents();
            }
            cmd.StandardInput.Close();

            //Global.Log(cmd.StandardOutput.ReadToEnd());

            return cmd;
        }
    }
}
