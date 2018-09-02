using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Web.Games.Clue.Common.DTO.Clue
{
    [AutoMapping]
    public class Nota
    {
        public enum SimbolosEnum
        {
            LaTiene = 1,
            NoLaTiene = 2,

            Seguro = 10,
            Corazon = 11,
            RePreguntar = 12,
            Estrella = 13,
            Flag = 14,
            Pin = 15,
            Pregunto = 16,
            Pregunta = 17
        }

        [Direct]
        public string TipoRumor { get; set; }
        [Direct]
        public int RumorCode { get; set; }
        [Direct]
        public Guid Jugador { get; set; }
        [SubList]
        public List<SimbolosEnum> Simbolos { get; set; }

        internal static List<Nota> Get(Guid idJugador, List<Rumor> rumores, SimbolosEnum simbol)
        {
            return rumores.Select(p => Get(idJugador, p, simbol)).ToList();
        }

        internal static Nota Get(Guid idJugador, Rumor rumor, SimbolosEnum simbol)
        {
            return new Nota()
            {
                Jugador = idJugador,
                TipoRumor = rumor.TipoRumor,
                RumorCode = rumor.Code,
                Simbolos = new SimbolosEnum[] { simbol }.ToList()
            };
        }

    }
}
