using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Web.Games.Clue.DTO.BLLServices
{
    public interface ISecurityService : IService, IDisposable
    {
        /// <summary>
        /// Devuelve un usuario según su Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DTO.Usuario GetUsuario(Guid id);

        /// <summary>
        /// Devuelve un usuario que coincida con el usuario y contraseña
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        DTO.Usuario GetUsuario(string login, string password);

        /// <summary>
        /// Inserta un nuevo usuario
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="password"></param>
        void Insert(DTO.Usuario dto, string password);

        /// <summary>
        /// Actualiza un usuario en la db
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        YerbaSoft.DTO.Result<DTO.Usuario> Update(DTO.Usuario dto);
    }
}
