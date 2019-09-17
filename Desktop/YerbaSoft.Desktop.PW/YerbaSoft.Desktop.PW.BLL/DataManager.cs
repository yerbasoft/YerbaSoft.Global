using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.Desktop.PW.DTO.Configuration.Villa;
using YerbaSoft.Desktop.PW.DTO.Configuration.WinModes;
using YerbaSoft.Desktop.PW.DTO.Data;

namespace YerbaSoft.Desktop.PW.BLL
{
    public class DataManager
    {
        public static List<MapPoint> GoTo { get; set; }
        public static Villa Villa { get; set; }
        public static List<DTO.Configuration.Partys.PartyConfig> Partys { get; set; }

        public YerbaSoft.DAL.Repositories.XmlSimpleRepository<MapPoint> GotoRepository;
        public YerbaSoft.DAL.Repositories.XmlSimpleRepository<WinMode> WinModes;
        public YerbaSoft.DAL.Repositories.XmlSimpleRepository<DTO.Configuration.Partys.PartyConfig> PartysRepository;

        public DataManager()
        {
            GotoRepository = new YerbaSoft.DAL.Repositories.XmlSimpleRepository<DTO.Data.MapPoint>("YerbaSoft.Desktop.PW.Goto.xml");
            WinModes = new YerbaSoft.DAL.Repositories.XmlSimpleRepository<WinMode>("YerbaSoft.Desktop.PW.WinModes.xml");
            PartysRepository = new YerbaSoft.DAL.Repositories.XmlSimpleRepository<DTO.Configuration.Partys.PartyConfig>("YerbaSoft.Desktop.PW.Partys.xml");
        }

    }
}
