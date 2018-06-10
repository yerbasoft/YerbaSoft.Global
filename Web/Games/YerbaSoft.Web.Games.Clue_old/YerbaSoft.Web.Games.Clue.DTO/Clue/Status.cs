using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Web.Games.Clue.DTO.Clue
{
    [AutoMapping]
    public class Status
    {
        [Direct]
        public Guid Turno { get; set; }
        [Direct]
        public int Etapa { get; set; }
        [SubList]
        public List<JugadorEnTablero> Jugadores { get; set; }
    }
}
