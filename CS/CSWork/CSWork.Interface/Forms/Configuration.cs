using CSWork.Interface.Model;
using CSWork.Interface.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSWork.Interface.Forms
{
    public partial class Configuration : Form
    {
        public class ResultType
        {
            public bool ReValidUser { get; set; }
            public bool ReLoadMemoryMenu { get; internal set; }
            public bool ReLoadAmbientesMenu { get; internal set; }
            public bool ReLoadAlarmaMenu { get; internal set; }
            public bool ReLoadWorkMenu { get; internal set; }
            public bool ReLoadLinksMenu { get; internal set; }
        }

        public enum ConfigurationTabs
        {
            General,
            Jira,
            Memory,
            GCBA,
            Working, 
            Alarmas,
            Links
        }

        private Model.Configuration.ConfigGeneralHelper ConfigGeneralHelper { get; set; }
        private Model.Configuration.ConfigJiraHelper ConfigJiraHelper { get; set; }
        private Model.Configuration.ConfigMemoryHelper ConfigMemoryHelper { get; set; }
        private Model.Configuration.ConfigGCBAHelper ConfigGCBAHelper { get; set; }
        private Model.Configuration.ConfigWorkingHelper ConfigWorkingHelper { get; set; }
        private Model.Configuration.ConfigAlarmasHelper ConfigAlarmasHelper { get; set; }
        private Model.Configuration.ConfigLinksHelper ConfigLinksHelper { get; set; }

        public ResultType Result { get; internal set; } = new ResultType();

        public Configuration()
        {
            InitializeComponent();
            this.Icon = Resources.nut_and_bolt;

            this.ConfigGeneralHelper = new Model.Configuration.ConfigGeneralHelper(this, tabGeneral);
            this.ConfigJiraHelper = new Model.Configuration.ConfigJiraHelper(this, tabJira);
            this.ConfigMemoryHelper = new Model.Configuration.ConfigMemoryHelper(this, tabMemory);
            this.ConfigGCBAHelper = new Model.Configuration.ConfigGCBAHelper(this, tabGCBA);
            this.ConfigWorkingHelper = new Model.Configuration.ConfigWorkingHelper(this, tabWork);
            this.ConfigAlarmasHelper = new Model.Configuration.ConfigAlarmasHelper(this, tabAlarmas);
            this.ConfigLinksHelper = new Model.Configuration.ConfigLinksHelper(this, tabLinks);

            // íconos de Tab
            images.Images.Add("General", Resources.bookmark);
            images.Images.Add("Jira", Resources.key1_preferences);
            images.Images.Add("Memory", Resources.note);
            images.Images.Add("GCBAAmbientes", Resources.data);
            images.Images.Add("Working", Resources.media_play);
            images.Images.Add("Alarmas", Resources.alarmclock);
            images.Images.Add("Links", Resources.link);
            tabGeneral.ImageKey = "General";
            tabJira.ImageKey = "Jira";
            tabMemory.ImageKey = "Memory";
            tabGCBA.ImageKey = "GCBAAmbientes";
            tabWork.ImageKey = "Working";
            tabAlarmas.ImageKey = "Alarmas";
            tabLinks.ImageKey = "Links";
        }

        public Configuration SetTab(ConfigurationTabs t, bool exclusive)
        {
            switch(t)
            {
                case ConfigurationTabs.General:
                    tab.SelectedTab = tabGeneral;
                    break;
                case ConfigurationTabs.Jira:
                    tab.SelectedTab = tabJira;
                    break;
                case ConfigurationTabs.Memory:
                    tab.SelectedTab = tabMemory;
                    break;
                case ConfigurationTabs.GCBA:
                    tab.SelectedTab = tabGCBA;
                    break;
                case ConfigurationTabs.Working:
                    tab.SelectedTab = tabWork;
                    break;
                case ConfigurationTabs.Alarmas:
                    tab.SelectedTab = tabAlarmas;
                    break;
                case ConfigurationTabs.Links:
                    tab.SelectedTab = tabLinks;
                    break;
            }

            if (exclusive)
            {
                foreach (var d in tab.TabPages.OfType<TabPage>().Where(p => p != tab.SelectedTab).ToArray())
                    tab.TabPages.Remove(d);
            }

            return this;
        }
    }
}
