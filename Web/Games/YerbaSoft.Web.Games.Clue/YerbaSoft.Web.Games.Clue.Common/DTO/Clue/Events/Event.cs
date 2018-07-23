using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Web.Games.Clue.Common.DTO.Clue.Events
{
    [AutoMapping]
    public class Event : YerbaSoft.DAL.Repositories.XmlSimpleClass
    {
        [Direct]
        public string Name { get; set; }
        [Direct]
        public string Triggers { get; set; }
        [Direct]
        public string Action { get; set; }

        public bool IsOn(string eventName)
        {
            return this.Triggers.Split(';').Contains(eventName);
        }

        public void Execute(Mesa mesa, Tablero tablero)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("mesa", mesa);
            parms.Add("tablero", tablero);
            parms.Add("e", this);
            
            var references = new string[]
            {
                typeof(YerbaSoft.DTO.Result).Assembly.Location,
                typeof(YerbaSoft.DAL.Pager).Assembly.Location,
                typeof(YerbaSoft.Web.Games.Clue.Common.DTO.Clue.Tablero).Assembly.Location
            };

            var usings = new string[]
            {
                "YerbaSoft.DTO"
            };

            var expression = this.Action + "return tablero;";

            var result = (Tablero)YerbaSoft.Dynamic.Dynamic.ExecCSharp(expression, parms, references, usings);
            tablero = result ?? tablero;
        }


        /// <summary>
        /// Método para ayudar al evento "Puerta para entrar a una habitación"
        /// </summary>
        public Tablero OnRoomDoor(Mesa mesa, Tablero tablero, int room, string doorsList, string placesList)
        {
            var doors = TipoTablero.GetCoords(doorsList);
            var places = TipoTablero.GetCoords(placesList);

            if (doors.Contains(tablero.Posiciones[tablero.TurnoIndex]))
            {
                // muevo al personaje a un lugar dentro de la sala (donde no haya otro personaje)
                string coord = null;
                do
                {
                    coord = places.GetRandomValue();
                } while (tablero.Posiciones.Contains(coord));
                tablero.Posiciones[tablero.TurnoIndex] = coord;

                // cambio el estado y seteo la habitación
                tablero.Status = YerbaSoft.Web.Games.Clue.Common.DTO.Clue.TurnoStatus.Acusando;
                tablero.CurrentRoom[tablero.TurnoIndex] = room;
            }
            return tablero;
        }

        /// <summary>
        /// Método para ayudar al evento "salir de una habitación"
        /// </summary>
        public Tablero OnExitingRoom(Mesa mesa, Tablero tablero, int room, string doorsList, string pasajesList)
        {
            if (tablero.CurrentRoom[tablero.TurnoIndex] != room) return tablero;

            var doors = TipoTablero.GetCoords(doorsList).ToArray();
            var pasajes = TipoTablero.GetCoords(pasajesList);

            tablero.MoveTo = tablero.Manager.CalcMoveTo(doors, tablero.Dados.Sum(p => p.Value) ?? 0, mesa).Concat(pasajes).ToArray();
            return tablero;
        }

        /// <summary>
        /// Método para ayudar al evento "obtener una carta por moverse por el tablero"
        /// </summary>
        public Tablero OnGetCardSpot(Mesa mesa, Tablero tablero, string spotList)
        {
            var spots = TipoTablero.GetCoords(spotList);
            if (!spots.Contains(tablero.Posiciones[tablero.TurnoIndex])) return tablero;

            var card = tablero.Mazo.Dequeue();
            tablero.Cards[tablero.TurnoIndex] = tablero.Cards[tablero.TurnoIndex].Concat(new Card[] { card }).ToArray();

            return tablero;
        }
    }
}
