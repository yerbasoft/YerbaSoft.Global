using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YerbaSoft.Web.Games.Clue.Models.Site
{
    public class Session
    {
        private const string USER_ACTIVE = ".USER.ACTIVE.";
        private const string PUSHPOP_DATA = ".USER.POSHPOP.";

        /// <summary>
        /// Establece el usuario activo (logueado) en la session
        /// </summary>
        /// <param name="session">session actual</param>
        /// <param name="user">objeto Usuario</param>
        internal static void SetUsuarioActivo(HttpSessionStateBase session, DTO.Usuario user)
        {
            session[USER_ACTIVE] = user;
        }

        /// <summary>
        /// Devuelve el usuario activo de la session
        /// </summary>
        /// <param name="session">session actual</param>
        /// <returns></returns>
        public static DTO.Usuario GetUsuarioActivo(HttpSessionStateBase session)
        {
            return (DTO.Usuario)session[USER_ACTIVE];
        }


        /// <summary>
        /// Establece el usuario activo (logueado) en la session
        /// </summary>
        /// <param name="session">session actual</param>
        /// <param name="data">objeto a guardar en la session temporalmente</param>
        internal static Guid Push(HttpSessionStateBase session, object data)
        {
            var id = Guid.NewGuid();
            session.Add(PUSHPOP_DATA + id.ToString(), data);
            return id;
        }

        /// <summary>
        /// Devuelve un objeto guardado temporalmente en la sessión
        /// </summary>
        /// <param name="session">session actual</param>
        /// <returns></returns>
        public static object Pop(HttpSessionStateBase session, Guid id)
        {
            var obj = session[PUSHPOP_DATA + id];
            session.Remove(PUSHPOP_DATA + id);
            return obj;
        }

        /// <summary>
        /// Devuelve un objeto guardado temporalmente en la sessión
        /// </summary>
        /// <param name="session">session actual</param>
        /// <returns></returns>
        public static T Pop<T>(HttpSessionStateBase session, Guid id)
        {
            return (T)Pop(session, id);
        }
    }
}