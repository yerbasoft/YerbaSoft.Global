using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs
{
    public class Transitions : Base.IJiraObject
    {
        public string expand { get; set; }
        public List<Transition> transitions { get; set; }
    }

    public class Transition : Base.IJiraObject
    {
        public string id { get; set; }
        public string name { get; set; }
        public Status to { get; set; }
        public bool hasScreen { get; set; }
        public bool isGlobal { get; set; }
        public bool isInitial { get; set; }
        public bool isConditional { get; set; }
    }
}
