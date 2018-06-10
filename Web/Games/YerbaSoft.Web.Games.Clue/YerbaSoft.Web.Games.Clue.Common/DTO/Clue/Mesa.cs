using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Web.Games.Clue.Common.DTO.Clue
{
    [AutoMapping]
    public class Mesa
    {
        [Direct]
        public Guid Id { get; set; }
        [Direct]
        public TipoTablero TipoTablero { get; set; }
        [Direct]
        public User Ower { get; set; }
        [YerbaSoft.DTO.Mapping.SubList]
        public List<User> Integrantes { get; set; }
    }
}
