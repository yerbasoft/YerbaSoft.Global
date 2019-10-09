using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs
{
    public class Attachment : Base.IJiraObject
    {
        public int id { get; set; }
        public string self { get; set; }
        public string filename { get; set; }
        public Author author { get; set; }
        public DateTime? created { get; set; }
        public int? size { get; set; }
        public string mimeType { get; set; }
        public string content { get; set; }
    }
}
