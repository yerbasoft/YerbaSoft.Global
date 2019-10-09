using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSWork.DTO.JiraObjs;

namespace CSWork.DTO.WorkDatas
{
    public class Attachment
    {
        public string Filename { get; set; }
        public string Content { get; set; }
        public string MimeType;

        public Attachment() { }
        public Attachment(JiraObjs.Attachment obj)
        {
            this.Filename = obj.filename;
            this.Content = obj.content;
            this.MimeType = obj.mimeType;
        }
    }
}
