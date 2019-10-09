using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs.Comments
{
    public static class Factory
    {
        public static CommentObjHeader GetHeader(params IContent[] contents)
        {
            return new CommentObjHeader() { type = "doc", version = 1, content = contents.ToList() };
        }

        public static IContent GetParagraph(params IContent[] contents)
        {
            return new Paragraph(contents);
        }
    }
}
