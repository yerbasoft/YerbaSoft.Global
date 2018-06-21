using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YerbaSoft.Web.Games.Clue.WebAPI.Controllers
{
    public class ChatController : BaseController
    {
        [HttpPost]
        public JsonResult GetChats()
        {
            try
            {
                if (this.SecurityToken.IsValid().ExistsErrorMessages) return new JsonResult() { Data = Common.Result.AUTHENTICATE_FAIL };

                return new JsonResult() { Data = this.ChatService.GetChats(SecurityToken.IdUser) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        [HttpPost]
        public JsonResult AddChatLine(Guid idchat, string user, string text)
        {
            try
            {
                if (this.SecurityToken.IsValid().ExistsErrorMessages) return new JsonResult() { Data = Common.Result.AUTHENTICATE_FAIL };

                return new JsonResult() { Data = this.ChatService.AddChatLine(SecurityToken.IdUser, idchat, user, text) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        [HttpPost]
        public JsonResult GetNews()
        {
            try
            {
                if (this.SecurityToken.IsValid().ExistsErrorMessages) return new JsonResult() { Data = Common.Result.AUTHENTICATE_FAIL };

                return new JsonResult() { Data = this.ChatService.GetNews(SecurityToken.IdUser) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }
    }
}