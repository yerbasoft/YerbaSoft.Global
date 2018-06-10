using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Web.Games.Clue.Common
{
    public class Result : YerbaSoft.DTO.Result
    {
        public int Code { get; set; } = 0;

        public static Result AUTHENTICATE_FAIL => new Result(1);

        public Result() : base() { }
        public Result(bool success) : base(success) { }
        public Result(Exception ex) : base(ex) { }
        public Result(MessageList messageList) : base(messageList) { }
        public Result(string error) : base(error) { }
        public Result(string message, bool iserror) : base(message, iserror) { }
        public Result(int code) : base(false) { this.Code = code; }
    }
}
