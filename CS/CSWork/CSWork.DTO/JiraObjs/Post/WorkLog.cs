using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs.Post
{
    public class WorkLog
    {
        public string started { get; set; }
        public CommentObjHeader comment { get; set; }
        public string timeSpent { get; set; }
    }
}
