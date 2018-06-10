using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Web.Games.Clue.DAL.DTO
{
    public class Usuario : YerbaSoft.DAL.Repositories.XmlSimpleClass
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public char Sexo { get; set; }
        public string Logo { get; set; }
    }
}
