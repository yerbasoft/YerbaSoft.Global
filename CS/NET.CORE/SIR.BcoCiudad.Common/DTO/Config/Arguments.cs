using SIR.Common.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.BcoCiudad.Common.DTO.Config
{
    public class Arguments
    {
        [Option("?", "Muestra la ayuda para el uso de parámetros")]
        public bool ShowHelp { get; set; }

        [Option("p", "Procesar Archivos de Banco Ciudad")]
        public bool ProcesarArchivo { get; set; }

        [Option("pr", "Indica si se deben incluir el reproceso delotes anteriores")]
        public bool Reprocesar { get; set; }

        [Option("e", "Proceso de Exportación de Boletas")]
        public bool Exportacion { get; set; }

        [Option("l", "Proceso de Notificaciones")]
        public bool Notificaciones { get; set; }
    }
}
