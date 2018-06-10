using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Web.Games.Clue.DTO
{
    [AutoMapping]
    public class Game
    {
        [Direct]
        public Guid Id { get; set; }
        [Direct]
        public string Nombre { get; set; }
        [Direct]
        public string Descripcion { get; set; }
        [Direct]
        public string Codigo { get; set; }
    }
}
