using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.Common.Log
{
    /// <summary>
    /// Estructura de configuración del Logger
    /// </summary>
    public class LoggerConfig
    {
        public class ConsoleConfig
        {
            /// <summary>
            /// Indica si se utiliza la salida por consola
            /// </summary>
            public bool ShowInConsole { get; set; } = true;
            /// <summary>
            /// Formato de fecha a mostrar en el log. Establecer null para no mostrar la fecha
            /// </summary>
            public string DateFormat { get; set; } = "dd-MM-yyyy HH:mm:ss.ff";

            /// <summary>
            /// Indica si se muestran por consola los logs de tipo TRACE
            /// </summary>
            public bool ShowTrace { get; set; } = true;
            /// <summary>
            /// Indica si se muestra por consola la leyenda "TRACE" para los logs de tipo TRACE
            /// </summary>
            public bool ShowTraceLabel { get; set; } = true;

            /// <summary>
            /// Indica si se muestran por consola los logs de tipo DEBUG
            /// </summary>
            public bool ShowDebug { get; set; } = true;
            /// <summary>
            /// Indica si se muestra por consola la leyenda "DEBUG" para los logs de tipo DEBUG
            /// </summary>
            public bool ShowDebugLabel { get; set; } = true;

            /// <summary>
            /// Indica si se muestran por consola los logs de tipo INFO
            /// </summary>
            public bool ShowInfo { get; set; } = true;
            /// <summary>
            /// Indica si se muestra por consola la leyenda "INFO" para los logs de tipo INFO
            /// </summary>
            public bool ShowInfoLabel { get; set; } = true;

            /// <summary>
            /// Indica si se muestran por consola los logs de tipo WARN
            /// </summary>
            public bool ShowWarn { get; set; } = true;
            /// <summary>
            /// Indica si se muestra por consola la leyenda "WARN" para los logs de tipo WARN
            /// </summary>
            public bool ShowWarnLabel { get; set; } = true;

            /// <summary>
            /// Indica si se muestran por consola los logs de tipo ERROR
            /// </summary>
            public bool ShowError { get; set; } = true;
            /// <summary>
            /// Indica si se muestra por consola la leyenda "ERROR" para los logs de tipo ERROR
            /// </summary>
            public bool ShowErrorLabel { get; set; } = true;
        }

        public class LogFileConfig
        {
            /// <summary>
            /// Indica si se deben exponer los logs por archivo
            /// </summary>
            public bool ShowInLogFile { get; set; } = true;

            /// <summary>
            /// Devuelve o establece el template a utilizar al registrar un log
            /// </summary>
            public string LogTemplate { get; set; } = "${longdate} ${uppercase:${level}} ${message}";

            /// <summary>
            /// Indica la subcarpeta/s desde el directorio de la aplicación, donde se guardará el log.
            /// </summary>
            public string SubFolder { get; set; } = "log/";

            /// <summary>
            /// Indica el formato para el nombre de archivo
            /// </summary>
            public string FileName { get; set; } = "${shortdate}.log";

            /// <summary>
            /// Indica si el nombre de archivo de salida de log utilizará como prefijo el nombre establecido para el logger
            /// </summary>
            public bool UseLoggerNameAsFileNamePrefix { get; set; } = true;

            /// <summary>
            /// Devuelve la ruta completa en forma de template del archivo de log.
            /// </summary>
            /// <returns></returns>
            public string GetFullTemplateFileName(string loggerName)
            {
                var filename = "${basedir}/";

                if (!string.IsNullOrEmpty(this.SubFolder))
                {
                    if (this.SubFolder.StartsWith("/") || this.SubFolder.StartsWith("\\"))
                        filename += this.SubFolder.Substring(1);
                    else
                        filename += this.SubFolder;
                }

                if (!filename.EndsWith("/") && !filename.EndsWith("\\"))
                    filename += "/";

                if (this.UseLoggerNameAsFileNamePrefix)
                {
                    filename += loggerName;
                    if (string.IsNullOrEmpty(this.FileName))
                        filename += ".log";
                    else
                        filename += " ";
                }

                if (!string.IsNullOrEmpty(this.FileName))
                {
                    if (this.FileName.StartsWith("/") || this.FileName.StartsWith("\\"))
                        filename += this.FileName.Substring(1);
                    else
                        filename += this.FileName;
                }

                return filename;
            }
        }

        /// <summary>
        /// Configuración para el output por consola
        /// </summary>
        public ConsoleConfig Console { get; set; } = new ConsoleConfig();

        /// <summary>
        /// Configuración para el output por log de archivo
        /// </summary>
        public LogFileConfig LogFile { get; set; } = new LogFileConfig();
    }
}
