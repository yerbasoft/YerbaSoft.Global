using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YerbaSoft.Web.Games.Clue.WebAPI.Controllers
{
    public class GameController : BaseController
    {
        [HttpPost]
        public JsonResult GetGames()
        {
            try
            {
                if (this.SecurityToken.IsValid().ExistsErrorMessages) return new JsonResult() { Data = Common.Result.AUTHENTICATE_FAIL };

                return new JsonResult() { Data = this.SecurityService.GetGames(SecurityToken.IdUser) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

    }
}