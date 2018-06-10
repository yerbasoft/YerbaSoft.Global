using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YerbaSoft.Web.Games.Clue.Controllers
{
    public class ClueController : BaseController
    {
        internal static Guid IdGame { get { return new Guid("00000000-0000-0000-0001-000000000000"); } }

        public JsonResult MesaNew()
        {
            try
            {
                base.ValidateSession();

                using (var srv = BLL.Factory.GetGamesService(CurrentUser)) { srv.CreateMesa(IdGame, CurrentUser.Id, "Mesa de " + CurrentUser.Nombre); }
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(true) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        public JsonResult MesaAddUser(Guid idMesa, Guid idUser)
        {
            try
            {
                base.ValidateSession();

                using (var srv = BLL.Factory.GetGamesService(CurrentUser)) { srv.MesaAddUser(idMesa, idUser); }
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(true) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        public JsonResult MesaRemove(Guid idMesa)
        {
            try
            {
                base.ValidateSession();

                using (var srv = BLL.Factory.GetGamesService(CurrentUser)) { srv.MesaRemove(idMesa); }
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(true) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        public JsonResult MesaRemoveUser(Guid idMesa, Guid idUser)
        {
            try
            {
                base.ValidateSession();

                using (var srv = BLL.Factory.GetGamesService(CurrentUser)) { srv.MesaRemoveUser(idMesa, idUser); }
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(true) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        public JsonResult MesaStart(Guid idMesa)
        {
            try
            {
                base.ValidateSession();

                using (var srv = BLL.Factory.GetClueService(CurrentUser)) { srv.MesaStart(idMesa); }
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(true) };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        public ActionResult Playing()
        {
            try
            {
                base.ValidateSession();

                using (var srv = BLL.Factory.GetClueService(CurrentUser))
                {
                    //this.ViewBag["Tablero"] = srv.GetTablero(this.CurrentUser);
                    this.ViewData["Tablero"] = srv.GetTablero(this.CurrentUser);
                }

                return View();
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

        public JsonResult GetStatus(Guid idTablero)
        {
            try
            {
                base.ValidateSession();

                using (var srv = BLL.Factory.GetClueService(CurrentUser))
                {
                    return new JsonResult() { Data = new YerbaSoft.DTO.Result<DTO.Clue.Status>(srv.GetStatus(idTablero)) };
                }
                
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }
        public JsonResult SetDados(Guid idTablero, Guid idJugador, int d1, int d2)
        {
            try
            {
                base.ValidateSession();

                using (var srv = BLL.Factory.GetClueService(CurrentUser))
                {
                    return new JsonResult() { Data = srv.SetDados(idTablero, idJugador, d1, d2) };
                }

            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new YerbaSoft.DTO.Result(ex) };
            }
        }

    }
}