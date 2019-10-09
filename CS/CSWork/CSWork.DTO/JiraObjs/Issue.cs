using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs
{
    public class Issue : Base.IJiraObject
    {
        public string expand { get; set; }
        public int id { get; set; }
        public string self { get; set; }
        public string key { get; set; }
        public IssueFields fields { get; set; }

        public override string ToString() => $"{key} - {fields?.summary}";
        public Post.IssueNew ToIssueNew() => Post.IssueNew.Get(this);
    }
}
