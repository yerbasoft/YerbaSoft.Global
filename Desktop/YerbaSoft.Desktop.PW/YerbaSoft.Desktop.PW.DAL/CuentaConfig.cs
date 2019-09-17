using System;
using System.Drawing;
using System.Linq;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Desktop.PW.DAL
{
    public class CuentaConfig : YerbaSoft.DAL.Repositories.XmlSimpleClass
    {
        /// <summary>
        /// Indica si hubo cambios
        /// </summary>
        [NoMap]
        public bool PendingChanges { get; set; }

        private const string SaveFileConfigPath = "YerbaSoft.Desktop.PW.CuentaConfigs.xml";

        [Direct] public Guid Id { get; set; }
        [Direct] public string Login { get; set; }

        // Coordenadas de la ventana PW
        [Direct] public int ScreenX { get; set; }
        [Direct] public int ScreenY { get; set; }

        [NoMap] private bool _HideWinChat { get; set; }
        [Direct] public bool HideWinChat { get => _HideWinChat; set { _HideWinChat = value; OnHideWinChatChanged?.Invoke(this, value); } }
        public EventHandler<bool> OnHideWinChatChanged;

        private AutoKeyConfig _AutoKey;
        [SubClass] public AutoKeyConfig AutoKey { get { return _AutoKey = _AutoKey ?? new AutoKeyConfig() { WinShowAttachParent = true }; } set { _AutoKey = value; } }
        private AutoSpotConfig _AutoSpot;
        [SubClass] public AutoSpotConfig AutoSpot { get { return _AutoSpot = _AutoSpot ?? new AutoSpotConfig() { WinShowAttachParent = true }; } set { _AutoSpot = value; } }
        private AutoAssistConfig _AutoAssist;
        [SubClass] public AutoAssistConfig AutoAssist { get { return _AutoAssist = _AutoAssist ?? new AutoAssistConfig() { WinShowAttachParent = true }; } set { _AutoAssist = value; } }
        private ShowInfoConfig _ShowInfo;
        [SubClass] public ShowInfoConfig ShowInfo { get { return _ShowInfo = _ShowInfo ?? new ShowInfoConfig() { WinShowAttachParent = true }; } set { _ShowInfo = value; } }


        public static DAL.CuentaConfig Get(string login)
        {
            var repo = new YerbaSoft.DAL.Repositories.XmlSimpleRepository<DAL.CuentaConfig>(SaveFileConfigPath);

            return repo.Find(p => p.Login == login).SingleOrDefault();
        }

        public void Save(Rectangle rect)
        {
            if (this.PendingChanges)
            {
                if (this.Id == default(Guid))
                    this.Id = Guid.NewGuid();

                var repo = new YerbaSoft.DAL.Repositories.XmlSimpleRepository<DAL.CuentaConfig>(SaveFileConfigPath);

                repo.UpsertEntity(this);
                repo.Commit();
                this.PendingChanges = false;
            }
        }
    }
}
