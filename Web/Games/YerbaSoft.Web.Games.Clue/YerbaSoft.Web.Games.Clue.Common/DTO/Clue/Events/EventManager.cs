using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Web.Games.Clue.Common.DTO.Clue.Events
{
    public class EventManager
    {
        private IEnumerable<Event> Events { get; set; }

        public EventManager(IEnumerable<Event> events)
        {
            this.Events = events;
        }

        public void OnStart(Mesa mesa, Tablero tablero)
        {
            CheckCustomEvents("OnStart", mesa, tablero);
        }

        public void OnMove(Mesa mesa, Tablero tablero)
        {
            CheckCustomEvents("OnMove", mesa, tablero);
        }

        public void OnTirarDados(Mesa mesa, Tablero tablero)
        {
            CheckCustomEvents("OnTirarDados", mesa, tablero);
        }

        public void OnFinTurno(Mesa mesa, Tablero tablero)
        {
            CheckCustomEvents("OnFinTurno", mesa, tablero);
        }

        private void CheckCustomEvents(string eventName, Mesa mesa, Tablero tablero)
        {
            var events = Events.Where(p => p.IsOn(eventName));

            foreach (var e in events)
                e.Execute(mesa, tablero);
        }
    }
}
