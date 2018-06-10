using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DAL.Repositories;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Web.Games.Clue.Common.DTO
{
    [AutoMapping]
    public class Chat : XmlSimpleClass
    {
        public static string RepositoryName => "ChatsRepository";

        [Direct]
        public Guid Id { get; set; }

        [Direct]
        public string Name { get; set; }

        [Direct]
        public string Type { get; set; }

        [Direct]
        public string IconRes { get; set; }

        [Direct]
        public DateTime LastUpdate { get; set; }

        [SubList]
        public List<ChatUser> Integrantes { get; set; } = new List<ChatUser>();

        [NoMap]
        public List<ChatLine> ChatLines { get; set; } = new List<ChatLine>();
    }

    [AutoMapping]
    public class ChatUser : XmlSimpleClass
    {
        [Direct]
        public Guid Id { get; set; }

        [Direct]
        public string Name { get; set; }
    }

    [AutoMapping]
    public class ChatLine : XmlSimpleClass
    {
        [Direct]
        public DateTime Fecha { get; set; }

        public string FechaToShow
        {
            get
            {
                if (DateTime.Now.ToString("yyyyMMdd") == Fecha.ToString("yyyyMMdd"))
                    return Fecha.ToString("HH:mm");
                else
                    return $"{new System.Globalization.CultureInfo("es-es").DateTimeFormat.GetDayName(Fecha.DayOfWeek)} {Fecha.ToString("HH:mm")}";
            }
        }

        [Direct]
        public Guid IdUser { get; set; }

        [Direct]
        public string Text { get; set; }
    }

    public class ChatUserUpdates
    {
        public Guid IdUser { get; set; }
        public DateTime LastUpdate { get; set; }
    }

    public class ChatNews
    {
        public Guid IdChat { get; set; }

        public ChatLine ChatLine { get; set; }
    }
}
