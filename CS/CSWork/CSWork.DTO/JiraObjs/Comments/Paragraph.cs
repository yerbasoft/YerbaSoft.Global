using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs.Comments
{
    public class Paragraph : IContent
    {
        public string type => "paragraph";
        public List<IContent> content { get; set; }

        public Paragraph() { }
        public Paragraph(params IContent[] contents)
        {
            this.content = contents.ToList();
        }
    }
}
