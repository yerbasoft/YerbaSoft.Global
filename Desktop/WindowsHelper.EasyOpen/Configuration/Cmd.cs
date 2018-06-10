using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsHelper.EasyOpen.Configuration
{
    internal class Cmd : EasyOpenType, YerbaSoft.DTO.Mapping.IExtraMapping
    {
        internal override string TypeName => "Cmd";

        public string Content { get; set; }

        public void ExtraMappingWhenGet(object ori, object info)
        {
            this.Content = ((XmlNode)ori).InnerText;
        }

        internal override void Run()
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = false;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            foreach(var c in Content.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                cmd.StandardInput.WriteLine(c.Trim());
                cmd.StandardInput.Flush();

                //Global.Log(cmd.StandardOutput.ReadToEnd());
                Application.DoEvents();
            }
            cmd.StandardInput.Close();
            cmd.WaitForExit();
        }
    }
}
