using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace YerbaSoft.Web.Games.Clue.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            Models.Site.Session.SetUsuarioActivo(this.Session, null);
            ViewBag.MsgState = "none";
            return View();
        }

        [HttpPost]
        public ActionResult Acceder(string txtUserName, string txtPassword)
        {
            var res = Login(txtUserName, txtPassword);
            if (res == null)
            {
                ViewBag.MsgState = "Error";
                return View("Index");
            }
            else
            {
                return res;
            }
        }

        public ActionResult Main()
        {
            ViewBag.CurrentUser = this.CurrentUser;
            ViewBag.Games = YerbaSoft.Web.Games.Clue.BLL.Factory.GetGamesService(this.CurrentUser).GetGames();

            return View();
        }
                        
        private ActionResult Login(string login, string password)
        {
            using (var srv = BLL.Factory.GetSecurityService(null))
            {
                var user = srv.GetUsuario(login, password);

                if (user == null)
                    return null;

                FormsAuthentication.SetAuthCookie(user.Login, true);
                Models.Site.Session.SetUsuarioActivo(this.Session, user);

                return RedirectToAction("Main");
            }
        }
    }
}