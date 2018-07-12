using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Web.Games.Clue.Common.DTO.Clue
{
    [AutoMapping]
    public class Mesa
    {
        public enum MesaStatus
        {
            Creating = 0,
            WaitingPlayers = 1,
            Playing = 10,
            Closed = 99
        }

        [Direct]
        public Guid Id { get; set; }

        [Direct]
        public int Sillas { get; set; }

        [Direct]
        public Guid IdOwner { get; set; }

        [Direct]
        public TipoTablero TipoTablero { get; set; }

        [YerbaSoft.DTO.Mapping.SubList]
        public List<User> Integrantes { get; set; } = new List<User>();

        [Direct]
        public MesaStatus Status { get; set; }

        /// <summary>
        /// Indica si un id de usuario existe en la mes
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public bool HasUser(Guid idUser)
        {
            return this.Integrantes.Any(p => p.Id == idUser);
        }
    }
}
