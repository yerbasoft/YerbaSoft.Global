using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSWork.DAL;

namespace CSWork.BLL.Managers
{
    public class Config : IDisposable
    {
        private Session Session;
        public DTO.GlobalConfig Global { get; set; }

        public Config(Session session)
        {
            this.Session = session;
            ReLoadGlobal();
        }

        public void ReLoadGlobal()
        {
            Global = this.Session.GetGlobalConfig();
        }

        public void SaveGlobal()
        {
            Session.Save(Global);
        }

        public void Dispose()
        {
        }
    }
}
