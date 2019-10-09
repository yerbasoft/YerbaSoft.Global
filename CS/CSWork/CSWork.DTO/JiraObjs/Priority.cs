using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs
{
    public class Priority : Base.IJiraObject
    {
        public string self { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string iconUrl { get; set; }
    }
}
