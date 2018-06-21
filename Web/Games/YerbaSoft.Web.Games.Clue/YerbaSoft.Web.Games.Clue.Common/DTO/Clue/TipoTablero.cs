using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Web.Games.Clue.Common.DTO.Clue
{
    [AutoMapping]
    public class TipoTablero : YerbaSoft.DAL.Repositories.XmlSimpleClass
    {
        public static string RepositoryName => "Clue-TipoTableroRepository";

        [Direct]
        public Guid Id { get; set; }
        [Direct]
        public Guid Name { get; set; }
    }
}
