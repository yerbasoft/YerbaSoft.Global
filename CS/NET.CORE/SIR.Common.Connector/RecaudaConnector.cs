using SIR.Common.DTO;
using System;
using System.Threading.Tasks;
using Request = SIR.Common.Connector.DTO.Recauda.Request;
//using Response = SIR.Common.Connector.DTO.Recauda.Response;


namespace SIR.Common.Connector
{
    public class RecaudaConnector : Connector
    {
        public RecaudaConnector(Uri baseUrl) : base(baseUrl, null) { }

        private Recauda_InternalService.InternalServiceSoap GetInternalService()
        {
            var url = base.BaseUrl.AbsoluteUri + (base.BaseUrl.AbsoluteUri.EndsWith("/") ? "" : "/") + "InternalService.asmx";
            return new Recauda_InternalService.InternalServiceSoapClient(Recauda_InternalService.InternalServiceSoapClient.EndpointConfiguration.InternalServiceSoap12, url);
        }

        private Recauda_PagosService.PagosServiceSoap GetPagosService()
        {
            var url = base.BaseUrl.AbsoluteUri + (base.BaseUrl.AbsoluteUri.EndsWith("/") ? "" : "/") + "PagosService.asmx";
            return new Recauda_PagosService.PagosServiceSoapClient(Recauda_PagosService.PagosServiceSoapClient.EndpointConfiguration.PagosServiceSoap12, url);
        }

        public async Task<Response<bool>> NotificarPostbackBUI(Request.NotificarPostbackBUIRequest req)
        {
            try
            {
                var result = await GetInternalService().NotificarPostbackBUIAsync(req.IdCobro, req.IdPostback, req.NroBUI, req.FechaPago, req.User, req.Pass);
                return new Response<bool>(result);
            }
            catch (Exception ex)
            {
                return new Response<bool>(ex);
            }
        }
    }
}
