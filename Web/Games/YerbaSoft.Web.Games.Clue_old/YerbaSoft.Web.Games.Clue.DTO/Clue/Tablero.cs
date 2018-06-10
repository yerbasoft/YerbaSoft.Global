using System;
using System.Linq;
using System.Collections.Generic;
using YerbaSoft.DTO;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Web.Games.Clue.DTO.Clue
{
    [AutoMapping]
    public class Wall
    {
        [Direct]
        public string From { get; set; }
        [Direct]
        public string To { get; set; }

        public bool IsValid { get { return !string.IsNullOrEmpty(From) && !string.IsNullOrEmpty(To); } }

        public Wall() { }
        public Wall(string config)
        {
            if (string.IsNullOrEmpty(config))
                return;

            config = config.Trim();
            var data = config.Split('-');

            if (data.Length == 2)
            {
                this.From = data[0];
                this.To = data[1];
            }
        }

        public override string ToString()
        {
            return $"{From}-{To}";
        }
    }

    [AutoMapping]
    public class Room
    {
        [Direct]
        public int Id { get; set; }
        [Direct]
        public string Name { get; set; }
        [Direct]
        public int? RoomPassage { get; set; }
        [Direct]
        public string ImagePath { get; set; }
        [Direct]
        public string ImageCoord { get; set; }
        [Direct]
        public List<string> Cells { get; set; }
        [SubList]
        public List<Wall> Walls { get; set; }

        public override string ToString()
        {
            return $"{Id}-{Name}";
        }

    }

    [AutoMapping]
    public class Celda
    {
        public string Id { get { return X.ToString("D3") + Y.ToString("D3"); } }
        [Direct]
        public int X { get; set; }
        [Direct]
        public int Y { get; set; }
        [Direct]
        public bool Card { get; set; }
        [Direct]
        public int? Room { get; set; }

        public override string ToString()
        {
            return Id;
        }
    }

    [AutoMapping]
    public class DadosType
    {
        [Direct]
        public int D1 { get; set; }
        [Direct]
        public int D2 { get; set; }
        [Direct]
        public int Movimientos { get; set; }
    }

    [AutoMapping]
    public class JugadorEnTablero
    {
        [SubClass]
        public Usuario Jugador { get; set; }
        [Direct]
        public string IdCelda { get; set; }
        [SubClass]
        public DadosType Dados { get; set; }
    }

    [AutoMapping]
    public class Tablero
    {
        [Direct]
        public Guid Id { get; set; }
        [Direct]
        public int Width { get; set; }
        [Direct]
        public int Height { get; set; }
        [SubList]
        public List<Celda> Celdas { get; set; }
        [SubList]
        public List<Room> Rooms { get; set; }
        [SubList]
        public List<Wall> Walls { get; set; }
        [Direct]
        public List<string> Spots { get; set; }

        [Direct]
        public Guid Turno { get; set; }
        [Direct]
        public int Etapa { get; set; }
        [SubList]
        public List<JugadorEnTablero> Jugadores { get; set; }

        public void Inicializar(Mesa mesa)
        {
            this.Jugadores = mesa.Integrantes.Random().Select((p, i) => new JugadorEnTablero() { IdCelda = this.Spots[i], Jugador = p }).ToList();
            Turno = this.Jugadores[0].Jugador.Id;
            this.Etapa = 1;
        }
    }
}
