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

        [HttpPost]
        public JsonResult SelectNoCard(string status)
        {
            try
            {
                if (this.SecurityToken.IsValid().ExistsErrorMessages) return new JsonResult() { Data = Common.Result.AUTHENTICATE_FAIL };

                return new JsonResult() { Data = this.ClueService.SelectNoCard(SecurityToken.IdUser, status) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        [HttpPost]
        public JsonResult UseCard()
        {
            try
            {
                var card = Get<Common.DTO.Clue.Card>("card");
                var data = Get<Common.DTO.Clue.Card.DataStr>("data");

                return new JsonResult() { Data = this.ClueService.UseCard(SecurityToken.IdUser, card, data) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        [HttpPost]
        public JsonResult GetNotas()
        {
            try
            {
                if (this.SecurityToken.IsValid().ExistsErrorMessages) return new JsonResult() { Data = Common.Result.AUTHENTICATE_FAIL };

                return new JsonResult() { Data = this.ClueService.GetNotas(this.SecurityToken.IdUser) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        [HttpPost]
        public JsonResult AddNota(string nota)
        {
            try
            {
                if (this.SecurityToken.IsValid().ExistsErrorMessages) return new JsonResult() { Data = Common.Result.AUTHENTICATE_FAIL };

                return new JsonResult() { Data = this.ClueService.AddNota(this.SecurityToken.IdUser, Get<Common.DTO.Clue.Nota>(nota)) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        [HttpPost]
        public JsonResult RemoveNota(string nota)
        {
            try
            {
                if (this.SecurityToken.IsValid().ExistsErrorMessages) return new JsonResult() { Data = Common.Result.AUTHENTICATE_FAIL };

                return new JsonResult() { Data = this.ClueService.RemoveNota(this.SecurityToken.IdUser, Get<Common.DTO.Clue.Nota>(nota)) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }
    }
}