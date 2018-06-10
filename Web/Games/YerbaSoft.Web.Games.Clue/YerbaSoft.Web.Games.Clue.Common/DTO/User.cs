using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Web.Games.Clue.Common.DTO
{
    [AutoMapping]
    public class User : YerbaSoft.DAL.Repositories.XmlSimpleClass
    {
        public static string RepositoryName => "UserRepository";

        public static User Anonimo { get { return new User() { Id = Guid.Empty, Name = "Anonimo" }; } }

        [Direct]
        public Guid? Id { get; set; }
        [Direct]
        public string Name { get; set; }
        [Direct]
        public string UserName { get; set; }
        [Direct]
        public string Password { get; set; }
        [Direct]
        public string EMail { get; set; }
        [Direct]
        public string IconRes { get; set; }
    }
}
