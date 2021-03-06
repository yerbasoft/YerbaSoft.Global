﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DAL.Repositories;

namespace YerbaSoft.Web.Games.Clue.DAL
{
    public class Session
    {
        private string RepositoryFilePath { get; set; }
        public Session(string repositoryFilePath)
        {
            this.RepositoryFilePath = repositoryFilePath;

            this.Clue = new ClueStr(this.RepositoryFilePath);
        }

        public ClueStr Clue { get; private set; }

        private YerbaSoft.DAL.IRepository<Clue.Common.DTO.User> _UserRepository { get; set; }
        public YerbaSoft.DAL.IRepository<Clue.Common.DTO.User> Users => _UserRepository = _UserRepository ?? new YerbaSoft.DAL.Repositories.XmlSimpleRepository<Games.Clue.Common.DTO.User>(System.IO.Path.Combine(RepositoryFilePath, Web.Games.Clue.Common.DTO.User.RepositoryName + ".xml"));

        private YerbaSoft.DAL.IRepository<Clue.Common.DTO.Game> _GameRepository { get; set; }
        public YerbaSoft.DAL.IRepository<Clue.Common.DTO.Game> Games => _GameRepository = _GameRepository ?? new YerbaSoft.DAL.Repositories.XmlSimpleRepository<Games.Clue.Common.DTO.Game>(System.IO.Path.Combine(RepositoryFilePath, Web.Games.Clue.Common.DTO.Game.RepositoryName + ".xml"));

        private YerbaSoft.DAL.IRepository<Clue.Common.DTO.Chat> _ChatRepository { get; set; }
        public YerbaSoft.DAL.IRepository<Clue.Common.DTO.Chat> Chats => _ChatRepository = _ChatRepository ?? new YerbaSoft.DAL.Repositories.XmlSimpleRepository<Games.Clue.Common.DTO.Chat>(System.IO.Path.Combine(RepositoryFilePath, Web.Games.Clue.Common.DTO.Chat.RepositoryName + ".xml"));

        public YerbaSoft.DAL.IRepository<Clue.Common.DTO.ChatUserUpdates> _ChatUserUpdatesRepository { get; set; }
        public YerbaSoft.DAL.IRepository<Clue.Common.DTO.ChatUserUpdates> ChatUserUpdates => _ChatUserUpdatesRepository = _ChatUserUpdatesRepository ?? new YerbaSoft.DAL.Repositories.MemoryRepository<Clue.Common.DTO.ChatUserUpdates>();

        public YerbaSoft.DAL.IRepository<T> GetXMLRepository<T>(string filename) where T : XmlSimpleClass, new()
        {
            return new YerbaSoft.DAL.Repositories.XmlSimpleRepository<T>(System.IO.Path.Combine(RepositoryFilePath, filename));
        }

        public class ClueStr
        {
            private string RepositoryFilePath { get; set; }
            public ClueStr(string repositoryFilePath)
            {
                this.RepositoryFilePath = repositoryFilePath;
            }

            private YerbaSoft.DAL.IRepository<Clue.Common.DTO.Clue.TipoTablero> _TipoTableroRepository { get; set; }
            public YerbaSoft.DAL.IRepository<Clue.Common.DTO.Clue.TipoTablero> TipoTableros => _TipoTableroRepository = _TipoTableroRepository ?? new YerbaSoft.DAL.Repositories.XmlSimpleRepository<Games.Clue.Common.DTO.Clue.TipoTablero>(System.IO.Path.Combine(RepositoryFilePath, Web.Games.Clue.Common.DTO.Clue.TipoTablero.RepositoryName + ".xml"));

            private YerbaSoft.DAL.IRepository<Clue.Common.DTO.Clue.Mesa> _MesaRepository { get; set; }
            public YerbaSoft.DAL.IRepository<Clue.Common.DTO.Clue.Mesa> Mesas => _MesaRepository = _MesaRepository ?? new YerbaSoft.DAL.Repositories.MemoryRepository<Games.Clue.Common.DTO.Clue.Mesa>();

            private YerbaSoft.DAL.IRepository<Clue.Common.DTO.Clue.Tablero> _TableroRepository { get; set; }
            public YerbaSoft.DAL.IRepository<Clue.Common.DTO.Clue.Tablero> Tableros => _TableroRepository = _TableroRepository ?? new YerbaSoft.DAL.Repositories.MemoryRepository<Games.Clue.Common.DTO.Clue.Tablero>();

            private YerbaSoft.DAL.IRepository<Clue.Common.DTO.Clue.Notas> _NotasRepository { get; set; }
            public YerbaSoft.DAL.IRepository<Clue.Common.DTO.Clue.Notas> Notas => _NotasRepository = _NotasRepository ?? new YerbaSoft.DAL.Repositories.MemoryRepository<Games.Clue.Common.DTO.Clue.Notas>();
        }
    }
}
