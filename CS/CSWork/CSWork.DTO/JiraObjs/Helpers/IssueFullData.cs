using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs.Helpers
{
    public class IssueFullData : Base.IJiraObject
    {
        public Issue Issue { get; set; }
        public Transitions Transitions { get; set; }

        public IssueFullData() { }
        public IssueFullData(Issue issue, Transitions transitions)
        {
            this.Issue = issue;
            this.Transitions = transitions;
        }
    }
}
