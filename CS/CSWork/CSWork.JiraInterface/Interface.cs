using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSWork.DTO.JiraObjs;
using CSWork.DTO.JiraObjs.Post;

namespace CSWork.JiraInterface
{
    public class Interface
    {
        private JiraClient JiraClient { get; set; }

        public Interface(string url, string user, string pass)
        {
            JiraClient = new JiraClient(url, user, pass);
        }

        public List<DTO.JiraObjs.Project> GetProjects()
        {
            return JiraClient.Get<List<DTO.JiraObjs.Project>>("project");
        }

        public DTO.JiraObjs.Issue GetIssue(string key)
        {
            return JiraClient.Get<DTO.JiraObjs.Issue>($"issue/{key}");
        }

        public DTO.JiraObjs.Transitions GetIssueTransitions(string key)
        {
            return Get<Transitions>($"issue/{key}/transitions");
        }

        public Filter GetFilter(int code)
        {
            return JiraClient.Get<Filter>($"filter/{code}");
        }

        public IEnumerable<Filter> GetFilters()
        {
            return JiraClient.Get<List<Filter>>($"filter");
        }

        public T Get<T>(string method)
        {
            return JiraClient.Get<T>(method);
        }

        public void IssueTransition(string issueKey, string transitionId, CommentObjHeader comment)
        {
            var data = new DTO.JiraObjs.Post.IssueTransition(transitionId, comment);

            JiraClient.Post($"issue/{issueKey}/transitions", data);
        }

        public void AddComment(string issue, CommentObjHeader comment)
        {
            var data = new DTO.JiraObjs.Post.CommentHeader() { body = comment };
            JiraClient.Post($"issue/{issue}/comment", data);
        }

        public Issue CreateIssue(DTO.JiraObjs.Post.IssueNew model)
        {
            return JiraClient.Post<Issue>("issue", model);
        }

        public void CreateLink(LinkNew model)
        {
            JiraClient.Post("issueLink", model);
        }

        public void AddWork(string key, CommentObjHeader comment, string time, string fecha)
        {
            var data = new DTO.JiraObjs.Post.WorkLog() { comment = comment, timeSpent = time, started = fecha };
            JiraClient.Post($"issue/{key}/worklog", data);
        }
    }
}
