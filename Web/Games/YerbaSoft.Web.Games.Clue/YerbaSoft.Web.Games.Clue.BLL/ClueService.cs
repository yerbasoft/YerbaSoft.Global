using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Web.Games.Clue.BLL
{
    public class ClueService : BaseService
    {
        public DTO.Result<Common.DTO.Clue.MesasInfo> GetMesas(Guid idUser)
        {
            var mesas = this.Session.Clue.MesaRepository.Find(p => p.Status == Common.DTO.Clue.Mesa.MesaStatus.WaitingPlayers || p.Status == Common.DTO.Clue.Mesa.MesaStatus.Playing).ToArray();
            var current = mesas.SingleOrDefault(p => p.Integrantes.Any(i => i.Id == idUser));

            if (current != null && current.Status == Common.DTO.Clue.Mesa.MesaStatus.Playing)
                mesas = new Common.DTO.Clue.Mesa[] { current };    // se va a redirigir a la mesa (no se necesita la info de las otras mesas)

            return new DTO.Result<Common.DTO.Clue.MesasInfo>(new Common.DTO.Clue.MesasInfo() { Mesas = mesas, Current = current });
        }
    }
}
