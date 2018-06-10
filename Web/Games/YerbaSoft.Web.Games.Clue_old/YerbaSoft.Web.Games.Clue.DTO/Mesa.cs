using System;
using System.Collections.Generic;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Web.Games.Clue.DTO
{
    [AutoMapping]
    public class Mesa
    {
        [Direct]
        public Guid Id { get; set; }
        [Direct]
        public Guid IdOwner { get; set; }
        [Direct]
        public Guid IdGame { get; set; }
        [Direct]
        public string Nombre { get; set; }
        [Direct]
        public int Estado { get; set; }
        
        public string unique { get { return "Mesa" + Id.ToString().Replace("-", ""); } }

        [SubList]
        public List<DTO.Usuario> Integrantes { get; set; }
    }
}
