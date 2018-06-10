using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;
using YerbaSoft.Web.Games.Clue.DTO;
using YerbaSoft.Web.Games.Clue.DTO.BLLServices;

namespace YerbaSoft.Web.Games.Clue.BLL.Service
{
    internal class GamesService : Service, DTO.BLLServices.IGamesService
    {
        public GamesService(DTO.Usuario currentUser) : base(currentUser) { }
        
        public void CreateMesa(Guid idGame, Guid idOwner, string nombre)
        {
            if (this.Session.Mesa.Any(p => p.IdOwner == idOwner))
                throw new ApplicationException("Ya tenés otra mesa creada");

            if (this.Session.Mesa.Any(p => p.Integrantes.Any(i => i.Id == idOwner)))
                throw new ApplicationException("Ya estás en otra mesa");

            var db = this.Session.Mesa.GetNew();
            db.Id = Guid.NewGuid();
            db.IdOwner = idOwner;
            db.IdGame = idGame;
            db.Nombre = nombre;

            db.Integrantes = new List<DAL.DTO.Usuario>();
            db.Integrantes.Add(Map.Get<DAL.DTO.Usuario>(CurrentUser));

            this.Session.Mesa.UpsertEntity(db);
            this.Session.Commit();
        }
        
        public DTO.Game[] GetGames()
        {
            return this.Session.Game.Find().Select(p => Map.Get<DTO.Game>(p)).ToArray();
        }

        public DTO.Mesa[] GetMesas(Guid idGame)
        {
            var mesas = this.Session.Mesa.Find(p => p.IdGame == idGame).Select(p => Map.Get<DTO.Mesa>(p)).ToArray();
            
            return mesas;
        }

        public void MesaAddUser(Guid idMesa, Guid idUser)
        {
            if (!(idUser == new Guid("00000000-0000-0000-0000-000000000001") || idUser == new Guid("00000000-0000-0000-0000-000000000002") || idUser == new Guid("00000000-0000-0000-0000-000000000002")))
            {
                if (this.Session.Mesa.Any(m => m.Integrantes.Any(i => i.Id == idUser)))
                    throw new ApplicationException("Ya te encontrás en otra mesa");
            }
            var mesa = this.Session.Mesa.Find(p => p.Id == idMesa).SingleOrDefault();
            if (mesa == null)
                return; //mesa ya cerrada
            
            mesa.Integrantes.Add(this.Session.Usuario.Find(p => p.Id == idUser).Single());
            this.Session.Mesa.UpsertEntity(mesa);
            this.Session.Commit();
        }

        public void MesaRemove(Guid idMesa)
        {
            var mesa = this.Session.Mesa.Find(p => p.Id == idMesa).SingleOrDefault();
            if (mesa == null)
                return;

            this.Session.Mesa.DeleteEntity(mesa);
            this.Session.Commit();
        }

        public void MesaRemoveUser(Guid idMesa, Guid idUser)
        {
            var mesa = this.Session.Mesa.Find(p => p.Id == idMesa).SingleOrDefault();
            if (mesa == null)
                return;

            var user = mesa.Integrantes.SingleOrDefault(p => p.Id == idUser);
            if (user == null)
                return;

            mesa.Integrantes.Remove(user);
            this.Session.Mesa.UpsertEntity(mesa);
            this.Session.Commit();
        }

        public void SendChatMessage(Guid idChat, Usuario user, string message)
        {
            var msg = new DAL.DTO.ChatMessage()
            {
                Id = Guid.NewGuid(),
                IdChat = idChat,
                Fecha = DateTime.Now.ToString("yyyyMMdd"),
                Hora = DateTime.Now.ToString("HH:mm"),
                IdUser = user.Id,
                Order = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")),
                Message = message,
                UserLogo = user.Logo,
                UserName = user.Nombre,
                Viewers = ""
            };
            this.Session.ChatMessage.UpsertEntity(msg);
            this.Session.Commit();
        }

        public ChatMessage[] GetChatMessages(Guid idChat, Usuario user)
        {
            var result = new List<ChatMessage>();
            var lastUser = Guid.Empty;
            foreach(var msg in this.Session.ChatMessage.Find(p => p.IdChat == idChat && (p.Viewers == null || !p.Viewers.Split(';').Contains(user.Id.ToString()))).OrderBy(p => p.Order))
            {
                var txt = $"<img src=\"../Content/UserProfiles/{msg.UserLogo}\" heigth=\"20px\" width=\"20px\" />{msg.UserName}: [{msg.Hora}] {msg.Message} <br />";

                result.Add(new ChatMessage() { IdMessage = msg.Id, HTMLMessage = txt });
            }
            return result.ToArray();
        }

        public void SetChatMessageRead(Guid idMessage, Usuario user)
        {
            var msg = this.Session.ChatMessage.Find(p => p.Id == idMessage).Single();

            msg.Viewers = $"{msg.Viewers ?? ""};{user.Id}";

            this.Session.ChatMessage.UpsertEntity(msg);
            this.Session.Commit();
        }
    }
}
