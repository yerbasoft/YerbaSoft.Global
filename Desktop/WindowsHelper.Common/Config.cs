using System.IO;
using WindowsHelper.Configuration;
using YerbaSoft.DTO;

namespace WindowsHelper
{
    public static class Config
    {
        private const string ConfigFileName = "WindowsHelper.xml";
        private const string ConfigXSDFileName = "WindowsHelper.xsd";
        public static string AppPath { get; private set; }
        internal static WindowsHelper.Configuration.WindowsHelper WindowsHelper { get; private set; }

        public static Applications Applications { get { return WindowsHelper?.Applications ?? new Applications(); } }

        public static void Iniciar(string appPath)
        {
            AppPath = appPath;
            Refresh();
        }

        public static void Refresh()
        {
            var result = XmlHelper.ValidateXMLFromFiles(Path.Combine(AppPath, ConfigFileName), Path.Combine(AppPath, ConfigXSDFileName));
            if (!result.Success)
            {
                foreach (var r in result.Data)
                    Global.Log($"{r.V1} :: Configuración {ConfigFileName} :: {r.V2}");

                return;
            }

            var mgr = new YerbaSoft.DTO.ConfigurationManager(Path.Combine(AppPath, ConfigFileName));
            WindowsHelper = mgr.GetMainElement<WindowsHelper.Configuration.WindowsHelper>();
        }
    }
}
