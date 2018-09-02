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

        /// <summary>
        /// Ejecuta una acción
        /// </summary>
        /// <param name="mesa"></param>
        /// <param name="tablero"></param>
        public void Execute(Mesa mesa, Tablero tablero)
        {
            var e = new EventHelper(tablero, mesa);

            var expression = this.Action + "return e?.Tablero;";
            var tbl = (Tablero)e.ExecuteAction(expression, null);
            tablero = tbl ?? tablero;
        }
    }
}
