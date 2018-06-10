using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using WindowsHelper.Configuration;
using YerbaSoft.DTO;


namespace WindowsHelper.Memory
{
    public class Memory : WindowsHelper.Interfaces.IApp
    {
        #region Properties

        internal static System.Drawing.Icon DefaultIcon => Properties.Resources.memory;

        public const string AppName = "Memory";
        private const string ConfigFileName = "WindowsHelper.Memory.xml";
        private const string ConfigXSDFileName = "WindowsHelper.Memory.xsd";

        private App AppConfig;
        private Configuration.SubMenu Config;
        private ToolStripMenuItem HeadMenu { get; set; }

        #endregion

        public void Inicializar(App app)
        {
            RefreshConfig();

            AppConfig = app;
            Global.OnCreateMenu += OnCreateMenu;
        }

        #region External Events

        private IEnumerable<ToolStripItem> OnCreateMenu()
        {
            RefreshConfig();
            HeadMenu = new ToolStripMenuItem(AppConfig.Name, DefaultIcon.ToBitmap());

            foreach (var link in Config.Items)
                HeadMenu.DropDownItems.Add(link.GetMenu());
            
            return new ToolStripItem[] { HeadMenu };
        }

        internal void RefreshMenu()
        {
            this.HeadMenu.DropDownItems.Clear();
            OnCreateMenu();
        }

        #endregion

        #region Private Methods
        
        private void RefreshConfig()
        {
            var result = XmlHelper.ValidateXMLFromFiles(Path.Combine(WindowsHelper.Config.AppPath, ConfigFileName), Path.Combine(WindowsHelper.Config.AppPath, ConfigXSDFileName));
            if (!result.Success)
            {
                foreach (var r in result.Data)
                    Global.Log($"{r.V1} :: Configuración {ConfigFileName} :: {r.V2}");

                return;
            }

            this.Config = new YerbaSoft.DTO.ConfigurationManager(Path.Combine(WindowsHelper.Config.AppPath, ConfigFileName)).GetMainElement<Configuration.SubMenu>();
        }

        #endregion
    }
}
