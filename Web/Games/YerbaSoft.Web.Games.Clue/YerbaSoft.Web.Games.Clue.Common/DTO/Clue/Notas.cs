using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Web.Games.Clue.Common.DTO.Clue
{
    public class Notas
    {
        public Guid IdTablero { get; set; }

        public List<List<Nota>> JugadorNotas { get; set; }

        public void Inicializar(Tablero tablero)
        {
            this.IdTablero = tablero.Id;
            
            this.JugadorNotas = tablero.Turnos.Select((p, i) => Nota.Get(p, tablero.Rumores[i], Nota.SimbolosEnum.LaTiene)).ToList();
        }
    }
}
