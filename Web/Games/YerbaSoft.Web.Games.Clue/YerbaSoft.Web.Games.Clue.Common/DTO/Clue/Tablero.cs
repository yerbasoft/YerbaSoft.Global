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
    [AutoMapping]
    public class Tablero
    {
        public enum TurnoStatus
        {
            Start = 0,
            DespuesDados = 10,
            DespuesMoverse = 20,
            Acusando = 30,
            DespuesAcusacion = 40,
            FinDeTurno = 50
        }

        [Direct]
        public Guid IdMesa { get; set; }
        [Direct]
        public Guid Turno { get; set; }
        [Direct]
        public TurnoStatus Status { get; set; }
        [Direct]
        public Guid[] Turnos { get; set; }
        [Direct]
        public string[] Posiciones { get; set; }
        [Direct]
        public Two<int, int> Dados { get; set; }
        [Direct]
        public string[] MoveTo { get; set; }

        [Direct]
        public Queue<Card> Mazo { get; set; }
        [Direct]
        public Card[][] Cards { get; set; }


        /// <summary>
        /// Inicializa el Tablero de juego
        /// </summary>
        /// <param name="mesa"></param>
        public void Inicializar(Mesa mesa)
        {
            this.IdMesa = mesa.Id;
            this.Turnos = mesa.Integrantes.Shuffle().Select(p => p.Id.Value).ToArray();
            this.Turno = this.Turnos[0];
            this.Dados = TirarDados();

            var spots = mesa.TipoTablero.Spots.ToList().Shuffle().ToArray();
            this.Posiciones = this.Turnos.Select((p, i) => spots[i]).ToArray();
            this.Mazo = new Queue<Card>(mesa.TipoTablero.Cards.SelectMany(p => new string(' ', p.Cantidad).Select(c => p)).ToList().Shuffle());
            this.Cards = this.Turnos.Select(p => new Card[] { this.Mazo.Dequeue() }).ToArray();

            this.MoveTo = CalcMoveTo(this.Posiciones[0], this.Dados.V1 + this.Dados.V2, mesa);
        }

        public string[] CalcMoveTo(string start, int dados, Mesa mesa)
        {
            var places = CalcMoveToRecursive(start, 0, dados, mesa, new List<string>()).Distinct();
            return places.Where(p => !this.Posiciones.Contains(p)).ToArray();
        }

        private string[] CalcMoveToRecursive(string pos, int steps, int dados, Mesa mesa, List<string> path)
        {
            if (steps > dados)
                return new string[] { };

            if (path.Contains(pos)) // vuelve para atrás
                return new string[] { };
            path.Add(pos);

            var acum = new string[] { };
            var X1 = pos.Substring(0, 3);
            var Y1 = pos.Substring(3, 3);
            var x1 = System.Convert.ToInt32(X1);
            var y1 = System.Convert.ToInt32(Y1);

            string X2 = null;
            string Y2 = null;
            // up
            if (y1 > 0)
            {
                X2 = X1;
                Y2 = (y1 - 1).ToString("D3");
                if (!HasWall(X1+Y1, X2+Y2, mesa))
                    acum = acum.Concat(CalcMoveToRecursive(X2 + Y2, steps + 1, dados, mesa, path)).ToArray();
            }

            // down
            if (y1 < mesa.TipoTablero.Heigth - 1)
            {
                X2 = X1;
                Y2 = (y1 + 1).ToString("D3");
                if (!HasWall(X1 + Y1, X2 + Y2, mesa))
                    acum = acum.Concat(CalcMoveToRecursive(X2 + Y2, steps + 1, dados, mesa, path)).ToArray();
            }

            // left
            if (x1 > 0)
            {
                X2 = (x1 - 1).ToString("D3");
                Y2 = Y1;
                if (!HasWall(X1 + Y1, X2 + Y2, mesa))
                    acum = acum.Concat(CalcMoveToRecursive(X2 + Y2, steps + 1, dados, mesa, path)).ToArray();
            }

            // rigth
            if (x1 < mesa.TipoTablero.Width - 1)
            {
                X2 = (x1 + 1).ToString("D3");
                Y2 = Y1;
                if (!HasWall(X1 + Y1, X2 + Y2, mesa))
                    acum = acum.Concat(CalcMoveToRecursive(X2 + Y2, steps + 1, dados, mesa, path)).ToArray();
            }
            return new string[] { pos }.Concat(acum).ToArray();
        }

        private bool HasWall(string c1, string c2, Mesa mesa)
        {
            return mesa.TipoTablero.Walls.Any(p => (p.V1 == c1 && p.V2 == c2) || (p.V1 == c2 && p.V2 == c1));
        }

        public Two<int, int> TirarDados()
        {
            var rnd = new Random();
            return new Two<int, int>()
            {
                V1 = rnd.Next(1, 6),
                V2 = rnd.Next(1, 6)
            };
        }
    }
}
