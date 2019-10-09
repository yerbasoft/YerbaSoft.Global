using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs
{
    public class IssueLink : Base.IJiraObject
    {
        public string id { get; set; }
        public string self { get; set; }
        public IssueLinkType type { get; set; }
        public Issue inwardIssue { get; set; }  //carga parcialmente los datos
        public Issue outwardIssue { get; set; }  //carga parcialmente los datos
    }
}
