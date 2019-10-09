using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSWork.DAL;
using CSWork.DTO.JiraObjs;

namespace CSWork.BLL.Managers
{
    public class Jira : ManagerBase, IDisposable
    {
        public new DTO.GlobalConfigs.Jira Config => base.Config.Global.Jira;

        public Jira(Session dal, Managers.Config config) : base(dal, config) { }
        public void Dispose() { }
        
        public bool SetJiraConnection(string url, string user, string token)
        {
            url = url ?? "https://cardinalconsulting.atlassian.net";

            var jira = new JiraInterface.Interface(url, user, token);
            var valid = (jira.GetProjects()?.Count ?? 0) > 0;
            if (valid || (url == null))
            {
                base.JiraInterface = jira;
                base.Config.Global.Jira.Url = url;
                base.Config.Global.Jira.User = user;
                base.Config.Global.Jira.Token = token;
                base.Config.SaveGlobal();
            }
            return valid;
        }

        public DTO.JiraObjs.Filter GetFilter(int code)
        {
            return base.JiraInterface.GetFilter(code);
        }

        public IEnumerable<DTO.JiraObjs.Issue> Search(string filterSearchUrl, bool allfields)
        {
            return base.JiraInterface.Get<SearchIssues>(filterSearchUrl + (allfields ? "&fields=*all&maxResults=100" : "")).issues;
        }

        public IEnumerable<DTO.JiraObjs.Transition> GetIssueTransitions(string key)
        {
            return base.JiraInterface.GetIssueTransitions(key).transitions;
        }

        public DTO.JiraObjs.Issue GetIssue(string key)
        {
            return base.JiraInterface.GetIssue(key);
        }

        public IEnumerable<DTO.JiraObjs.Filter> GetFilters()
        {
            return base.JiraInterface.GetFilters();
        }

        public void IssueTransition(string issueKey, string transitionId, CommentObjHeader comment = null)
        {
            base.JiraInterface.IssueTransition(issueKey, transitionId, comment);
        }

        public Issue CreateIssue(DTO.JiraObjs.Post.IssueNew model)
        {
            return base.JiraInterface.CreateIssue(model);
        }

        public void CreateLink(string inward, string outward, string type)
        {
            base.JiraInterface.CreateLink(new DTO.JiraObjs.Post.LinkNew(inward, outward, type));
        }

        private void AddWork(string key, CommentObjHeader comment, string time, string fecha)
        {
            base.JiraInterface.AddWork(key, comment, time, fecha);
        }

        public Issue AddWork(Issue issue, CommentObjHeader comment, string time, DateTime fecha, Issue workIssue = null)
        {
            string key = workIssue?.key;
            if (workIssue == null)
            {
                // si no lo tengo lo busco
                var work = issue.fields.issuelinks.FirstOrDefault(obj =>
                                    (obj.type.id == BLL.Factory.Config.Global.Work.Clonning.IdLinkType &&
                                    obj.inwardIssue?.fields?.issuetype?.id == BLL.Factory.Config.Global.Work.Clonning.IdIssueType)
                );

                // si no existe, lo creo
                if (work == null)
                {
                    var obj = issue.ToIssueNew();
                    obj.fields.summary = $"{BLL.Factory.Config.Global.Work.Clonning.SummaryPrefix}{issue.key} :: {issue.fields.summary}";
                    obj.fields.project.id = BLL.Factory.Config.Global.Work.Clonning.IdProyect;
                    obj.fields.issuetype.id = BLL.Factory.Config.Global.Work.Clonning.IdIssueType;

                    // creo el issue
                    key = BLL.Factory.Jira.CreateIssue(obj).key;

                    // Mete el link entre issues
                    BLL.Factory.Jira.CreateLink(key, issue.key, BLL.Factory.Config.Global.Work.Clonning.IdLinkType);

                    BLL.Factory.Cache.RefreshIssue(key);
                }
                else
                {
                    key = work.inwardIssue?.key;
                }
            }

            BLL.Factory.Jira.AddWork(key, comment, time, fecha.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'+0000'"));

            return workIssue;
        }
    }
}
