using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using YerbaSoft.Desktop.PW.Client.PWI_1_3_6_2265;
using YerbaSoft.Desktop.PW.Client.PWI_1_3_6_2265.Structs;

namespace YerbaSoft.Desktop.PW.BLL
{
    public class PWClient : IDisposable
    {
        internal Process Process;
        public DTO.Configuration.Cuenta Config;
        public DAL.CuentaConfig dbConfig;
        public YerbaSoft.Windows.API.ProcessManager Manager;
        public YerbaSoft.Windows.API.MemoryManager MemMgr => Manager?.Memory;

        public Mem.PWMem Mem { get; set; }
        public Auto.AutoManager Auto { get; set; }
        public Actions.PWActions Action { get; set; }

        public event EventHandler<PWClient> OnDisposing;
        public event EventHandler<string> OnMessageAvailable;

        public PWClient(Process process, DTO.Configuration.Cuenta config, DAL.CuentaConfig dbConfig)
        {
            this.Process = process;
            this.Config = config;
            this.dbConfig = dbConfig;
            this.dbConfig.OnHideWinChatChanged += (sender, e) => { this.Action.Global.ShowWin(!e, BLL.Mem.Basic.GUIObj.GUIs.WinChat); };

            this.Manager = new YerbaSoft.Windows.API.ProcessManager(this.Process);

            this.Mem = new Mem.PWMem(this);
            this.Auto = new Auto.AutoManager(this);
            this.Action = new Actions.PWActions(this);

            this.Mem.OnConnect += (sender, e) => { if (!e) this.Dispose(); }; // solo se dispara cuando se logró conectar alguna vez y se desconecta
            this.Mem.Link.OnPlayerConnect += (sender, e) => {
                if (e)
                {
                    new Thread(() => {
                        Thread.Sleep(3000);
                        this.Action.Global.ShowWin(!this.dbConfig.HideWinChat, BLL.Mem.Basic.GUIObj.GUIs.WinChat);
                    }).Start();
                }
            };
        }
        
        public void Dispose()
        {
            this.OnDisposing?.Invoke(this, this);

            this.Mem?.Dispose();
            this.Mem = null;

            this.Auto?.Dispose();
            this.Auto = null;
        }

        /// <summary>
        /// establece el mensaje principal a mostrar en el cliente
        /// </summary>
        /// <param name="message"></param>
        internal void SetMessage(string message)
        {
            OnMessageAvailable?.Invoke(this, message);
        }
    }
}
