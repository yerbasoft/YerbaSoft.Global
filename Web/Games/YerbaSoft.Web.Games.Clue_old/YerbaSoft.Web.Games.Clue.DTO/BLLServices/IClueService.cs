using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO;

namespace YerbaSoft.Web.Games.Clue.DTO.BLLServices
{
    public interface IClueService : IDisposable
    {
        void MesaStart(Guid idMesa);
        DTO.Clue.Tablero GetTablero(Usuario currentUser);
        DTO.Clue.Status GetStatus(Guid idTablero);
        Result SetDados(Guid idTablero, Guid idJugador, int d1, int d2);
    }
}
