using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs.Post
{
    public class IssueTransition
    {
        public Transition transition { get; set; } = new Transition();
        public Update update { get; set; } = new Update();

        public IssueTransition() { }
        public IssueTransition(string idTransition, CommentObjHeader comment)
        {
            this.transition.id = idTransition;
            if (comment != null)
            {
                this.update = new Update();
                this.update.comment = new List<UpdateComment>();
                this.update.comment.Add(new UpdateComment()
                {
                    add = new CommentHeader()
                    {
                        body = comment
                    }
                });
            }
        }
    }
}
