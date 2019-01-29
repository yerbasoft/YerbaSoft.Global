using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHelper.Customs.BLL
{
    public enum Explorers
    {
        Chrome,
        Opera,
        Firefox
    }

    public class ExplorersManager
    {
        public static string Get(Explorers explore)
        {
            switch(explore)
            {
                case Explorers.Chrome: return @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
                case Explorers.Firefox: return @"C:\Program Files\Mozilla Firefox\firefox.exe";
                case Explorers.Opera: return @"C:\Program Files\Opera\launcher.exe";
                default: return null;
            }
        }
    }
}
