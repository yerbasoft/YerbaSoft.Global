using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YerbaSoft.Web.Games.Clue.Models.Site;

namespace YerbaSoft.Web.Games.Clue.Controllers
{
    public class BaseController : Controller
    {
        #region Propiedades

        private HttpSessionStateBase _Session { get; set; }
        /// <summary>
        /// Session abierta
        /// </summary>
        public new HttpSessionStateBase Session
        {
            get
            {
                return base.Session ?? this._Session;
            }
        }

        private DTO.Usuario _CurrentUser = null;
        public DTO.Usuario CurrentUser
        {
            get
            {
                return _CurrentUser = _CurrentUser ?? Models.Site.Session.GetUsuarioActivo(this.Session);
            }
            set
            {
                _CurrentUser = value;
            }
        }
        
        #endregion

        #region Constructor

        public BaseController() : base()
        {
            AutoLoadViewBagBasics();
        }
        public BaseController(HttpSessionStateBase currentSession) : base()
        {
            this._Session = currentSession;
            AutoLoadViewBagBasics();
        }

        private void AutoLoadViewBagBasics()
        {
            if (this.Session != null)
                ViewBag.CurrentUser = this.CurrentUser;
        }
        #endregion

        /// <summary>
        /// Arma un objeto a partir de los datos que existen en el Request.Form
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetFromRequest<T>(DTO.BLLServices.IService service) where T : new()
        {
            var getMethod = service.GetType().GetMethods().Where(m => m.ReturnType == typeof(T) && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(Guid)).SingleOrDefault();
            
            var dic = this.Request.Form.AllKeys.Select(p => new { key = p, value = this.Request.Form[p] }).Union(           //vars de Form
                      this.Request.QueryString.AllKeys.Select(p => new { key = p, value = this.Request.QueryString[p] })    //vars de QueryString
                      ).ToDictionary(p => p.key, p => (object)p.value);

            T dto = new T();
            if (dic.Keys.Contains("Id") && YerbaSoft.DTO.Convert.To<Guid>(dic["Id"]) != Guid.Empty)
                dto = (T)getMethod.Invoke(service, new object[] { YerbaSoft.DTO.Convert.To<Guid>(dic["Id"]) });

            var oDTO = (object)dto;
            YerbaSoft.DTO.Mapping.Map.CopyTo(dic, oDTO);
            
            return (T)oDTO;
        }

        protected void ValidateSession()
        {
            if (this.Session == null || this.CurrentUser == null)
                throw new Exception("Has sido desconectado del servidor");
        }
    }
}