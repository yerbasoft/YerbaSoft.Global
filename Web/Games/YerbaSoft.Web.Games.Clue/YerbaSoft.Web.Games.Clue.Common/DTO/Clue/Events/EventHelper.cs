using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO;

namespace YerbaSoft.Web.Games.Clue.Common.DTO.Clue.Events
{
    public class EventHelper
    {
        public Tablero Tablero { get; set; }
        public Mesa Mesa { get; set; }

        public EventHelper(Tablero tablero, Mesa mesa)
        {
            this.Tablero = tablero;
            this.Mesa = mesa;
        }

        public object ExecuteAction(string expression, object data = null)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("e", this);
            parms.Add("data", data);

            var references = new string[]
            {
                typeof(YerbaSoft.DTO.Result).Assembly.Location,
                typeof(YerbaSoft.DAL.Pager).Assembly.Location,
                typeof(YerbaSoft.Web.Games.Clue.Common.DTO.Clue.Tablero).Assembly.Location
            };

            var usings = new string[] { "YerbaSoft.DTO" };
            
            return YerbaSoft.Dynamic.Dynamic.ExecCSharp(expression, parms, references, usings);
        }

        /// <summary>
        /// Método para ayudar al evento "Puerta para entrar a una habitación"
        /// </summary>
        public Tablero OnRoomDoor(int room, string doorsList, string placesList)
        {
            var doors = TipoTablero.GetCoords(doorsList);
            var places = TipoTablero.GetCoords(placesList);

            if (doors.Contains(this.Tablero.Posiciones[this.Tablero.TurnoIndex]))
            {
                // muevo al personaje a un lugar dentro de la sala (donde no haya otro personaje)
                string coord = null;
                do
                {
                    coord = places.GetRandomValue();
                } while (this.Tablero.Posiciones.Contains(coord));
                this.Tablero.Posiciones[this.Tablero.TurnoIndex] = coord;

                // cambio el estado y seteo la habitación
                this.Tablero.Status = YerbaSoft.Web.Games.Clue.Common.DTO.Clue.TurnoStatus.Acusando;
                this.Tablero.CurrentRoom[this.Tablero.TurnoIndex] = room;
            }
            return this.Tablero;
        }

        /// <summary>
        /// Método para ayudar al evento "salir de una habitación"
        /// </summary>
        public Tablero OnExitingRoom(int room, string doorsList, string pasajesList)
        {
            if (this.Tablero.CurrentRoom[this.Tablero.TurnoIndex] != room) return this.Tablero;

            var doors = TipoTablero.GetCoords(doorsList).ToArray();
            var pasajes = TipoTablero.GetCoords(pasajesList);

            this.Tablero.MoveTo = this.Tablero.Manager.CalcMoveTo(doors, this.Tablero.Dados.GetValues(false).Sum(p => p) ?? 0, this.Mesa).Concat(pasajes).ToArray();
            return this.Tablero;
        }

        /// <summary>
        /// Método para ayudar al evento "obtener una carta por moverse por el tablero"
        /// </summary>
        public Tablero OnGetCardSpot(string spotList)
        {
            var spots = TipoTablero.GetCoords(spotList);
            if (!spots.Contains(this.Tablero.Posiciones[this.Tablero.TurnoIndex])) return this.Tablero;

            var card = this.Tablero.Mazo.Dequeue();
            this.Tablero.Cards[this.Tablero.TurnoIndex] = this.Tablero.Cards[this.Tablero.TurnoIndex].Concat(new Card[] { card }).ToArray();

            return this.Tablero;
        }

        /// <summary>
        /// Agrega una carta al jugador en turno
        /// </summary>
        /// <returns></returns>
        public Tablero RaizeDadoEspecial()
        {
            foreach (var dado in this.Tablero.Dados.GetValues(false).Where(p => p == 0))
            {
                this.Tablero.Cards[this.Tablero.TurnoIndex] = this.Tablero.Cards[this.Tablero.TurnoIndex].Concat(new Card[] { this.Tablero.Mazo.Dequeue() }).ToArray();
            }

            return this.Tablero;
        }
    }
}
