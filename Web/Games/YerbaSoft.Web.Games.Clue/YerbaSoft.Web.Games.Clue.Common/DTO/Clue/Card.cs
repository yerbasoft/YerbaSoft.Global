using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DAL.Repositories;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Web.Games.Clue.Common.DTO.Clue
{
    [AutoMapping]
    public class Card : XmlSimpleClass
    {
        public Guid Id => Guid.NewGuid();
        [Direct]
        public string Name { get; set; }
        [Direct]
        public string Texto { get; set; }
        [Direct]
        public int Cantidad { get; set; }
        [Direct]
        public string Uso { get; set; }
        [Direct]
        public CardAction Action { get; set; }

        public bool IsUsable(TurnoStatus status)
        {
            var usos = Uso.Split(';').Select(p => (TurnoStatus)Enum.Parse(typeof(TurnoStatus), p));
            return usos.Contains(status);
        }

        [AutoMapping]
        public class CardAction : XmlSimpleClass
        {
            [Direct]
            public string Client { get; set; }
            [Direct]
            public string Server { get; set; }

            /// <summary>
            /// Ejecuta una acción de una carta del lado servidor
            /// </summary>
            public CardActionResult ExecuteServer(Mesa mesa, Tablero tablero, DataStr data)
            {
                var e = new Events.EventHelper(tablero, mesa);
                var expression = "var result = new YerbaSoft.Web.Games.Clue.Common.DTO.Clue.Card.CardAction.CardActionResult(tablero, true);" + this.Server + "return result;";
                var result = (CardActionResult)e.ExecuteAction(expression, data);
                tablero = result?.Tablero ?? tablero;

                return result;
            }

            public class CardActionResult
            {
                public Tablero Tablero { get; set; }
                public bool NextStatus { get; set; }

                public CardActionResult(Tablero tablero, bool nextStatus)
                {
                    this.Tablero = tablero;
                    this.NextStatus = nextStatus;
                }
            }
        }

        public class DataStr
        {
            public string SelectedRoom { get; set; }
        }
    }
}
