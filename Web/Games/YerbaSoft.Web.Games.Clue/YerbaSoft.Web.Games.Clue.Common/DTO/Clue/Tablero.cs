using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Web.Games.Clue.Common.DTO.Clue
{
    [AutoMapping]
    public class Tablero
    {
        [Direct]
        public Guid IdMesa { get; set; }
        [Direct]
        public Guid Turno { get; set; }
        [Direct]
        public Guid[] Turnos { get; set; }

        /// <summary>
        /// Inicializa el Tablero de juego
        /// </summary>
        /// <param name="mesa"></param>
        public void Inicializar(Mesa mesa)
        {
            this.IdMesa = mesa.Id;
            this.Turnos = mesa.Integrantes.Shuffle().Select(p => p.Id.Value).ToArray();
            this.Turno = this.Turnos[0];
        }
    }
}
