using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.Sync.DTO.Config
{
    public class Application
    {
        public string ConnectionString { get; set; }

        public int NotificacionesBUI_Paralelismo { get; set; }
        public int Anulaciones_Paralelismo { get; set; }
        public int Vencimientos_Paralelismo { get; set; }
        public int NotificacionesPE_Paralelismo { get; set; }
        public int RendicionesDAI_Paralelismo { get; set; }
    }
}
