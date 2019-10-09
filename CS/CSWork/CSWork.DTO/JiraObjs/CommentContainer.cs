using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs
{
    public class IssueCommentContainer : Base.IJiraObject
    {
        public int maxResults { get; set; }
        public int total { get; set; }
        public int startAt { get; set; }
        public List<IssueComment> comments { get; set; }
    }
}
