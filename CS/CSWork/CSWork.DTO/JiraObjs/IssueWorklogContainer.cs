using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs
{
    public class IssueWorklogContainer : Base.IJiraObject
    {
        public int startAt { get; set; }
        public int maxResult { get; set; }
        public int total { get; set; }
        public List<Worklog> worklogs { get; set; }
    }
}
