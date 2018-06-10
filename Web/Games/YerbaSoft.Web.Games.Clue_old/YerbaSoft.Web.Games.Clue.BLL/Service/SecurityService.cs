using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Web.Games.Clue.BLL.Service
{
    internal class SecurityService : Service, DTO.BLLServices.ISecurityService
    {
        public SecurityService(DTO.Usuario currentUser) : base(currentUser) { }

        public DTO.Usuario GetUsuario(Guid id)
        {
            return Map.Get<DTO.Usuario>(this.Session.Usuario.Find(p => p.Id == id).SingleOrDefault());
        }

        public DTO.Usuario GetUsuario(string login, string password)
        {
            return Map.Get<DTO.Usuario>(this.Session.Usuario.Find(p => p.Login == login && p.Password == password).SingleOrDefault());
        }

        public void Insert(DTO.Usuario dto, string password)
        {
            var db = Map.Get<DAL.DTO.Usuario>(dto);
            db.Id = Guid.NewGuid();
            db.Password = password;
            db.Logo = dto.Sexo == 'M' ? "man.png" : "woman.png";
            this.Session.Usuario.UpsertEntity(db);
            this.Session.Commit();
        }

        public YerbaSoft.DTO.Result<DTO.Usuario> Update(DTO.Usuario dto)
        {
            try
            {
                var db = this.Session.Usuario.Find(p => p.Id == dto.Id).Single();
                Map.CopyTo(dto, db);
                this.Session.Usuario.UpsertEntity(db);
                this.Session.Commit();
                return new YerbaSoft.DTO.Result<DTO.Usuario>(Map.Get<DTO.Usuario>(db));
            }
            catch (Exception ex)
            {
                return new YerbaSoft.DTO.Result<DTO.Usuario>(ex);
            }
        }
    }
}
