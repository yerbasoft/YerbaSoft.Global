using System;
using System.Collections.Generic;

namespace YerbaSoft.Web.Games.Clue.DAL.DTO
{
    public class Wall
    {
        public string From { get; set; }
        public string To { get; set; }
    }

    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? RoomPassage { get; set; }
        public string ImagePath { get; set; }
        public string ImageCoord { get; set; }
        public List<string> Cells { get; set; }
        public List<Wall> Walls { get; set; }
    }

    public class Celda
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Card { get; set; }
        public int? Room { get; set; }
        public Guid? IdJugador { get; set; }
    }

    public class JugadorEnTablero
    {
        public class DadosType
        {
            public int D1 { get; set; }
            public int D2 { get; set; }
            public int Movimientos { get; set; }
        }

        public Usuario Jugador { get; set; }
        public string IdCelda { get; set; }
        public DadosType Dados { get; set; } = new DadosType();
    }

    public class Tablero
    {
        public enum Etapas
        {
            TirarDados = 1,
            MoverPersonaje = 2
        }
        public Guid Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<Celda> Celdas { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Wall> Walls { get; set; }
        public List<string> Spots { get; set; }
        public Guid Turno { get; set; }
        public Etapas Etapa { get; set; }
        public List<JugadorEnTablero> Jugadores { get; set; }
    }
}
