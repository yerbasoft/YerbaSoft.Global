using SIR.Common.Console;
using SIR.Sync.DTO.Config;
using System;

namespace SIR.Sync
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = new SIR.Common.Log.Logger("SIR.Sync", new Common.Log.LoggerConfig() { Console = new Common.Log.LoggerConfig.ConsoleConfig() { ShowInConsole = true } });

            try
            {
                log.Info("== Inicio de Procesamiento de SIR.Sync ==");
                log.Info($"Version: {System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}");
                log.Info($"Command: {AppDomain.CurrentDomain.FriendlyName} {string.Join(' ', args)}");

                var optionsRes = new ParseArgs().Parse<Arguments>(args);
                if (optionsRes.ExistsErrorMessages)
                {
                    log.Log(optionsRes);
                    Console.ReadLine();
                    return;
                }
                var options = optionsRes.Data;

                if (options.ShowHelp)
                {
                    Console.WriteLine("Listado de Parámetros válidos para la aplicación");
                    Console.WriteLine(new ParseArgs().GetHelpText<Arguments>());
                    return;
                }

                var config = Newtonsoft.Json.JsonConvert.DeserializeObject<Application>(System.IO.File.ReadAllText("SIR.Sync.Config.json"));

                if (options.ProcesarSync)
                {
                    var procesador = new BLL.ProcesadorSync(log, config);

                    procesador.ProcesarNotificaciones(options.FechaDesde, options.FechaHasta);
                    procesador.ProcesarAnulaciones(options.FechaDesde, options.FechaHasta);
                    procesador.ProcesarVencimientos();
                    procesador.ProcesarNotificacionesPE();
                }

                if (options.ProcesarRendicion)
                {
                    var procesador = new BLL.ProcesadorRendiciones(log, config);

                    procesador.ProcesarRendicionDAI(options.FechaRendicion, options.DiasRendicion);
                }

            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            finally
            {
                log.Info("== Fin de Procesamiento de SIR.Sync ==");
            }
        }
    }
}
