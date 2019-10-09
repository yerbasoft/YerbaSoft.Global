using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSWork.DAL;

namespace CSWork.BLL.Managers
{
    public class Working : ManagerBase, IDisposable
    {
        public event EventHandler OnWorkingIssuesListChange;

        private DTO.WorkData Data { get; set; }

        public Working(Session dal, Config config) : base(dal, config)
        {
            this.Data = dal.GetWorkData();

            BLL.Factory.Cache.OnIssueChangeData += (i, changes) => { base.Session.Save(this.Data); };
            BLL.Factory.Cache.Add(this.Data.Issues);
        }

        public void Dispose() { }

        public void StartIssue(DTO.JiraObjs.Issue issue)
        {
            var dto = new DTO.WorkDatas.Issue(issue);
            lock (Data.Issues)
            {
                Data.Issues.Add(dto);
            }
            this.Session.Save(this.Data);
            OnWorkingIssuesListChange?.Invoke(this, null);

            BLL.Factory.Cache.Add(dto);
        }

        public bool IsWorkingOn(string key)
        {
            lock (Data.Issues)
            {
                return Data.Issues.Any(p => p.Key == key);
            }
        }

        public DTO.WorkDatas.Issue[] GetWorkingOn()
        {
            lock (Data.Issues)
            {
                return Data.Issues.ToArray();
            }
        }
    }
}
