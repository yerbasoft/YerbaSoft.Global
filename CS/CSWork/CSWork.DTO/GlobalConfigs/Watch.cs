using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSWork.DTO.GlobalConfigs
{
    public class Watch
    {
        /// <summary>
        /// Indica la hora en la que el reloj siempre pausará la tarea que se está realizando. Ejemplo: 1800 (18:00 hs)
        /// </summary>
        public int? AlwaysStopWatchAtTime { get; set; }
    }
}
