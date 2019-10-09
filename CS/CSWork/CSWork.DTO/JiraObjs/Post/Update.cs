using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs.Post
{
    public class Update
    {
        public List<UpdateComment> comment { get; set; }
    }

    public class UpdateComment
    {
        public CommentHeader add { get; set; }
    }

    public class CommentHeader
    {
        public CommentObjHeader body { get; set; }
    }
}
