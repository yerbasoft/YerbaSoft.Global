using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YerbaSoft.Desktop.PW
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Global.Debug = Application.StartupPath.Contains(@"bin\Debug");
            Global.Config = new YerbaSoft.DTO.ConfigurationManager("PWConfig.xml").GetMainElement<Configuration.PWConfig>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.MainForm());
        }
    }
}
