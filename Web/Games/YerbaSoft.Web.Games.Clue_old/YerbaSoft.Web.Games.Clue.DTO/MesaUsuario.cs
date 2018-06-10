using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Web.Games.Clue.DTO
{
    [AutoMapping]
    public class MesaUsuario
    {
        [Direct]
        public Guid IdMesa { get; set; }
        [Direct]
        public Guid IdUsuario { get; set; }
        [SubClass]
        public Usuario Usuario { get; set; }
    }
}
