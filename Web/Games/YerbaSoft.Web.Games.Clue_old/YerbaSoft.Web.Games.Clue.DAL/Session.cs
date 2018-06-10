
using YerbaSoft.DAL;
using YerbaSoft.DAL.Repositories;

namespace YerbaSoft.Web.Games.Clue.DAL
{
    public class Session
    {
        private string XmlFilePath { get; set; }
        private string XmlChatFilePath { get; set; }
        public Session(string xmlFilePath, string xmlChatFilePath)
        {
            this.XmlFilePath = xmlFilePath;
            this.XmlChatFilePath = xmlChatFilePath;
        }

        private IRepository<DAL.DTO.ChatMessage> _ChatMessage;
        public IRepository<DAL.DTO.ChatMessage> ChatMessage { get { return _ChatMessage = _ChatMessage ?? new XmlSimpleRepository<DAL.DTO.ChatMessage>(this.XmlChatFilePath); } }

        private IRepository<DAL.DTO.Mesa> _Mesa;
        public IRepository<DAL.DTO.Mesa> Mesa { get { return _Mesa = _Mesa ?? new MemoryRepository<DAL.DTO.Mesa>(); } }

        private IRepository<DAL.DTO.MesaUsuario> _MesaUsuario;
        public IRepository<DAL.DTO.MesaUsuario> MesaUsuario { get { return _MesaUsuario = _MesaUsuario ?? new MemoryRepository<DAL.DTO.MesaUsuario>(); } }

        private IRepository<DAL.DTO.Usuario> _Usuario;
        public IRepository<DAL.DTO.Usuario> Usuario { get { return _Usuario = _Usuario ?? new XmlSimpleRepository<DAL.DTO.Usuario>(this.XmlFilePath); } }

        private IRepository<DAL.DTO.Game> _Game;
        public IRepository<DAL.DTO.Game> Game { get { return _Game = _Game ?? new XmlSimpleRepository<DAL.DTO.Game>(this.XmlFilePath); } }

        private IRepository<DAL.DTO.Tablero> _Tablero;
        public IRepository<DAL.DTO.Tablero> Tablero { get { return _Tablero = _Tablero ?? new MemoryRepository<DAL.DTO.Tablero>(); } }

        public void Commit()
        {
            Usuario.Commit();
            Game.Commit();
            ChatMessage.Commit();
        }

        public void RollBack()
        {
            Usuario.RollBack();
            Game.RollBack();
        }
    }
}
