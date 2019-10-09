using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using CSWork.DTO.WorkDatas;

namespace CSWork.BLL.Managers
{
    public class Cache : ManagerBase, IDisposable
    {
        public event Event<Issue, IEnumerable<Issue.Changes>> OnIssueChangeData;
        private Dictionary<Issue, Thread> Issues { get; set; } = new Dictionary<Issue, Thread>();

        public Cache(DAL.Session dal, Config config) : base(dal, config) { }
        public void Dispose()
        {
            lock (this.Issues)
            {
                foreach(var dto in this.Issues)
                    dto.Value.Abort();

                this.Issues.Clear();
            }
        }

        public void Add(List<Issue> dtos)
        {
            foreach (var dto in dtos)
                Add(dto);
        }
        public Issue Add(Issue dto)
        {
            Issue exists;
            lock (this.Issues)
                exists = this.Issues.Keys.Where(p => p.Key == dto.Key).SingleOrDefault();

            if (exists != null)
                return exists;

            dto.OnChangeData += (i, e) => OnIssueChangeData?.Invoke(i, e);
            var thread = new Thread(_RefreshIssue) { Priority = ThreadPriority.Lowest };
            lock (this.Issues)
                this.Issues.Add(dto, thread);
            thread.Start(dto);

            return dto;
        }

        public void Remove(Issue dto)
        {
            Issue exists;
            Thread thread = null;
            lock (this.Issues)
            {
                exists = this.Issues.Keys.Where(p => p.Key == dto.Key).SingleOrDefault();
                if (exists != null)
                    thread = this.Issues[exists];
            }

            if (exists == null)
                return;

            thread?.Abort();

            lock (this.Issues)
                this.Issues.Remove(exists);
        }

        private void _RefreshIssue(object obj)
        {
            var issue = (Issue)obj;

            do
            {
                var info = base.JiraInterface.GetIssue(issue.Key);
                var trans = base.JiraInterface.GetIssueTransitions(issue.Key);

                issue.SetLazyData(new DTO.JiraObjs.Helpers.IssueFullData(info, trans));
                                
                Thread.Sleep(2 * 60 * 1000);    // 2 minutos
            } while (true);
        }

        public void RefreshIssue(string key)
        {
            Issue[] toupdate;
            lock (this.Issues)
                toupdate = this.Issues.Where(p => p.Key.Key == key).Select(p => p.Key).ToArray();

            foreach (var upd in toupdate)
            {
                new Thread((_issue) =>
                {
                    var info = base.JiraInterface.GetIssue(((Issue)_issue).Key);
                    var trans = base.JiraInterface.GetIssueTransitions(((Issue)_issue).Key);

                    ((Issue)_issue).SetLazyData(new DTO.JiraObjs.Helpers.IssueFullData(info, trans));

                }).Start(upd);
            }
        }
    }
}
