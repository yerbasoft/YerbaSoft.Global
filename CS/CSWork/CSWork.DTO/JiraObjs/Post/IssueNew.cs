using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs.Post
{
    public class IssueNew
    {
        public IssueNewFields fields { get; set; }

        public static IssueNew Get(Issue ori)
        {
            return new IssueNew()
            {
                fields = IssueNewFields.Get(ori.fields)
            };
        }
    }
}
