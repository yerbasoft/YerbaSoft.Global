using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIR.Common.Log
{
    /// <summary>
    /// Clase administradora de logueo y traza de aplicaciones
    /// </summary>
    public class Logger
    {
        public LoggerConfig Config { get; private set; }
        private ILogger _Logger { get; set; }

        public Logger() : this("default", null) { }
        public Logger(string name) : this(name, null) { }
        public Logger(string name, LoggerConfig config)
        {
            this.Config = config ?? new LoggerConfig();
            var nConfig = new NLog.Config.LoggingConfiguration();

            var t = new NLog.Targets.FileTarget(name)
            {
                FileName = this.Config.LogFile.GetFullTemplateFileName(name),
                Layout = this.Config.LogFile.LogTemplate
            };
            nConfig.AddTarget(t);
            nConfig.LoggingRules.Add(new NLog.Config.LoggingRule(name, LogLevel.Trace, LogLevel.Error, t));

            this._Logger = new NLog.LogFactory(nConfig).GetLogger(name);
        }

        #region Public Methods

        public Logger Trace(string msg, object data = null) => Trace(new string[] { msg }, data);
        public Logger Trace(IEnumerable<string> msgs, object data = null)
        {
            return DoLog(LogLevel.Trace, (this.Config.Console.ShowTraceLabel ? "TRACE " : ""), msgs, data, this.Config.Console.ShowTrace);
        }

        public Logger Debug(string msg, object data = null) => Debug(new string[] { msg }, data);
        public Logger Debug(IEnumerable<string> msgs, object data = null)
        {
            return DoLog(NLog.LogLevel.Debug, (this.Config.Console.ShowDebugLabel ? "DEBUG " : ""), msgs, data, this.Config.Console.ShowDebug);
        }

        public Logger Info(string msg, object data = null) => Info(new string[] { msg }, data);
        public Logger Info(IEnumerable<string> msgs, object data = null)
        {
            return DoLog(NLog.LogLevel.Info, (this.Config.Console.ShowInfoLabel ? "INFO " : ""), msgs, data, this.Config.Console.ShowInfo);
        }

        public Logger Warn(string msg, object data = null) => Warn(new string[] { msg }, data);
        public Logger Warn(IEnumerable<string> msgs, object data = null)
        {
            return DoLog(NLog.LogLevel.Warn, (this.Config.Console.ShowWarnLabel ? "WARN " : ""), msgs, data, this.Config.Console.ShowWarn);
        }

        public Logger Error(string msg, object data = null) => Error(new string[] { msg }, data);
        public Logger Error(Exception ex, object data = null) => Error(new string[] { ex.GetFullDescription() }, data);
        public Logger Error(string msg, Exception ex, object data = null) => Error(new string[] { msg, ex.GetFullDescription() }, data);
        public Logger Error(IEnumerable<string> msgs, object data = null)
        {
            return DoLog(NLog.LogLevel.Error, (this.Config.Console.ShowErrorLabel ? "ERROR " : ""), msgs, data, this.Config.Console.ShowError);
        }

        public DTO.Response Log(DTO.Response response)
        {
            if (response == null)
                return response;

            var info = response.Messages.Where(p => !p.EsError).Select(p => p.Text ?? p.Ex?.GetFullDescription());
            var error = response.Messages.Where(p => p.EsError).Select(p => p.Text ?? p.Ex?.GetFullDescription());

            Info(info);
            Error(error);

            return response;
        }

        public DTO.Response<T> Log<T>(DTO.Response<T> response)
        {
            if (response == null)
                return response;

            var info = response.Messages.Where(p => !p.EsError).Select(p => p.Text ?? p.Ex?.GetFullDescription());
            var error = response.Messages.Where(p => p.EsError).Select(p => p.Text ?? p.Ex?.GetFullDescription());

            Info(info);
            Error(error);

            return response;
        }

        #endregion

        #region Core Methods

        /// <summary>
        /// Funcion genérica para todos los tipos de logs
        /// </summary>
        /// <param name="level">Nivel de log</param>
        /// <param name="prefix">prefijo a mostrar para el nivel</param>
        /// <param name="msgs">lista de mensajes a mostrar</param>
        /// <param name="data">objeto adicional a mostrar sus datos</param>
        /// <param name="showInConsole">indica si se debe mostrar por consola según la configuracion</param>
        /// <returns></returns>
        private Logger DoLog(LogLevel level, string prefix, IEnumerable<string> msgs, object data, bool showInConsole)
        {
            if (this.Config.LogFile.ShowInLogFile)
            {
                var toFile = msgs.ToList();
                if (data != null)
                    toFile.Add("Reference: " + Newtonsoft.Json.JsonConvert.SerializeObject(data));

                DoShowInLogFile(level, toFile);
            }

            if (this.Config.Console.ShowInConsole && showInConsole)
            {
                DoShowInConsole(msgs.Select(p => prefix + p));
            }

            return this;
        }

        /// <summary>
        /// Muestra una lista de mensajes ya procesados en la consola
        /// </summary>
        /// <param name="msgs"></param>
        private void DoShowInConsole(IEnumerable<string> msgs)
        {
            try
            {
                var prefix = "";
                if (!string.IsNullOrEmpty(this.Config.Console.DateFormat))
                    prefix = DateTime.Now.ToString(this.Config.Console.DateFormat) + " ";

                if (!string.IsNullOrEmpty(prefix))
                {
                    if (msgs.Count() > 1)
                    {
                        System.Console.WriteLine(prefix);
                        prefix = "\t";
                    }
                }

                foreach (var msg in msgs)
                    System.Console.WriteLine($"{prefix}{msg}");
            }
            catch { }
        }

        /// <summary>
        /// Imprime una lista de resultados a una archivo d elog
        /// </summary>
        /// <param name="level">nivel de log</param>
        /// <param name="msgs">lista de mensajes</param>
        private void DoShowInLogFile(LogLevel level, IEnumerable<string> msgs)
        {
            try
            {
                lock (this._Logger)
                {
                    foreach (var msg in msgs)
                        this._Logger.Log(level, msg);
                }
            }
            catch { }
        }

        #endregion
    }
}
