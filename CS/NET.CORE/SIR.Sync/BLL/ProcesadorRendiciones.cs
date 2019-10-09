using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SIR.Common.Log;
using SIR.Sync.DTO.Config;

namespace SIR.Sync.BLL
{
    internal class ProcesadorRendiciones
    {
        private Logger Logger;
        private Application Config;
        public SIR.Common.DAL.EF.EFDAO DAO { get; private set; }

        public ProcesadorRendiciones(Logger log, Application config)
        {
            this.Logger = log;
            this.Config = config;
            this.DAO = new SIR.Common.DAL.EF.EFDAO(config.ConnectionString, "SYN", Assembly.GetExecutingAssembly());
        }

        internal void ProcesarRendicionDAI(DateTime fecha, int dias)
        {
            IList<DTO.StoredProcedures.RendicionPagos> pendientes = new DTO.StoredProcedures.RendicionPagos[0];
            try
            {
                var deps = DAO.Config.Get("RendicionPagosDAIDependencias", Logger)?.Value;
                var parms = new SIR.Common.DAL.SP.Parameters()
                            .AddParam("pFechaDesde", fecha.AddDays(-dias + 1))
                            .AddParam("pFechaHasta", fecha)
                            .AddParam("pDependencias", deps.Split(','));

                pendientes = DAO.ExecProcedure<DTO.StoredProcedures.RendicionPagos>("SIR.GETRENDPAGOSDAI", parms);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error al obtener las boletas pendientes de notificación desde la base de datos.", ex);
            }

            var path = DAO.Config.Get("RendicionPagosDAIFilePath", Logger)?.Value;
            var tasks = new Queue<Task>();
            for (var d = 1; d <= dias; d++)
            {
                var procFecha = fecha.AddDays(1 - d);
                var f = procFecha.ToString("ddMMyyyy");
                var data = pendientes.Where(p => p.Fecha == f).ToArray();
                tasks.Enqueue(new Task<bool>((obj) =>
                {
                    var _logger = (SIR.Common.Log.Logger)((dynamic)obj).Logger;
                    var _fecha = (DateTime)((dynamic)obj).Fecha;
                    var _path = (string)((dynamic)obj).Path;
                    var _pagos = (DTO.StoredProcedures.RendicionPagos[])((dynamic)obj).Pagos;
                    
                    GenerarArchivoRendicion(_logger, _fecha, _path, _pagos);
                    return true;
                }, new { Logger, Fecha = procFecha, Path = path, Pagos = data }));
            }

            var async = new SIR.Common.Thread.TaskManager();
            async.ProcesarEnParalelo(tasks, Config.RendicionesDAI_Paralelismo);
        }

        private void GenerarArchivoRendicion(SIR.Common.Log.Logger logger, DateTime fecha, string path, DTO.StoredProcedures.RendicionPagos[] pagos)
        {
            try
            {
                logger.Info($"Se encontraron {pagos.Length} pagos a rendir para la fecha {fecha:dd/MM/yyyy}.");

                var content = new StringBuilder();

                // Cabecera
                content.AppendLine($"0{DateTime.Now:ddMMyyyyHHmmss}");

                // Detalles
                foreach (var pago in pagos)
                {
                    var row = "1";
                    row += pago.CodBarras.PadLeft(59, '0').Substring(0, 59);
                    row += $"{pago.FechaPago:ddMMyyyy}";
                    row += pago.Canal;
                    row += pago.Pos.ToString().PadLeft(5, '0');
                    row += pago.NroCbte.ToString().PadLeft(20, '0');

                    content.AppendLine(row);
                }

                // Footer
                content.Append($"9{pagos.Length.ToString().PadLeft(8, '0')}");

                var filename = System.IO.Path.Combine(path, $"RENDICIONSIR_{fecha:yyyyMMdd}.txt");
                System.IO.File.WriteAllText(filename, content.ToString(), Encoding.UTF8);

                logger.Info($"Se ha generado el archivo {filename}");
            }
            catch (Exception ex)
            {
                logger.Error($"Error al generar el archivo de Rendiciones DAI del día {fecha:dd/MM/yyyy}", ex);
            }
        }
    }
}
