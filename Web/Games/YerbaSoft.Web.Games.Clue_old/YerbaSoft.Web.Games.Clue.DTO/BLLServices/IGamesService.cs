using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Web.Games.Clue.DTO.BLLServices
{
    public interface IGamesService : IService, IDisposable
    {
        DTO.Game[] GetGames();
        DTO.Mesa[] GetMesas(Guid idGame);
        void CreateMesa(Guid idGame, Guid idOwner, string nombre);
        void MesaAddUser(Guid idMesa, Guid idUser);
        void MesaRemove(Guid idMesa);
        void MesaRemoveUser(Guid idMesa, Guid idUser);
        ChatMessage[] GetChatMessages(Guid idChat, Usuario user);
        void SendChatMessage(Guid idChat, Usuario user, string message);
        void SetChatMessageRead(Guid idMessage, Usuario user);
    }
}
