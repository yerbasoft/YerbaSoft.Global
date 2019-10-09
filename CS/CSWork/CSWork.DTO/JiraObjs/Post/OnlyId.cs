using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs.Post
{
    public class OnlyId
    {
        public string id { get; set; }

        public OnlyId() { }
        public OnlyId(string value)
        {
            this.id = value;
        }
    }
}
