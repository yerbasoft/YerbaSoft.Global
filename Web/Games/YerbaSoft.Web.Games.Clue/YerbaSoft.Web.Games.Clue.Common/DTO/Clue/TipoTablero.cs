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
        [SubList("Rooms")]
        public List<Room> Rooms { get; set; }
        [SubList("Rooms")]
        public List<Card> Cards { get; set; }

        private IEnumerable<Two<string, string>> _Walls = null;
        public IEnumerable<Two<string, string>> Walls => _Walls = _Walls ?? GetPars(this.WallsConfig);

        [Direct]
        public string SpotsConfig { get; set; }
        public IEnumerable<string> Spots => this.SpotsConfig.Split(';').Select(p => p.Trim()).Where(p => !string.IsNullOrEmpty(p));
        
        internal static IEnumerable<Two<string, string>> GetPars(string fullconfig)
        {
            fullconfig = fullconfig ?? "";
            var pars = fullconfig.Split(';').Where(p => p.IndexOf('-') > 0).Select(p => p.Trim());
            return pars.Select(p => p.Split('-')).Select(p => new Two<string, string>(p[0], p[1]));
        }
    }

    [AutoMapping]
    public class Room
    {
        [Direct]
        public string Name { get; set; }

        [Direct]
        public string DoorsConfig { get; set; }
        public IEnumerable<string> Doors => this.DoorsConfig.Split(';').Select(p => p.Trim()).Where(p => !string.IsNullOrEmpty(p));

        [Direct("Spots")]
        public string SpotsConfig { get; set; }
        public IEnumerable<string> Spots => this.SpotsConfig.Split(';').Select(p => p.Trim()).Where(p => !string.IsNullOrEmpty(p));

        public override string ToString()
        {
            return $"{{ Name:{Name}, Doors:{Doors.Count()}, Spots:{Spots.Count()} }}";
        }
    }


    [AutoMapping]
    public class Card
    {
        [Direct]
        public string Name { get; set; }
        [Direct]
        public string Texto { get; set; }
        [Direct]
        public string Imagen { get; set; }
        [Direct]
        public int Cantidad { get; set; }
        [Direct]
        public string Uso { get; set; }

        public bool IsUsable(Tablero.TurnoStatus status)
        {
            var usos = Uso.Split(';').Select(p => (Tablero.TurnoStatus)Enum.Parse(typeof(Tablero.TurnoStatus), p));

            return usos.Contains(status);            
        }
    }
}
