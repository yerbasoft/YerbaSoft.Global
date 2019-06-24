using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.Windows.API;

namespace YerbaSoft.Desktop.PW.BLL.Structs
{
    public class Barco1 : IDisposable
    {
        // Constantes de OPffset de memoria
        public static readonly uint PJInfoOffset = 0x20;

        // Events
        /// <summary>
        /// Ocurre cuando cambian los datos de la estructura PJInfo
        /// </summary>
        public event EventHandler<PJInfo.Structure> OnPJInfoDataChanged;
        /// <summary>
        /// Ocurre cuando se connecta o desconecta el personaje
        /// </summary>
        public event EventHandler<PJInfo> OnPJInfoConnect;

        // Tools
        private ProcessManager Manager;
        private Configuration.Cuenta Config;
        private uint BasePointer;

        // Listeners de Memoria
        private Dictionary<string, Guid> Listeners = new Dictionary<string, Guid>();

        // Propiedades
        public PJInfo PJInfo { get; set; }
        
        public Barco1(ProcessManager manager, uint pointer, Configuration.Cuenta config)
        {
            this.Manager = manager;
            this.Config = config;
            this.BasePointer = pointer;
            
            // Cargo valores fijos
            
            // Escucho valores Variables
            Listeners.Add("PJInfo", this.Manager.Memory.OnMemoryChange<uint>(new IntPtr(BasePointer + PJInfoOffset), (b) => {
                if ((uint)b == 0 && PJInfo != null)
                {
                    PJInfo.Dispose();
                    PJInfo = null;
                    OnPJInfoConnect?.Invoke(this, null);
                }
                else if ((uint)b != 0)
                {
                    this.PJInfo = new PJInfo(this.Manager, (uint)b, this.Config);
                    OnPJInfoConnect?.Invoke(this, this.PJInfo);
                    this.PJInfo.OnInfoChanged += (sender, e) => { OnPJInfoDataChanged?.Invoke(this, e); };
                }
            }));
        }

        public void Dispose()
        {
            foreach (var l in Listeners.Values)
                this.Manager.Memory.RemoveMemoryChange(l);
            Listeners.Clear();

            // Dispose en Cascada
            PJInfo?.Dispose();
            PJInfo = null;

            OnPJInfoConnect?.Invoke(this, null);
        }
    }
}
