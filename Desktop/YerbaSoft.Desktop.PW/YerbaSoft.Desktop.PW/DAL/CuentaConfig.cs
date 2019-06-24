using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Desktop.PW.DAL
{
    public class CuentaConfig : YerbaSoft.DAL.Repositories.XmlSimpleClass
    {
        private const string SaveFileConfigPath = "YerbaSoft.Desktop.PW.CuentaConfigs.xml";

        [Direct] public Guid Id { get; set; }
        [Direct] public string Login { get; set; }

        // Coordenadas de la ventana PW
        [Direct] public int ScreenX { get; set; }
        [Direct] public int ScreenY { get; set; }

        // Coordenadas del cliente
        [Direct] public int GameScreenX { get; set; }
        [Direct] public int GameScreenY { get; set; }
        [Direct] public int GameScreenWidth { get; set; }
        [Direct] public int GameScreenHeight { get; set; }

        private AutoKeyConfig _AutoKey;
        [SubClass] public AutoKeyConfig AutoKey { get { return _AutoKey = _AutoKey ?? new AutoKeyConfig(); } set { _AutoKey = value; } }
        private AutoSpotConfig _AutoSpot;
        [SubClass] public AutoSpotConfig AutoSpot { get { return _AutoSpot = _AutoSpot ?? new AutoSpotConfig(); } set { _AutoSpot = value; } }
        private AutoAssistConfig _AutoAssist;
        [SubClass] public AutoAssistConfig AutoAssist { get { return _AutoAssist = _AutoAssist ?? new AutoAssistConfig(); } set { _AutoAssist = value; } }

        public static DAL.CuentaConfig Get(string login)
        {
            var repo = new YerbaSoft.DAL.Repositories.XmlSimpleRepository<DAL.CuentaConfig>(SaveFileConfigPath);

            return repo.Find(p => p.Login == login).SingleOrDefault();
        }
        
        public void Save(BLL.Cuenta cuenta)
        {
            if (this.Id == default(Guid))
                this.Id = Guid.NewGuid();

            var rect = cuenta.Manager.GetWindowRect();
            this.GameScreenX = rect.X;
            this.GameScreenY = rect.Y;
            this.GameScreenWidth = rect.Width;
            this.GameScreenHeight = rect.Height;

            var repo = new YerbaSoft.DAL.Repositories.XmlSimpleRepository<DAL.CuentaConfig>(SaveFileConfigPath);

            repo.UpsertEntity(this);
            repo.Commit();
        }
    }
}
