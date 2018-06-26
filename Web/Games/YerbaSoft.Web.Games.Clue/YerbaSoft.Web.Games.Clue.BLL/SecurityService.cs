using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.Web.Games.Clue.Common.DTO;

namespace YerbaSoft.Web.Games.Clue.BLL
{
    public class SecurityService : BaseService
    {
        #region Users

        public DTO.Result<Clue.Common.DTO.SecurityToken> AddUser(Clue.Common.DTO.User user)
        {
            if (Session.Users.Any(p => p.UserName == user.UserName || (p.EMail == user.EMail && !string.IsNullOrEmpty(user.EMail))))
            {
                return new DTO.Result<SecurityToken>("Ya existe un usuario con el mismo nombre de usuario o e-Mail");
            }

            user.Id = Guid.NewGuid();

            Session.Users.UpsertEntity(user);
            Session.Users.Commit();

            return GetToken(user.UserName, user.Password);
        }

        public DTO.Result<Clue.Common.DTO.SecurityToken> GetToken(string user, string pass)
        {
            var dbUser = Session.Users.Find(p => p.UserName == user && p.Password == pass).SingleOrDefault();

            if (dbUser == null)
                return new DTO.Result<SecurityToken>("El usuario/contraseña no son correctos");

            var token = SecurityToken.Generate(dbUser.Id.Value, DateTime.UtcNow.AddMonths(6));
            return new DTO.Result<SecurityToken>(token);
        }

        public DTO.Result<User> GetUser(Guid idUser)
        {
            var dbUser = Session.Users.Find(p => p.Id == idUser).SingleOrDefault();

            if (dbUser == null)
                return  new DTO.Result<User>("Usuario no válido");

            return new DTO.Result<User>(dbUser);
        }

        public DTO.Result<User> ChangePassword(Guid idUser, string pass, string newpass)
        {
            var dbUser = Session.Users.Find(p => p.Id == idUser).SingleOrDefault();

            if (dbUser == null)
                return new DTO.Result<User>("Usuario no válido");

            if (dbUser.Password != pass)
                return new DTO.Result<User>("Contraseña actual no válida");

            dbUser.Password = newpass;
            Session.Users.UpsertEntity(dbUser);
            Session.Users.Commit();

            return new DTO.Result<User>(dbUser);
        }

        public DTO.Result<Clue.Common.DTO.User> UpdateUser(Guid idUser, Clue.Common.DTO.User user)
        {
            if (idUser != user.Id)
                return new DTO.Result<User>("El usuario a modificar es distinto al usuario logueado");

            var dbUser = Session.Users.Find(p => p.Id == user.Id).SingleOrDefault();

            if (dbUser == null)
                return new DTO.Result<User>("Error al obtener el usuario a modificar");

            YerbaSoft.DTO.Mapping.Map.CopyTo(user, dbUser);

            Session.Users.UpsertEntity(dbUser);
            Session.Users.Commit();

            return new DTO.Result<User>(dbUser);
        }

        #endregion

        public DTO.Result<Clue.Common.DTO.Game[]> GetGames(Guid idUser)
        {
            return new DTO.Result<Game[]>(Session.Games.Find().ToArray());
        }

    }
}
