using SIR.Common.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.Sync.DTO.Config
{
    public class Arguments
    {
        [Option("?", "Muestra la ayuda para el uso de parámetros")]
        public bool ShowHelp { get; set; }

        [Option("s", "Procesar Sync")]
        public bool ProcesarSync { get; set; }

        [Option("sd", "Fecha de Inicio de proceso Sync")]
        public DateTime FechaDesde { get; set; } = DateTime.Now.AddMonths(-1);

        [Option("sh", "Fecha de Fin de proceso Sync")]
        public DateTime FechaHasta { get; set; } = DateTime.Now;

        [Option("r", "Procesar Rendicion de Pagos")]
        public bool ProcesarRendicion { get; set; }

        [Option("rf", "Fecha a Procesar la Rendicion de Pagos")]
        public DateTime FechaRendicion { get; set; } = DateTime.Now.AddDays(-2);

        [Option("rd", "Cantidad de dias de Reproceso de Rendicion de Pagos")]
        public int DiasRendicion { get; set; } = 1;
    }
}
