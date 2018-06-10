using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsHelper.Configuration;
using YerbaSoft.DTO;

namespace WindowsHelper.Task
{
    public class Task : WindowsHelper.Interfaces.IApp
    {
        public const string AppName = "Task";
        private const string ConfigFileName = "WindowsHelper.Task.xml";
        private const string ConfigXSDFileName = "WindowsHelper.Task.xsd";

        internal static System.Drawing.Icon DefaultIcon => Properties.Resources.task;

        private App AppConfig;
        private Configuration.Tasks Config;
        private ToolStripMenuItem HeadMenu { get; set; }

        public void Inicializar(App app)
        {
            this.AppConfig = app;
            Global.OnCreateMenu += OnCreateMenu;
            
        }

        private IEnumerable<System.Windows.Forms.ToolStripItem> OnCreateMenu()
        {
            RefreshConfig();

            HeadMenu = new ToolStripMenuItem(AppConfig.Name, DefaultIcon.ToBitmap());

            foreach (var link in Config.Task)
            {
                if (!link.IsRunning)
                    link.Start();

                HeadMenu.DropDownItems.Add(link.GetMenu());
            }

            return new ToolStripItem[] { HeadMenu };
        }

        #region Private Methods

        private void RefreshConfig()
        {
            //var result = XmlHelper.ValidateXMLFromFiles(Path.Combine(WindowsHelper.Config.AppPath, ConfigFileName), Path.Combine(WindowsHelper.Config.AppPath, ConfigXSDFileName));
            //if (!result.Success)
            //{
                //foreach (var r in result.Data)
                //    Global.Log($"{r.V1} :: Configuración {ConfigFileName} :: {r.V2}");

                //return;
            //}

            this.Config = new YerbaSoft.DTO.ConfigurationManager(Path.Combine(WindowsHelper.Config.AppPath, ConfigFileName)).GetMainElement<Configuration.Tasks>();
        }

        #endregion
    }
}
