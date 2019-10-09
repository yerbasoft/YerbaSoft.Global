using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs
{
    public class CommentObjHeader
    {
        public int version { get; set; }
        public string type { get; set; }
        public List<Comments.IContent> content { get; set; }
    }
    public class CommentObj : Comments.IContent
    {
        public string type { get; set; }
        public List<CommentObj> content { get; set; }
        public List<CommentObj> marks { get; set; } = new List<CommentObj>();
        public CommentObj attrs { get; set; }

        // propiedades opcionales según el "type"
        public string text { get; set; }
        public int level { get; set; }
        public string color { get; set; }
        public string panelType { get; set; }
        public int order { get; set; }
        public string title { get; set; }
        public string href { get; set; }
        public string url { get; set; }
    }

    public class Comment : Base.IJiraObject
    {
        public string version { get; set; }
        public string type { get; set; }
        public object content { get; set; }
    }
}
