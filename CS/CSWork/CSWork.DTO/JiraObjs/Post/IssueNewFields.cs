using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs.Post
{
    public class IssueNewFields
    {
        public OnlyId priority { get; set; }
        public OnlyId assignee { get; set; }
        public List<OnlyId> components { get; set; }
        public CommentObjHeader description { get; set; }
        public OnlyId issuetype { get; set; }
        public OnlyId project { get; set; }
        public string summary { get; set; }

        public static IssueNewFields Get(IssueFields ori)
        {
            return new IssueNewFields()
            {
                assignee = new OnlyId(ori.assignee.accountId),
                issuetype = new OnlyId(ori.issuetype.id),
                components = ori.components.Select(p => new OnlyId(p.id)).ToList(),
                project = new OnlyId(ori.project.id),
                description = new CommentObjHeader() { type = "doc", version = 1, content = new Comments.IContent[] { new Comments.Paragraph(new Comments.Text("Clonacion de original")) }.ToList() },
                priority = new OnlyId(ori.priority.id),
                summary = ori.summary
            };
        }
    }
}
