using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Web.Games.Clue.BLL
{
    public class Factory
    {
        public static DTO.BLLServices.ISecurityService GetSecurityService(DTO.Usuario currentUser)
        {
            return new Service.SecurityService(currentUser);
        }

        public static DTO.BLLServices.IGamesService GetGamesService(DTO.Usuario currentUser)
        {
            return new Service.GamesService(currentUser);
        }

        public static DTO.BLLServices.IClueService GetClueService(DTO.Usuario currentUser)
        {
            return new Service.ClueService(currentUser);
        }

        internal static string FilesPath { get { return "W:\\YerbaSoft\\Web\\Games\\"; } }
    }
}
