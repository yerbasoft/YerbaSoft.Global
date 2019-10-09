using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs
{
    public class Worklog : Base.IJiraObject
    {
        public string self { get; set; }
        public Author author { get; set; }
        public Author updateAuthor { get; set; }
        public Comment comment { get; set; }
        public DateTime? created { get; set; }
        public DateTime? updated { get; set; }
        public DateTime? started { get; set; }
        public string timeSpent { get; set; }
        public int timeSpentSeconds { get; set; }
        public string id { get; set; }
        public string issueId { get; set; }
    }
}
