using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Web.Games.Clue.BLL
{
    public class BaseService
    {
        public static string RepositoriesPath { get; set; }
        
        private Clue.DAL.Session _session { get; set; }
        protected Clue.DAL.Session Session => _session = _session ?? new DAL.Session(RepositoriesPath);
    }
}
