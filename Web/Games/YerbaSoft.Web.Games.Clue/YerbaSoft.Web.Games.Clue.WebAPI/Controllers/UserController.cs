using System;
using System.Web.Mvc;

namespace YerbaSoft.Web.Games.Clue.WebAPI.Controllers
{
    public class UserController : BaseController
    {
        [HttpPost]
        public JsonResult LogIn(string user, string pass)
        {
            try
            {
                if (this.SecurityToken.IsValid(true).ExistsErrorMessages) return new JsonResult() { Data = Common.Result.AUTHENTICATE_FAIL };

                return new JsonResult() { Data = this.SecurityService.GetToken(user, pass) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        [HttpPost]
        public JsonResult NewUser()
        {
            try
            {
                if (this.SecurityToken.IsValid(true).ExistsErrorMessages) return new JsonResult() { Data = Common.Result.AUTHENTICATE_FAIL };

                return new JsonResult() { Data = this.SecurityService.AddUser(Get<Common.DTO.User>("user")) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        [HttpPost]
        public JsonResult GetCurrentUser()
        {
            try
            {
                if (this.SecurityToken.IsValid().ExistsErrorMessages) return new JsonResult() { Data = Common.Result.AUTHENTICATE_FAIL };

                return new JsonResult() { Data = this.SecurityService.GetUser(this.SecurityToken.IdUser) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        [HttpPost]
        public JsonResult ChangePassword(string pass, string newpass)
        {
            try
            {
                if (this.SecurityToken.IsValid().ExistsErrorMessages) return new JsonResult() { Data = Common.Result.AUTHENTICATE_FAIL };

                return new JsonResult() { Data = this.SecurityService.ChangePassword(this.SecurityToken.IdUser, pass, newpass) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        [HttpPost]
        public JsonResult UpdateUser()
        {
            try
            {
                if (this.SecurityToken.IsValid().ExistsErrorMessages) return new JsonResult() { Data = Common.Result.AUTHENTICATE_FAIL };

                return new JsonResult() { Data = this.SecurityService.UpdateUser(this.SecurityToken.IdUser, Get<Common.DTO.User>("user")) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }
    }
}