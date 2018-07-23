using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO;
using YerbaSoft.DTO.Mapping;
using YerbaSoft.DTO.Types;

namespace YerbaSoft.Web.Games.Clue.Common.DTO.Clue
{
    /// <summary>
    /// Estados posibles en un Turno
    /// </summary>
    public enum TurnoStatus
    {
        Start = 0,
        DespuesDados = 10,
        Acusando = 30,
        DespuesAcusacion = 40,
        FinDeTurno = 50
    }

    [AutoMapping]
    public class Tablero
    {
        /// <summary>
        /// Id único por tablero
        /// </summary>
        [Direct]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Id de la mesa a la que pertenece el tablero
        /// </summary>
        [Direct]
        public Guid IdMesa { get; set; }

        /// <summary>
        /// Indica el Id del jugador en Turno
        /// </summary>
        [Direct]
        public Guid Turno { get; set; }

        /// <summary>
        /// Indica el index de Turno para los arrays con información x Turno
        /// </summary>
        [Direct]
        public int TurnoIndex { get; set; }
        
        /// <summary>
        /// Indica el Estado del Turno
        /// </summary>
        [Direct]
        public TurnoStatus Status { get; set; }

        /// <summary>
        /// Indica la lista de Jugadores (Ordenado por turno)
        /// </summary>
        [Direct]
        public Guid[] Turnos { get; set; }

        /// <summary>
        /// Indica la habitación donde se encuentran los personajes
        /// </summary>
        [Direct]
        public int?[] CurrentRoom { get; set; }

        /// <summary>
        /// Indica las posiciones en el mapa de cada uno de los jugadores (Ordenado por turno)
        /// </summary>
        [Direct]
        public string[] Posiciones { get; set; }

        /// <summary>
        /// Indica los Dados tal como se tiraron la última vez
        /// </summary>
        [Direct]
        public Dado[] Dados { get; set; } = new Dado[] { };

        /// <summary>
        /// Indica las posiciones donde se puese mover un personaje (solo debe tener valor en estado = "DespuesDados")
        /// </summary>
        [Direct]
        public string[] MoveTo { get; set; }

        /// <summary>
        /// Mazo de cartas disponibles en la partida
        /// </summary>
        [Direct]
        public Queue<Card> Mazo { get; set; }

        /// <summary>
        /// Listado de cartas que posee cada jugador
        /// </summary>
        [Direct]
        public Card[][] Cards { get; set; }

        private TableroManagement _Manager;
        [NoMap]
        public TableroManagement Manager => _Manager = _Manager ?? new TableroManagement(this);
    }
}
