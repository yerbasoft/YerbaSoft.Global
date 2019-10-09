using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSWork.BLL.Managers
{
    public class ManagerBase
    {
        protected DAL.Session Session { get; private set; }
        protected Managers.Config Config { get; private set; }
        protected JiraInterface.Interface JiraInterface { get; set; }

        public ManagerBase(DAL.Session dal, Managers.Config config)
        {
            Session = dal;
            Config = config;
            JiraInterface = new JiraInterface.Interface(Config.Global.Jira.Url, Config.Global.Jira.User, Config.Global.Jira.Token);
        }
    }
}
