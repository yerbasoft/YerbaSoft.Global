using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs.Post
{
    public class OnlyName
    {
        public string name { get; set; }

        public OnlyName() { }
        public OnlyName(string value)
        {
            this.name = value;
        }
    }
}
