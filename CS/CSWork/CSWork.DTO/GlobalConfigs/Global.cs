using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSWork.DTO.GlobalConfigs
{
    public class Global
    {
        public event Event<bool> OnModuleAlarmaChange;

        public bool StartWithWindows { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        private bool _ModuleAlarma = true;
        public bool ModuleAlarma
        {
            get { return _ModuleAlarma; }
            set
            {
                _ModuleAlarma = value;
                OnModuleAlarmaChange?.Invoke(value);
            }
        }
        public bool ModuleMemory { get; set; } = true;
        public bool ModuleAmbiente { get; set; } = true;
        public bool ModuleLink { get; set; } = true;

        public GCBARed GCBARed { get; set; } = new GCBARed();
        public DefaultApps App { get; set; } = new DefaultApps();
    }
}
