using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs.Comments
{
    public class Text : IContent
    {
        public string type => "text";
        public string text { get; set; }

        public Text() { }
        public Text(string value)
        {
            this.text = value;
        }
    }
}
