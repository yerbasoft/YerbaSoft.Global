using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Web.Games.Clue.Common.DTO
{
    [AutoMapping]
    public class Game : YerbaSoft.DAL.Repositories.XmlSimpleClass
    {
        public static string RepositoryName => "GameRepository";

        [Direct]
        public Guid Id { get; set; }
        [Direct]
        public string Name { get; set; }
        [Direct]
        public string Text { get; set; }
        [Direct]
        public string ImageCardUrl { get; set; }
        [Direct]
        public string ImageCardBackUrl { get; set; }
        [NoMap]
        public bool Redirect { get; set; }
    }
}
