using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YerbaSoft.Web.Games.Clue.WebAPI.Controllers
{
    public class ClueController : BaseController
    {
        [HttpPost]
        public JsonResult GetMesas()
        {
            try
            {
                if (this.SecurityToken.IsValid().ExistsErrorMessages) return new JsonResult() { Data = Common.Result.AUTHENTICATE_FAIL };

                return new JsonResult() { Data = this.ClueService.GetMesas(SecurityToken.IdUser) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        [HttpPost]
        public JsonResult CreateMesa(int sillas, string tipoTableroName)
        {
            try
            {
                if (this.SecurityToken.IsValid().ExistsErrorMessages) return new JsonResult() { Data = Common.Result.AUTHENTICATE_FAIL };

                return new JsonResult() { Data = this.ClueService.CreateMesa(SecurityToken.IdUser, sillas, tipoTableroName) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        [HttpPost]
        public JsonResult AbandonarMesa()
        {
            try
            {
                if (this.SecurityToken.IsValid().ExistsErrorMessages) return new JsonResult() { Data = Common.Result.AUTHENTICATE_FAIL };

                return new JsonResult() { Data = this.ClueService.AbandonarMesa(SecurityToken.IdUser) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        [HttpPost]
        public JsonResult EnterMesa(Guid idMesa)
        {
            try
            {
                if (this.SecurityToken.IsValid().ExistsErrorMessages) return new JsonResult() { Data = Common.Result.AUTHENTICATE_FAIL };

                return new JsonResult() { Data = this.ClueService.EnterMesa(SecurityToken.IdUser, idMesa) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        [HttpPost]
        public JsonResult StartMesa(Guid idMesa)
        {
            try
            {
                if (this.SecurityToken.IsValid().ExistsErrorMessages) return new JsonResult() { Data = Common.Result.AUTHENTICATE_FAIL };

                return new JsonResult() { Data = this.ClueService.StartMesa(SecurityToken.IdUser, idMesa) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        [HttpPost]
        public JsonResult GetTipoTableroNames()
        {
            try
            {
                if (this.SecurityToken.IsValid().ExistsErrorMessages) return new JsonResult() { Data = Common.Result.AUTHENTICATE_FAIL };

                return new JsonResult() { Data = this.ClueService.GetTipoTableroNames(SecurityToken.IdUser) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        [HttpPost]
        public JsonResult GetGameInfo()
        {
            try
            {
                if (this.SecurityToken.IsValid().ExistsErrorMessages) return new JsonResult() { Data = Common.Result.AUTHENTICATE_FAIL };

                return new JsonResult() { Data = this.ClueService.GetGameInfo(SecurityToken.IdUser) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        [HttpPost]
        public JsonResult GetTablero(Guid idMesa)
        {
            try
            {
                if (this.SecurityToken.IsValid().ExistsErrorMessages) return new JsonResult() { Data = Common.Result.AUTHENTICATE_FAIL };

                return new JsonResult() { Data = this.ClueService.GetTablero(idMesa) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        [HttpPost]
        public JsonResult LeftGame(string user)
        {
            try
            {
                if (this.SecurityToken.IsValid().ExistsErrorMessages) return new JsonResult() { Data = Common.Result.AUTHENTICATE_FAIL };

                return new JsonResult() { Data = this.ClueService.LeftGame(Get<Common.DTO.User>("user")) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        [HttpPost]
        public JsonResult MoveTo(string x, string y)
        {
            try
            {
                if (this.SecurityToken.IsValid().ExistsErrorMessages) return new JsonResult() { Data = Common.Result.AUTHENTICATE_FAIL };

                return new JsonResult() { Data = this.ClueService.MoveTo(SecurityToken.IdUser, x, y) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }
    }
}