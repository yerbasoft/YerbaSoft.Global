using SIR.Common.DTO;
using System;
using Request = SIR.Common.Connector.DTO.VEP.Request;
//using Response = SIR.Common.Connector.DTO.VEP.Response;

namespace SIR.Common.Connector
{
    public class VEPConnector : Connector
    {
        public VEPConnector(Uri url, string user, string pass) : base(url, new Http.ConnectorHeader(user, pass).SetUseContentTypeJSON(true)) { }
        
        public Response<string> NotificarPago(Request.NotificarPagoRequest data) => Post<string>("BUI/NotificarPago", data);
        public Response<string> Anular(Request.AnularRequest data) => Post<string>("BUI/Anular", data);
        public Response<Guid> Cancelar(Request.CancelarRequest data) => Post<Guid>("BUI/Cancelar", data);

        public Response<string> BajaFacturaPMC(Request.BajaFacturaPMCRequest data) => Post<string>("BUI/BajaFacturaPMC", data);
    }
}
