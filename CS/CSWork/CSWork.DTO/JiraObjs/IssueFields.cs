using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs
{
    public class IssueFields : Base.IJiraObject
    {
        public DateTime? statuscategorychangedate { get; set; }
        public Priority priority { get; set; }
        public List<IssueLink> issuelinks { get; set; }
        public Resolution resolution { get; set; }
        public Author assignee { get; set; }
        public Status status { get; set; }
        public List<Component> components { get; set; }
        public Author creator { get; set; }
        public Author reporter { get; set; }
        public Comment description { get; set; }
        public IssueType issuetype { get; set; }
        public Project project { get; set; }
        public List<Attachment> attachment { get; set; }
        public string summary { get; set; }
        public IssueCommentContainer comment { get; set; }
        public IssueWorklogContainer worklog { get; set; }
    }
}
