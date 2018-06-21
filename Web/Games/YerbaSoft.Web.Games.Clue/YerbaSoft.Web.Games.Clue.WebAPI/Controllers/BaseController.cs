using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace YerbaSoft.Web.Games.Clue.WebAPI.Controllers
{
    public class BaseController : Controller
    {
        protected Common.DTO.SecurityToken SecurityToken { get; set; }

        private Clue.BLL.SecurityService _SecurityService { get; set; }
        protected Clue.BLL.SecurityService SecurityService => _SecurityService = _SecurityService ?? new BLL.SecurityService();

        private Clue.BLL.ChatService _ChatService { get; set; }
        protected Clue.BLL.ChatService ChatService => _ChatService = _ChatService ?? new BLL.ChatService();

        private Clue.BLL.ClueService _ClueService { get; set; }
        protected Clue.BLL.ClueService ClueService => _ClueService = _ClueService ?? new BLL.ClueService();


        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            this.SecurityToken = GetFromB64<Common.DTO.SecurityToken>(Request.Headers["auth"]) ?? Common.DTO.SecurityToken.Generate(Common.DTO.User.Anonimo.Id.Value, DateTime.Now);
        }

        /// <summary>
        /// Devuelve el objeto codificado del lado cliente
        /// </summary>
        /// <typeparam name="T">Tipo del objeto a obtener</typeparam>
        /// <param name="b64">string codificado obtenido desde el cliente</param>
        /// <returns></returns>
        protected T GetFromB64<T>(string b64)
        {
            var u64 = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(b64));
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(u64);
        }

        /// <summary>
        /// Devuelve un objeto codificado en los parámetros
        /// </summary>
        /// <typeparam name="T">tipo de objeto</typeparam>
        /// <param name="paramName">nombre del parámetro</param>
        /// <returns></returns>
        protected T Get<T>(string paramName)
        {
            return GetFromB64<T>(this.Request[paramName]);
        }
    }
}