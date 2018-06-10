using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using YerbaSoft.DTO;
using YerbaSoft.DTO.Mapping;
using YerbaSoft.Web.Games.Clue.DTO;
using YerbaSoft.Web.Games.Clue.DTO.Clue;

namespace YerbaSoft.Web.Games.Clue.BLL.Service
{
    internal class ClueService : Service, DTO.BLLServices.IClueService
    {
        public ClueService(Usuario currentUser) : base(currentUser)
        {
        }

        public Status GetStatus(Guid idTablero)
        {
            var tablero = this.Session.Tablero.Find(p => p.Id == idTablero).SingleOrDefault();
            if (tablero == null)
                return null;

            var status = Map.Get<Status>(tablero);

            return status;
        }

        public Tablero GetTablero(Usuario idUser)
        {
            var mesa = this.Session.Mesa.Find(p => p.Integrantes.Any(i => i.Id == idUser.Id)).SingleOrDefault();
            if (mesa == null || !mesa.IdTablero.HasValue)
                return null;

            return Map.Get<DTO.Clue.Tablero>(this.Session.Tablero.Find(p => p.Id == mesa.IdTablero).SingleOrDefault());
        }

        public void MesaStart(Guid idMesa)
        {
            var mesa = this.Session.Mesa.Find(p => p.Id == idMesa).SingleOrDefault();
            if (mesa == null)
                return;

            var tbl = NewTablero();
            tbl.Inicializar(Map.Get<Mesa>(mesa));
            var tablero = Map.Get<DAL.DTO.Tablero>(tbl);
            this.Session.Tablero.UpsertEntity(tablero);

            mesa.Estado = (int)DAL.DTO.Tablero.Etapas.TirarDados;
            mesa.IdTablero = tablero.Id;


            this.Session.Mesa.UpsertEntity(mesa);
            this.Session.Commit();
        }

        public Result SetDados(Guid idTablero, Guid idJugador, int d1, int d2)
        {
            var tablero = this.Session.Tablero.Find(p => p.Id == idTablero).Single();
            tablero.Etapa = DAL.DTO.Tablero.Etapas.MoverPersonaje;
            var j = tablero.Jugadores.Single(p => p.Jugador.Id == idJugador);
            j.Dados.D1 = d1;
            j.Dados.D2 = d2;
            j.Dados.Movimientos = d1 + d2;

            this.Session.Tablero.UpsertEntity(tablero);
            this.Session.Commit();

            return new Result();
        }

        private Tablero NewTablero()
        {
            var xml = new XmlDocument();
            xml.Load($"{Factory.FilesPath}TableroClue.xml");
            var MainNode = (XmlNode)xml.DocumentElement;

            var width = MainNode.Attr<int>("Width");
            var height = MainNode.Attr<int>("Heigth");
            var tbl = new Tablero() { Id = Guid.NewGuid(), Width = width, Height = height };

            // ROOMS
            tbl.Rooms = MainNode.SubNode("Rooms").SubNodes("Room").Select(r =>
                new Room() {
                    Id = r.Attr<int>("id"),
                    Name = r.Attr("name"),
                    ImagePath = r.Attr("image"),
                    ImageCoord = r.Attr("imagefrom"),
                    RoomPassage = r.Attr("roompassage") != null ? r.Attr<int>("roompassage") : (int?)null,
                    Cells = r.SubNode("Cells").InnerText.Split(';').Select(p => p.Trim()).ToList(),
                    Walls = r.SubNode("Walls").InnerText.Split(';').Select(p => new Wall(p)).Where(p => p.IsValid).ToList()
                }).ToList();

            // WALLS
            tbl.Walls = tbl.Rooms.SelectMany(p => p.Walls).ToList();

            // SPOTS
            tbl.Spots = MainNode.SubNode("Spots").InnerText.Split(';').Select(p => p.Trim()).Where(p => !string.IsNullOrEmpty(p)).ToList();

            // CARD CELLS
            var cardCells = MainNode.SubNode("Cards").SubNode("Cells").InnerText.Split(';').Select(p => p.Trim());

            // CELLS
            tbl.Celdas = new List<Celda>();
            for (var x = 0; x < tbl.Width; x++)
            {
                for (var y = 0; y < tbl.Height; y++)
                {
                    var c = new Celda() { X = x, Y = y };

                    var room = tbl.Rooms.SingleOrDefault(p => p.Cells.Contains(c.Id));
                    
                    c.Card = cardCells.Contains(c.Id);
                    if (room != null)
                        c.Room = room.Id;


                    tbl.Celdas.Add(c);
                }
            }

            return tbl;
        }
    }
}
