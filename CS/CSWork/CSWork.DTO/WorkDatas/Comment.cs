using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.WorkDatas
{
    public class Comment
    {
        public string Id { get; set; }
        public DateTime? ModiFecha { get; set; }

        public Comment() { }
        public Comment(JiraObjs.IssueComment obj)
        {
            this.Id = obj.id;
            this.ModiFecha = obj.updated;
        }
    }
}
