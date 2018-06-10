using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YerbaSoft.Web.Games.Clue.Controllers
{
    public class GameController : BaseController
    {
        public ActionResult Clue()
        {
            ViewBag.IdGame = ClueController.IdGame;
            ViewBag.CurrentUser = this.CurrentUser;

            return View();
        }

        public JsonResult GetMesas(Guid idGame)
        {
            try
            {
                base.ValidateSession();

                using (var srv = BLL.Factory.GetGamesService(CurrentUser))
                {
                    return new JsonResult() { Data = new YerbaSoft.DTO.Result<DTO.Mesa[]>(srv.GetMesas(idGame)) };
                }
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        public JsonResult SendChatMessage(Guid idChat, string message)
        {
            try
            {
                base.ValidateSession();

                using (var srv = BLL.Factory.GetGamesService(CurrentUser)) { srv.SendChatMessage(idChat, this.CurrentUser, message); }

                return new JsonResult() { Data = new YerbaSoft.DTO.Result() };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        public JsonResult GetChat(Guid idChat)
        {
            try
            {
                base.ValidateSession();

                using (var srv = BLL.Factory.GetGamesService(CurrentUser))
                {
                    return new JsonResult() { Data = new YerbaSoft.DTO.Result<DTO.ChatMessage[]>(srv.GetChatMessages(idChat, this.CurrentUser)) };
                }
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        public JsonResult SetChatMessageRead(Guid idMessage)
        {
            try
            {
                base.ValidateSession();

                using (var srv = BLL.Factory.GetGamesService(CurrentUser))
                {
                    srv.SetChatMessageRead(idMessage, this.CurrentUser);
                    return new JsonResult() { Data = new YerbaSoft.DTO.Result(true) };
                }
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

    }
}