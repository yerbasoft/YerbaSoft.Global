using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.Web.Games.Clue.Common.DTO;

namespace YerbaSoft.Web.Games.Clue.BLL
{
    public class ChatService : BaseService
    {
        public DTO.Result<Clue.Common.DTO.Chat[]> GetChats(Guid idUser)
        {
            /* Crea el chat global
            var newchat = Session.ChatRepository.GetNew();
            newchat.Id = Guid.NewGuid();
            newchat.Name = "Global";
            newchat.Type = "Global";
            newchat.LastUpdate = 0;
            newchat.IconRes = "http://localhost:4200/assets/clue/ClueCard.jpg";
            newchat.Integrantes = new List<Common.DTO.ChatUser>();
            newchat.Integrantes.Add(new Common.DTO.ChatUser() { Id = Common.DTO.User.Anonimo.Id.Value, Name = Common.DTO.User.Anonimo.Name });

            Session.ChatRepository.UpsertEntity(newchat);
            Session.ChatRepository.Commit();
            */

            var data = Session.ChatRepository.Find(p => p.Integrantes.Any(i => i.Id == idUser || i.Id == Common.DTO.User.Anonimo.Id));
            return new DTO.Result<Common.DTO.Chat[]>(data.OrderByDescending(p => p.LastUpdate).ToArray());
        }

        public DTO.Result AddChatLine(Guid idUser, Guid idchat, string userName, string text)
        {
            var repo = Session.GetXMLRepository<Common.DTO.ChatLine>($"Chat_{idchat}.xml");
            var fechahora = DateTime.Now.Ticks;

            var dbLine = repo.GetNew();
            dbLine.IdUser = idUser;
            dbLine.UserName = userName;
            dbLine.Text = text;
            dbLine.Fecha = fechahora;
            repo.UpsertEntity(dbLine);
            repo.Commit();

            var dbChat = Session.ChatRepository.Find(p => p.Id == idchat).SingleOrDefault();
            dbChat.LastUpdate = fechahora;
            Session.ChatRepository.UpsertEntity(dbChat);
            Session.ChatRepository.Commit();
            return new DTO.Result(true);
        }

        public DTO.Result<ChatNews[]> GetNews(Guid iduser)
        {
            var fechahora = DateTime.Now.Ticks;

            var db = Session.ChatUserUpdatesRepository.Find(p => p.IdUser == iduser).SingleOrDefault();

            if (db == null)
            {
                db = Session.ChatUserUpdatesRepository.GetNew();
                db.IdUser = iduser;
                db.LastUpdate = DateTime.Now.AddDays(-5).Ticks;
            }

            var chats = Session.ChatRepository.Find(p => p.LastUpdate > db.LastUpdate && p.Integrantes.Any(i => i.Id == iduser || i.Id == Common.DTO.User.Anonimo.Id));

            var result = new List<ChatNews>();
            foreach (var chat in chats)
            {
                var repo = Session.GetXMLRepository<Common.DTO.ChatLine>($"Chat_{chat.Id}.xml");
                var lines = repo.Find(p => p.Fecha > db.LastUpdate).OrderByDescending(p => p.Fecha);

                result.AddRange(lines.Select(p => new ChatNews() { IdChat = chat.Id, ChatLine = p }));
            }

            db.LastUpdate = fechahora;
            Session.ChatUserUpdatesRepository.UpsertEntity(db);
            Session.ChatUserUpdatesRepository.Commit();

            return new DTO.Result<ChatNews[]>(result.ToArray());
        }
    }
}
