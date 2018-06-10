using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using WindowsHelper.Configuration;
using YerbaSoft.DTO;

namespace WindowsHelper.EasyOpen
{
    public class EasyOpen : Interfaces.IApp
    {
        #region Properties

        internal static System.Drawing.Icon DefaultIcon => Properties.Resources.EasyOpen;

        public const string AppName = "Easy Open";
        private const string ConfigFileName = "WindowsHelper.EasyOpen.xml";
        private const string ConfigXSDFileName = "WindowsHelper.EasyOpen.xsd";
        
        private App AppConfig;
        private Configuration.SubMenu EasyOpenConfig;
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

            foreach (var link in EasyOpenConfig.Items)
                HeadMenu.DropDownItems.Add(link.GetMenu());
            /*
            var add = new ToolStripMenuItem("Agregar", DefaultIcon.ToBitmap());
            add.Click += OnAddClick;
            HeadMenu.DropDownItems.Insert(0, add);
            HeadMenu.DropDownItems.Insert(1, new ToolStripSeparator());
            */
            return new ToolStripItem[] { HeadMenu };
        }

        internal void RefreshMenu()
        {
            this.HeadMenu.DropDownItems.Clear();
            OnCreateMenu();
        }

        #endregion

        #region Private Methods

        private void OnAddClick(object sender, EventArgs e)
        {
            Global.Log($"{AppName} :: Nuevo Link");

            var frm = new Forms.Admin(Path.Combine(Config.AppPath, ConfigFileName), this);
            frm.Icon = Properties.Resources.EasyOpen;
            frm.Show();
        }
        
        private void RefreshConfig()
        {
            var result = XmlHelper.ValidateXMLFromFiles(Path.Combine(Config.AppPath, ConfigFileName), Path.Combine(Config.AppPath, ConfigXSDFileName));
            if (!result.Success)
            {
                foreach (var r in result.Data)
                    Global.Log($"{r.V1} :: Configuración {ConfigFileName} :: {r.V2}");

                //return; // no cancelo la carga
            }

            this.EasyOpenConfig = new YerbaSoft.DTO.ConfigurationManager(Path.Combine(Config.AppPath, ConfigFileName)).GetMainElement<Configuration.SubMenu>();
        }

        #endregion
    }
}
