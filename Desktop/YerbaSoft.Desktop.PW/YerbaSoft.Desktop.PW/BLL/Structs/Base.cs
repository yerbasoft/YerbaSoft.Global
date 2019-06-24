using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.Windows.API;

namespace YerbaSoft.Desktop.PW.BLL.Structs
{
    public class Base : IDisposable
    {
        // Constantes de Offset de memoria
        public static readonly IntPtr FreezeScreenOffset = new IntPtr(0x009B4A04);
        public static readonly IntPtr Barco1Offset = new IntPtr(0x005B4594 + 0x00400000);
        //public static readonly IntPtr IdPj1Offset = new IntPtr(0x005B3F8C);

        // Tools
        private ProcessManager Manager { get; set; }

        // Listeners de Memoria
        private Dictionary<string, Guid> Listeners = new Dictionary<string, Guid>();

        // Listeners Status
        public bool IsAntiFreezeActive => Listeners.ContainsKey("AntiFreezeScreen");

        // Events
        public event EventHandler<bool> OnFreezeScreenStatusChanged;

        // Propiedades
        public Barco1 Barco1 { get; set; }

        public Base(ProcessManager manager, Configuration.Cuenta config)
        {
            this.Manager = manager;

            // Cargo valores fijos
            this.Barco1 = new Barco1(manager, this.Manager.Memory.ReadInt(Base.Barco1Offset), config);

            // Escucho valores Variables
            SetFreezeScreen(config.AntiFreeze ?? true);
        }

        /// <summary>
        /// Activa o desactiva la funcionalidad de Freezear la pantalla
        /// </summary>
        /// <param name="active"></param>
        public void SetFreezeScreen(bool active)
        {
            if (!active && Listeners.ContainsKey("AntiFreezeScreen"))
            {
                this.Manager.Memory.RemoveMemoryChange(Listeners["AntiFreezeScreen"]);
                Listeners.Remove("AntiFreezeScreen");
                OnFreezeScreenStatusChanged?.Invoke(this, false);
            }

            if (active && !Listeners.ContainsKey("AntiFreezeScreen"))
            {
                Listeners.Add("AntiFreezeScreen", this.Manager.Memory.OnMemoryChange<byte>(Base.FreezeScreenOffset, (b) => { this.Manager.Memory.Write(Base.FreezeScreenOffset, (byte)1); }));
                OnFreezeScreenStatusChanged?.Invoke(this, true);
            }
        }

        public void Dispose()
        {
            foreach (var l in Listeners.Values)
                this.Manager.Memory.RemoveMemoryChange(l);
            Listeners.Clear();

            // Dispose en Cascada
            this.Barco1?.Dispose();
            this.Barco1 = null;
        }


        public uint GetIsTageted()
        {
            var offsets = new uint[] { 0x005B45A0, 0xAC, 0x8, 0x38 };
            uint pos = 0x00400000;
            foreach (var offset in offsets)
            {
                pos += offset;
                pos = this.Manager.Memory.ReadInt(new IntPtr(pos));
            }
            return pos;
        }

        public uint GetHieroHP()
        {
            var offsets = new uint[] { 0xBD0048, 0x2E8, 0xC, 0x50, 0xB0 };
            uint pos = 0x00400000;
            foreach (var offset in offsets)
            {
                pos += offset;
                pos = this.Manager.Memory.ReadInt(new IntPtr(pos));
            }
            return pos;
        }
    }
}
