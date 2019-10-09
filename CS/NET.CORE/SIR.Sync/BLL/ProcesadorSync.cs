using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VEP = SIR.Common.Connector.DTO.VEP;
using Recauda = SIR.Common.Connector.DTO.Recauda;

namespace SIR.Sync.BLL
{
    internal class ProcesadorSync
    {
        private SIR.Common.Log.Logger Logger;
        private SIR.Common.DAL.SimpleDAO Session;
        private DTO.Config.Application Config;
        private SIR.Common.Connector.VEPConnector VEPConnector;
        private SIR.Common.Connector.RecaudaConnector RecaudaConnector;

        public ProcesadorSync(SIR.Common.Log.Logger logger, DTO.Config.Application config)
        {
            this.Logger = logger;
            this.Config = config;
            this.Session = new SIR.Common.DAL.SimpleDAO(config.ConnectionString);

            this.VEPConnector = new SIR.Common.Connector.VEPConnector(new Uri(Session.GetConfig("SYN", "VEPUrl")), Session.GetConfig("SYN", "VEPUser"), Session.GetConfig("SYN", "VEPPass"));
            this.RecaudaConnector = new SIR.Common.Connector.RecaudaConnector(new Uri(Session.GetConfig("SYN", "RecaudaUrl")));
        }

        internal void ProcesarNotificaciones(DateTime desde, DateTime hasta)
        {
            IList<DTO.StoredProcedures.Pendiente> pendientes = new DTO.StoredProcedures.Pendiente[0];
            try
            {
                var parms = new SIR.Common.DAL.SP.Parameters()
                            .AddParam("pFechaDesde", desde)
                            .AddParam("pFechaHasta", hasta);

                pendientes = Session.ExecProcedure<DTO.StoredProcedures.Pendiente>("SIR.GETBUIPENDNOTIF", parms);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error al obtener las boletas pendientes de notificación desde la base de datos.");
                Logger.Error(ex);
            }

            var notificaciones = new Queue<Task>();
            foreach (var notif in pendientes)
            {
                notificaciones.Enqueue(new Task<bool>((obj) => {

                    var _logger = (SIR.Common.Log.Logger)((dynamic)obj).Logger;
                    var _notif = (DTO.StoredProcedures.Pendiente)((dynamic)obj).notif;
                    var _connector = (SIR.Common.Connector.VEPConnector)((dynamic)obj).connector;
                    try
                    {
                        var res = _connector.NotificarPago(new VEP.Request.NotificarPagoRequest()
                        {
                            Numero = _notif.Numero,
                            Traza = _notif.IdCobro,
                            AConfirmar = _notif.AConfirmar
                        });
                        _logger.Log(res);

                        if (res.Success)
                            _logger.Info($"Se estableció la Traza {_notif.IdCobro} para la Boleta {_notif.Numero}({_notif.Id})");
                        else
                            _logger.Error($"Ocurrió un error al establecer la Traza {_notif.IdCobro} para la Boleta {_notif.Numero}({_notif.Id}).");

                        if (res.Success && _notif.AConfirmar)
                        {
                            var baja = _connector.BajaFacturaPMC(new VEP.Request.BajaFacturaPMCRequest()
                            {
                                NroFactura = _notif.Numero,
                                NroUsuario = string.Empty
                            });
                            _logger.Log(baja);

                            if (baja.Success)
                                _logger.Info($"Baja PMC para la boleta {_notif.Numero}({_notif.Id}): {baja.Data}");
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error($"Error al procesar la Notificación de Pago de la Boleta {_notif.Numero}({_notif.Id})");
                        _logger.Error(ex);
                    }

                    return true;

                }, new { notif, Logger, connector = this.VEPConnector }));
            }

            Logger.Info($"Se han encontrado {notificaciones.Count} Boletas a Notificar.");
            var async = new SIR.Common.Thread.TaskManager();
            async.ProcesarEnParalelo(notificaciones, this.Config.NotificacionesBUI_Paralelismo);
        }

        internal void ProcesarAnulaciones(DateTime desde, DateTime hasta)
        {
            IList<DTO.StoredProcedures.Pendiente> pendientes = new DTO.StoredProcedures.Pendiente[0];
            try
            {
                var parms = new SIR.Common.DAL.SP.Parameters()
                            .AddParam("pFechaDesde", desde)
                            .AddParam("pFechaHasta", hasta);

                pendientes = Session.ExecProcedure<DTO.StoredProcedures.Pendiente>("SIR.GETBUIPENDANULA", parms);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error al obtener las boletas pendientes de anulación desde la base de datos.");
                Logger.Error(ex);
            }

            var notificaciones = new Queue<Task>();
            foreach (var notif in pendientes)
            {
                notificaciones.Enqueue(new Task<bool>((obj) => {

                    var _logger = (SIR.Common.Log.Logger)((dynamic)obj).Logger;
                    var _notif = (DTO.StoredProcedures.Pendiente)((dynamic)obj).notif;
                    var _connector = (SIR.Common.Connector.VEPConnector)((dynamic)obj).connector;
                    try
                    {
                        var res = _connector.Anular(new VEP.Request.AnularRequest()
                        {
                            Numero = _notif.Numero
                        });
                        _logger.Log(res);

                        if(res.Success)
                            _logger.Info($"Se Anuló la Boleta {_notif.Numero}({_notif.Id})");
                        else
                            _logger.Error($"No se pudo anular la Boleta {_notif.Numero}({_notif.Id}).");

                        if (res.Success && _notif.AConfirmar)
                        {
                            var baja = _connector.BajaFacturaPMC(new VEP.Request.BajaFacturaPMCRequest()
                            {
                                NroFactura = _notif.Numero,
                                NroUsuario = string.Empty
                            });
                            _logger.Log(baja);

                            if (baja.Success)
                                _logger.Info($"Baja PMC para la boleta {_notif.Numero}({_notif.Id}): {baja.Data}");
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error($"Error al procesar la Anulación de la Boleta {_notif.Numero}({_notif.Id})");
                        _logger.Error(ex);
                    }

                    return true;

                }, new { notif, Logger, connector = this.VEPConnector }));
            }

            Logger.Info($"Se han encontrado {notificaciones.Count} Boletas a Anular.");
            var async = new SIR.Common.Thread.TaskManager();
            async.ProcesarEnParalelo(notificaciones, this.Config.Anulaciones_Paralelismo);
        }

        internal void ProcesarVencimientos()
        {
            IList<DTO.StoredProcedures.Pendiente> pendientes = new DTO.StoredProcedures.Pendiente[0];
            try
            {
                pendientes = Session.ExecProcedure<DTO.StoredProcedures.Pendiente>("SIR.GETBUIVENCIDAS", null);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error al obtener las boletas pendientes de cancelación por vencimiento desde la base de datos.");
                Logger.Error(ex);
            }

            var notificaciones = new Queue<Task>();
            foreach (var notif in pendientes)
            {
                notificaciones.Enqueue(new Task<bool>((obj) => {

                    var _logger = (SIR.Common.Log.Logger)((dynamic)obj).Logger;
                    var _notif = (DTO.StoredProcedures.Pendiente)((dynamic)obj).notif;
                    var _connector = (SIR.Common.Connector.VEPConnector)((dynamic)obj).connector;
                    try
                    {
                        var res = _connector.Cancelar(new VEP.Request.CancelarRequest()
                        {
                            Id = _notif.Id,
                            Numero = _notif.Numero
                        });
                        _logger.Log(res);

                        if (res.Success)
                            _logger.Info($"Se Canceló la Boleta {_notif.Numero}({_notif.Id}) por Vencimiento de la misma");
                        else
                            _logger.Error($"No se pudo cancelar la Boleta {_notif.Numero}({_notif.Id}) por Vencimiento de la misma");

                        if (res.Success && _notif.AConfirmar)
                        {
                            var baja = _connector.BajaFacturaPMC(new VEP.Request.BajaFacturaPMCRequest()
                            {
                                NroFactura = _notif.Numero,
                                NroUsuario = string.Empty
                            });
                            _logger.Log(baja);

                            if (baja.Success)
                                _logger.Info($"Baja PMC para la boleta {_notif.Numero}({_notif.Id}): {baja.Data}");
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error($"Error al procesar la Cancelación de la Boleta {_notif.Numero}({_notif.Id}) por Vencimiento de la misma");
                        _logger.Error(ex);
                    }

                    return true;

                }, new { notif, Logger, connector = this.VEPConnector }));
            }

            Logger.Info($"Se han encontrado {notificaciones.Count} Boletas a Cancelar por Vencimiento.");
            var async = new SIR.Common.Thread.TaskManager();
            async.ProcesarEnParalelo(notificaciones, this.Config.Vencimientos_Paralelismo);
        }

        internal void ProcesarNotificacionesPE()
        {
            IList<DTO.StoredProcedures.PendientePE> pendientes = new DTO.StoredProcedures.PendientePE[0];
            try
            {
                pendientes = Session.ExecProcedure<DTO.StoredProcedures.PendientePE>("SIR.GETPAGOSBUIPENDPE", null);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error al obtener los pagos de BUIs externos a PE desde la base de datos.");
                Logger.Error(ex);
            }

            var peUser = Session.GetConfig("SYN", "RecaudaUser");
            var pePass = Session.GetConfig("SYN", "RecaudaPass");
            var notificaciones = new Queue<Task>();
            foreach (var notif in pendientes)
            {
                notificaciones.Enqueue(new Task<bool>((obj) => {

                    var _logger = (SIR.Common.Log.Logger)((dynamic)obj).Logger;
                    var _notif = (DTO.StoredProcedures.PendientePE)((dynamic)obj).notif;
                    var _connector = (SIR.Common.Connector.RecaudaConnector)((dynamic)obj).connector;
                    var _vepConnector = (SIR.Common.Connector.VEPConnector)((dynamic)obj).vepConnector;
                    var _user = (string)((dynamic)obj).user;
                    var _pass = (string)((dynamic)obj).pass;

                    try
                    {
                        var res = _connector.NotificarPostbackBUI(new Recauda.Request.NotificarPostbackBUIRequest()
                        {
                            IdCobro = _notif.IdCobro,
                            IdPostback = _notif.IdPostback,
                            FechaPago = _notif.Fecha,
                            NroBUI = _notif.Numero,
                            User = _user,
                            Pass = _pass
                        }).Result;

                        _logger.Log(res);
                        if (res.Success && res.Data)
                            _logger.Info($"Se ha notificado el Pago de BUI a Pago Electrónico. Boleta:{_notif.Numero}({_notif.IdBoleta}), Cobro:{_notif.Fecha:dd/MM/yyyy HH:mm}({_notif.IdCobro})");
                        else
                            _logger.Info($"Error al notificar pago de BUI a Pago Electrónico. Boleta:{_notif.Numero}({_notif.IdBoleta}), Cobro:{_notif.Fecha:dd/MM/yyyy HH:mm}({_notif.IdCobro})");
                    }
                    catch (Exception ex)
                    {
                        _logger.Error($"Error al procesar la Notificación de Pago de la Boleta:{notif.Numero}({notif.IdBoleta}), Cobro:{notif.Fecha:dd/MM/yyyy HH:mm}({notif.IdCobro})");
                        _logger.Error(ex);
                    }

                    return true;

                }, new { notif, Logger, connector = this.RecaudaConnector, vepConnector = this.VEPConnector, user = peUser, pass = pePass }));
            }

            Logger.Info($"Se han encontrado {notificaciones.Count} Boletas a Informar al Sistema de Recaudaciones Electrónico.");
            var async = new SIR.Common.Thread.TaskManager();
            async.ProcesarEnParalelo(notificaciones, this.Config.NotificacionesPE_Paralelismo);
        }
    }
}
