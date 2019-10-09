using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSWork.DTO
{
    public class GlobalConfig
    {
        public GlobalConfigs.Global General { get; set; } = new GlobalConfigs.Global();
        public GlobalConfigs.Jira Jira { get; set; } = new GlobalConfigs.Jira();
        public GlobalConfigs.Watch Watch { get; set; } = new GlobalConfigs.Watch();
        public List<GlobalConfigs.Memory> Memory { get; set; } = new List<GlobalConfigs.Memory>();
        public List<GlobalConfigs.Ambiente> Ambientes { get; set; } = new List<GlobalConfigs.Ambiente>();
        public GlobalConfigs.Working Work { get; set; } = new GlobalConfigs.Working();
        public GlobalConfigs.Alarmas Alarmas { get; set; } = new GlobalConfigs.Alarmas();
        public List<GlobalConfigs.Repository> Repositories { get; set; } = new List<GlobalConfigs.Repository>();
        public GlobalConfigs.Link Link { get; set; } = new GlobalConfigs.Link() { Name = "Accesos Directos", IsSubMenu = true, Icon = "link" };
    }
}
