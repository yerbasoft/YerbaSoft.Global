using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsHelper.Configuration;

namespace WindowsHelper.Customs
{
    public class Customs : WindowsHelper.Interfaces.IApp
    {
        internal static System.Drawing.Icon DefaultIcon => Properties.Resources.home;
        public const string AppName = "Customs";

        private App AppConfig;
        private ToolStripMenuItem HeadMenu { get; set; }

        public void Inicializar(App app)
        {
            AppConfig = app;
            WindowsHelper.Global.OnCreateMenu += OnCreateMenu;
        }

        private IEnumerable<ToolStripItem> OnCreateMenu()
        {
            HeadMenu = new ToolStripMenuItem(AppConfig.Name, DefaultIcon.ToBitmap());

            HeadMenu.DropDownItems.AddRange(
                new ToolStripMenuItem[] {
                    NewSubMenu("Open Jira", Properties.Resources.environment_view.ToBitmap(),
                        new ToolStripMenuItem[] {
                            NewMenu("Open Jira [ Ctrl + Shift + J ]", Properties.Resources.environment.ToBitmap(), JIRA.Jira.OpenJira),
                            NewMenu("Open SIRE", Properties.Resources.environment.ToBitmap(), JIRA.Jira.OpenSIRE),
                            NewMenu("Open SIRP", Properties.Resources.environment.ToBitmap(), JIRA.Jira.OpenSIRP),
                            NewMenu("Open SIRN", Properties.Resources.environment.ToBitmap(), JIRA.Jira.OpenSIRN)
                        }),
                    NewSubMenu("GCBA VPN", Properties.Resources.environment_view.ToBitmap(),
                        new ToolStripMenuItem[] {
                            NewMenu("Open All", Properties.Resources.node.ToBitmap(), GCBA.VPNConnector.OpenAll),
                            NewMenu("Close All", Properties.Resources.node_delete.ToBitmap(), GCBA.VPNConnector.CloseAll)
                        })
                }
            );

            // HOTKEYS
            Global.RegisterHotKey(Keys.J | Keys.Control | Keys.Shift, (k) => { JIRA.Jira.OpenJira(null, null); } );

            return new ToolStripItem[] { HeadMenu };
        }

        internal void RefreshMenu()
        {
            this.HeadMenu.DropDownItems.Clear();
            OnCreateMenu();
        }

        private ToolStripMenuItem NewMenu(string text, System.Drawing.Image image, EventHandler onClick)
        {
            var m = new ToolStripMenuItem(text);
            m.Image = image;
            if (onClick != null)
                m.Click += onClick;
            return m;
        }

        private ToolStripMenuItem NewSubMenu(string text, System.Drawing.Image image, ToolStripMenuItem[] submenus)
        {
            var m = NewMenu(text, image, null);

            m.DropDownItems.AddRange(submenus);

            return m;
        }

    }
}
