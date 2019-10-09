using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs
{
    public class SearchFilter : Base.IJiraObject
    {
        public int maxResults { get; set; }
        public int startAt { get; set; }
        public int total { get; set; }
        public int isLast { get; set; }
        public List<Filter> values { get; set; }
    }
}
