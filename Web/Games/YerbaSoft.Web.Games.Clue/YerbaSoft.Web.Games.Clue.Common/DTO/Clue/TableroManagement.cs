﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO;

namespace YerbaSoft.Web.Games.Clue.Common.DTO.Clue
{
    public class TableroManagement
    {
        public Tablero tablero { get; private set; }

        public TableroManagement(Tablero t)
        {
            this.tablero = t;
        }

        /// <summary>
        /// MAIN PROCESS :: Inicia un tablero para el juego (prepatrativos) y continúa el flujo
        /// </summary>
        /// <param name="mesa"></param>
        public void StartTablero(Mesa mesa)
        {
            tablero.IdMesa = mesa.Id;
            tablero.Turnos = mesa.Integrantes.Shuffle().Select(p => p.Id.Value).ToArray();  // distribuyo los turnos

            var spots = mesa.TipoTablero.Spots.ToList().Shuffle().ToArray();
            tablero.Posiciones = tablero.Turnos.Select((p, i) => spots[i]).ToArray();   // distribuyo los jugadores por los spots de inicio
            tablero.Mazo = new Queue<Card>(mesa.TipoTablero.Cards.SelectMany(p => new string(' ', p.Cantidad).Select(c => p)).ToList().Shuffle()); // preparo el mazo de cartas
            tablero.Cards = tablero.Turnos.Select(p => new Card[] { tablero.Mazo.Dequeue() }).ToArray();    // reparto una carta para cada jugador

            this.NuevoTurno(mesa, true);
        }

        /// <summary>
        /// MAIN PROCESS :: Cambia de turno al siguiente jugador y continúa el flujo
        /// </summary>
        /// <param name="mesa"></param>
        /// <param name="starting"></param>
        public void NuevoTurno(Mesa mesa, bool starting = false)
        {
            tablero.TurnoIndex = starting ? 0 : (tablero.TurnoIndex >= tablero.Turnos.Length - 1 ? 0 : (tablero.TurnoIndex + 1));   // calculo el index del siguiente turno
            tablero.Turno = tablero.Turnos[tablero.TurnoIndex];
            tablero.Status = TurnoStatus.Start;

            mesa.TipoTablero.EventManager.OnStart(mesa, tablero);
            
            if (!TieneCartas(tablero.Status))
                this.TiraDados(mesa);
        }

        /// <summary>
        /// MAIN PROCESS :: Tira los dados y continúa el flujo
        /// </summary>
        public void TiraDados(Mesa mesa)
        {
            var dados = mesa.TipoTablero.Dados;

            tablero.Dados = dados.Select(p => p.Shufle()).ToArray();

            mesa.TipoTablero.EventManager.OnTirarDados(mesa, tablero);

            if ((tablero.MoveTo?.Length ?? 0) == 0)     // validación por si algún evento ya calculó el movimiento
                tablero.MoveTo = CalcMoveTo(tablero.Posiciones[tablero.TurnoIndex], tablero.Dados.Sum(p => p.Value) ?? 0, mesa).ToArray();

            if (tablero.Status == TurnoStatus.Start)    // validación por si algún evento cambió de estado
                tablero.Status = TurnoStatus.DespuesDados;
        }

        /// <summary>
        /// MAIN PROCESS :: Mueve el personaje y continúa el flujo
        /// </summary>
        public void MoverPersonaje(Mesa mesa, string pos)
        {
            tablero.Posiciones[tablero.TurnoIndex] = pos;   // muevo al jugador
            tablero.MoveTo = new string[] { };              // quito los posibles movimientos del jugador
            tablero.CurrentRoom[tablero.TurnoIndex] = null; // por default reseteo que esté en alguna habitación

            mesa.TipoTablero.EventManager.OnMove(mesa, tablero);

            if (tablero.Status == TurnoStatus.Acusando)
                this.EmpezarAcusamiento(); // entró a una habitación
            else
                this.FinDeTurno(mesa); // solo caminó por el mapa
        }

        /// <summary>
        /// MAIN PROCESS :: Prepara los datos para realizar una Acusación y continúa el flujo
        /// </summary>
        public void EmpezarAcusamiento()
        {
            //...


            tablero.Status = TurnoStatus.Acusando;
        }

        /// <summary>
        /// MAIN PROCESS :: Procesa los datos de la Acusación y continúa el flujo
        /// </summary>
        public void ProcesarAcusamiento()
        {
            //...


            tablero.Status = TurnoStatus.DespuesAcusacion;
        }

        /// <summary>
        /// MAIN PROCESS :: Chequea información y finaliza el turno y continúa el flujo
        /// </summary>
        public void FinDeTurno(Mesa mesa)
        {
            mesa.TipoTablero.EventManager.OnFinTurno(mesa, tablero);

            if (tablero.Status == TurnoStatus.DespuesDados || tablero.Status == TurnoStatus.DespuesAcusacion)   // validación por si cambia el estado en algun evento
                tablero.Status = TurnoStatus.FinDeTurno;

            tablero.Status = Common.DTO.Clue.TurnoStatus.FinDeTurno;

            if (!TieneCartas(TurnoStatus.FinDeTurno))
                this.NuevoTurno(mesa);
        }



        #region Helpers

        /// <summary>
        /// Indica si el usuario actual tiene cartas para usar según el estado del Turno
        /// </summary>
        /// <returns></returns>
        private bool TieneCartas(TurnoStatus status)
        {
            return tablero.Cards[tablero.TurnoIndex].Any(p => p.IsUsable(status));
        }
        
        #endregion

        #region Calcular Movimientos Posibles

        public IEnumerable<string> CalcMoveTo(string[] start, int dados, Mesa mesa)
        {
            var places = new List<string>();

            foreach (var s in start)
                places.AddRange(CalcMoveTo(s, dados, mesa));

            return places;
        }

        public IEnumerable<string> CalcMoveTo(string start, int dados, Mesa mesa)
        {
            var x = System.Convert.ToInt32(start.Substring(0, 3));
            var y = System.Convert.ToInt32(start.Substring(3));
            var places = Calc(x, y, new List<string>(), mesa.TipoTablero, 0, dados).Distinct();

            return places.Where(p => !tablero.Posiciones.Contains(p));
        }

        private List<string> Calc(int x, int y, List<string> path, TipoTablero config, int step, int steps)
        {
            if (step > steps) return new List<string>();    // se me acabaron los movimientos
            if (x < 0 || y < 0 || y == config.Heigth || x == config.Width) return new List<string>(); // se sale del tablero

            var X = x.ToString("D3");
            var Y = y.ToString("D3");
            var coord = X + Y;
            if (path.Contains(coord)) return new List<string>();

            var acum = new List<string>();
            if (step > 0) acum.Add(coord);
            path.Add(coord);

            // up
            var dest = X + (y - 1).ToString("D3");
            if (!HasWall(coord, dest, config))
                acum.AddRange(Calc(x, y - 1, path.ToArray().ToList(), config, step + 1, steps));

            // down
            dest = X + (y + 1).ToString("D3");
            if (!HasWall(coord, dest, config))
                acum.AddRange(Calc(x, y + 1, path.ToArray().ToList(), config, step + 1, steps));

            // left
            dest = (x - 1).ToString("D3") + Y;
            if (!HasWall(coord, dest, config))
                acum.AddRange(Calc(x - 1, y, path.ToArray().ToList(), config, step + 1, steps));

            // rigth
            dest = (x + 1).ToString("D3") + Y;
            if (!HasWall(coord, dest, config))
                acum.AddRange(Calc(x + 1, y, path.ToArray().ToList(), config, step + 1, steps));

            return acum;
        }

        private bool HasWall(string c1, string c2, TipoTablero tipoTablero)
        {
            return tipoTablero.Walls.Any(p => (p.V1 == c1 && p.V2 == c2) || (p.V1 == c2 && p.V2 == c1));
        }

        #endregion
    }
}
