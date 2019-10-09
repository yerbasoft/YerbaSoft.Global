using SIR.BcoCiudad.Common.DTO.Config;
using SIR.Common.Console;
using SIR.Common.Log;
using System;

namespace SIR.BcoCiudad.Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = new Logger("SIR.BcoCiudad", new LoggerConfig() { Console = new LoggerConfig.ConsoleConfig() { ShowInConsole = true } });
            try
            {
                log.Info("== Inicio de Procesamiento de SIR.BcoCiudad ==");
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

                var config = Newtonsoft.Json.JsonConvert.DeserializeObject<Application>(System.IO.File.ReadAllText("SIR.BcoCiudad.Config.json"));

                var processor = Factory.GetBcoCiudadService(log, config);
                if (options.ProcesarArchivo)
                {
                    processor.ProcesarArchivos(options.Reprocesar);
                }

                if (options.Exportacion)
                {
                    processor.ExportarBUI();
                }

                if (options.Notificaciones)
                {
                    Factory.GetNotificacionService(log, config).ProcesarNotificaciones();
                }

            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            finally
            {
                log.Info("== Fin de Procesamiento de SIR.BcoCiudad ==");
            }
        }
    }
}
