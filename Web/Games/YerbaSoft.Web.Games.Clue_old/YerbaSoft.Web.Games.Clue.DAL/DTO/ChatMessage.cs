using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Web.Games.Clue.DAL.DTO
{
    public class ChatMessage : YerbaSoft.DAL.Repositories.XmlSimpleClass
    {
        public Guid Id { get; set; }
        public Guid IdChat { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public Guid IdUser { get; set; }
        public long Order { get; set; }
        public string Message { get; set; }
        public string UserLogo { get; set; }
        public string UserName { get; set; }
        public string Viewers { get; set; }
    }
}
