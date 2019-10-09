using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs.Post
{
    public class OnlyKey
    {
        public string key { get; set; }

        public OnlyKey() { }
        public OnlyKey(string value)
        {
            this.key = value;
        }
    }
}
