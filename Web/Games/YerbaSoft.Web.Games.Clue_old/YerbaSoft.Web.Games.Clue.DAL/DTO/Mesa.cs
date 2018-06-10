using System;
using System.Collections.Generic;

namespace YerbaSoft.Web.Games.Clue.DAL.DTO
{
    public class Mesa
    {
        public Guid Id { get; set; }
        public Guid IdOwner { get; set; }
        public Guid IdGame { get; set; }
        public Guid? IdTablero { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }

        public List<DAL.DTO.Usuario> Integrantes { get; set; }
    }
}
