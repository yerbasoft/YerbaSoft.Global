using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs
{
    public class IssueComment : Base.IJiraObject
    {
        public string self { get; set; }
        public string id { get; set; }
        public Comment body { get; set; }
        public Author author { get; set; }
        public Author updateAuthor { get; set; }
        public DateTime? created { get; set; }
        public DateTime? updated { get; set; }
        public bool jsdPublic { get; set; }
    }
}
