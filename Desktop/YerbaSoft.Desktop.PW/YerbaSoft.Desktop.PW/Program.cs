using System;
using System.Linq;
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
            BLL.ClientManager.Config = new YerbaSoft.DTO.ConfigurationManager("PWConfig.xml").GetMainElement<DTO.Configuration.PWCuentaConfig>();
            BLL.DataManager.Villa = new YerbaSoft.DTO.ConfigurationManager("YerbaSoft.Desktop.PW.Villa.xml").GetMainElement<DTO.Configuration.Villa.Villa>();
            var datamanager = new BLL.DataManager();
            BLL.DataManager.GoTo = datamanager.GotoRepository.Find().ToList();
            BLL.DataManager.Partys = datamanager.PartysRepository.Find().ToList(); 

            if (Application.StartupPath.Contains(@"bin\Debug"))
                BLL.ClientManager.AppIcon = "debug_run";
            else
                BLL.ClientManager.AppIcon = BLL.ClientManager.Config.AppIcon ?? "application";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.MainForm());
        }
    }
}
