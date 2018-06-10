using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Web.Games.Clue.BLL.Service
{
    internal class Service : IDisposable
    {
        protected DTO.Usuario CurrentUser;
        protected DAL.Session Session;

        public Service(DTO.Usuario currentUser)
        {
            this.Session = new DAL.Session($"{Factory.FilesPath}YerbaSoft.Web.Games.Config.xml", $"{Factory.FilesPath}YerbaSoft.Web.Games.Chat.xml");
            this.CurrentUser = currentUser;
        }
    
        public void Dispose()
        {
        }
    }
}
