using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Web.Games.Clue.DAL.Editor
{
    public class TipoTablero
    {
        private string Path { get; set; }

        public TipoTablero(string path)
        {
            this.Path = path;
        }

        /// <summary>
        /// Mueve todas las coordenadas configuradas hacia la derecha-abajo según los offset
        /// </summary>
        /// <param name="name">Nombre del tablero</param>
        /// <param name="offsetX"></param>
        /// <param name="offsetY"></param>
        public void MoveAllCords(string name, int offsetX, int offsetY)
        {
            Console.WriteLine($"ALERTA!! :: Está a punto de mover las coordenadas del tablero {name} - offsets {offsetX}-{offsetY}");
            Console.WriteLine($"Presione ENTER para continuar. o escriba cualquier cosa para cancelar.");
            var input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
                return;


            var db = new Session(this.Path);

            var tableros = db.Clue.TipoTableros.Find(p => p.Name == name);

            foreach(var tablero in tableros)
            {
                var prev = tablero.SpotsConfig;
                tablero.SpotsConfig = string.Join(";", GetCoords(tablero.SpotsConfig).Select(p => OffsetCoord(p, offsetX, offsetY)));

                prev = tablero.WallsConfig;
                var walls = GetCoords(tablero.WallsConfig)
                                .Select(p => new { a = GetCoords(p, '-')[0], b = GetCoords(p, '-')[1] })
                                .Select(p => new { a = OffsetCoord(p.a, offsetX, offsetY), b = OffsetCoord(p.b, offsetX, offsetY) })
                                .Select(p => p.a + "-" + p.b);
                tablero.WallsConfig = string.Join(";", walls);

                /*
                foreach (var room in tablero.Rooms)
                {
                    prev = room.DoorsConfig;
                    room.DoorsConfig = string.Join(";", GetCoords(room.DoorsConfig).Select(p => OffsetCoord(p, offsetX, offsetY)));

                    
                    prev = room.SpotsConfig;
                    room.SpotsConfig = string.Join(";", GetCoords(room.SpotsConfig).Select(p => OffsetCoord(p, offsetX, offsetY)));
                }
                */
                db.Clue.TipoTableros.UpsertEntity(tablero);
            }

            db.Clue.TipoTableros.Commit();
        }


        private string[] GetCoords(string coords, char separator = ';')
        {
            return coords.Split(separator).Select(p => p.Trim()).Where(p => !string.IsNullOrEmpty(p)).ToArray();
        }

        private string OffsetCoord(string coord, int offsetX, int offsetY)
        {
            var x = Convert.ToInt32(coord.Substring(0, 3)) + offsetX;
            var y = Convert.ToInt32(coord.Substring(3)) + offsetY;

            return x.ToString("D3") + y.ToString("D3");
        }
    }
}
