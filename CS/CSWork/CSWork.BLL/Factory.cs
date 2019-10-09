using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSWork.BLL
{
    public static class Factory
    {
        public const string GetTokenUrl = "https://id.atlassian.com/manage/api-tokens";
        
        // Managers
        public static Managers.Config Config { get; private set; }
        public static Managers.Cache Cache { get; private set; }
        public static Managers.Jira Jira { get; private set; }
        public static Managers.Working Work { get; private set; }

        public static void Inicializar()
        {
            var session = new DAL.Session();
            Config = new Managers.Config(session);
            Cache = new Managers.Cache(session, Config);

            Jira = new Managers.Jira(session, Config);
            Work = new Managers.Working(session, Config);
        }

        public static void Dispose()
        {
            Work.Dispose();
            Jira.Dispose();
            Cache.Dispose();
            Config.Dispose();
        }
    }
}
