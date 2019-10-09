using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs.Post
{
    public class LinkNew
    {
        public OnlyKey inwardIssue { get; set; }
        public OnlyKey outwardIssue { get; set; }
        public OnlyId type { get; set; }

        public LinkNew() { }
        public LinkNew(string inward, string outward, string typeId)
        {
            this.inwardIssue = new OnlyKey(inward);
            this.outwardIssue = new OnlyKey(outward);
            this.type = new OnlyId(typeId);
        }
    }
}
