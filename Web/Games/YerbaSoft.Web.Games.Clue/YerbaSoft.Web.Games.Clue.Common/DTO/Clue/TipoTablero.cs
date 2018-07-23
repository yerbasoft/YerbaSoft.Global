using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;
using YerbaSoft.DTO.Types;

namespace YerbaSoft.Web.Games.Clue.Common.DTO.Clue
{
    [AutoMapping]
    public class TipoTablero : YerbaSoft.DAL.Repositories.XmlSimpleClass
    {
        public static string RepositoryName => "Clue-TipoTableroRepository";

        [Direct]
        public Guid Id { get; set; }
        [Direct]
        public string Name { get; set; }
        [Direct]
        public int Width { get; set; }
        [Direct]
        public int Heigth { get; set; }
        [Direct]
        public string WallsConfig { get; set; }
        [Direct]
        public string Imagen { get; set; }
        [SubList]
        public List<Room> Rooms { get; set; }
        [SubList]
        public List<Card> Cards { get; set; }
        [SubList]
        public List<Events.Event> Events { get; set; }
        [SubList]
        public List<Dado> Dados { get; set; }

        public Common.DTO.Clue.Events.EventManager EventManager => new Events.EventManager(this.Events);

        private IEnumerable<Two<string, string>> _Walls = null;
        public IEnumerable<Two<string, string>> Walls => _Walls = _Walls ?? GetParCoords(this.WallsConfig);

        [Direct]
        public string SpotsConfig { get; set; }
        public IEnumerable<string> Spots => TipoTablero.GetCoords(this.SpotsConfig);
        
        internal static IEnumerable<string> GetCoords(string fullconfig, char separator = ';')
        {
            if (fullconfig == null)
                return new string[] { };

            return (fullconfig ?? "").Split(separator).Select(p => p.Trim()).Where(p => !string.IsNullOrEmpty(p));
        }

        internal static IEnumerable<Two<string, string>> GetParCoords(string fullconfig)
        {
            fullconfig = fullconfig ?? "";
            var pars = fullconfig.Split(';').Where(p => p.IndexOf('-') > 0).Select(p => p.Trim());
            return pars.Select(p => p.Split('-')).Select(p => new Two<string, string>(p[0], p[1]));
        }
    }

    [AutoMapping]
    public class Room : YerbaSoft.DAL.Repositories.XmlSimpleClass
    {
        [Direct]
        public string Name { get; set; }
        [Direct]
        public int Code { get; set; }
    }


    [AutoMapping]
    public class Card : YerbaSoft.DAL.Repositories.XmlSimpleClass
    {
        [Direct]
        public string Name { get; set; }
        [Direct]
        public string Texto { get; set; }
        [Direct]
        public int Cantidad { get; set; }
        [Direct]
        public string Uso { get; set; }

        public bool IsUsable(TurnoStatus status)
        {
            var usos = Uso.Split(';').Select(p => (TurnoStatus)Enum.Parse(typeof(TurnoStatus), p));
            return usos.Contains(status);            
        }
    }
}
