namespace UniversityIot.VitoControlApi.Handlers.Gateways
{
    using System.Configuration;
    using System.Net;
    using System.Threading.Tasks;
    using AutoMapper;
    using RestSharp;
    using RestSharp.Authenticators;
    using UniversityIot.VitoControlApi.Enums;
    using UniversityIot.VitoControlApi.Models;
    using UniversityIot.VitoControlApi.Models.DataObjects;

    /// <summary>
    /// Get by id handler
    /// </summary>
    /// <seealso cref="UniversityIot.VitoControlApi.Handlers.AsyncBaseHandler{UniversityIot.VitoControlApi.Models.GetGatewayRequest, UniversityIot.VitoControlApi.Models.GetGatewayResponse}" />
    public class GetByIdHandler : AsyncBaseHandler<GetGatewayRequest, GetGatewayResponse>
    {
        protected override async Task<GetGatewayResponse> InternalHandle(GetGatewayRequest message)
        {
            var restClient = new RestClient(ConfigurationManager.AppSettings["ServiceEndpoints:Gateways"])
            {
                Authenticator = new HttpBasicAuthenticator(ConfigurationManager.AppSettings["ServiceEndpoints:Username"], ConfigurationManager.AppSettings["ServiceEndpoints:Password"])
            };

            var gatewayRequest = new RestRequest("gateways/{id}", Method.GET);
            gatewayRequest.AddUrlSegment("id", message.Id);

            var gatewayResponse = await restClient.ExecuteTaskAsync<Messages.Gateway>(gatewayRequest);
            if (gatewayResponse.StatusCode == HttpStatusCode.NotFound)
            {
                return new GetGatewayResponse()
                {
                    ErrorModel = new ErrorModel(ErrorType.NotFound)
                };
            }

            var gateway = Mapper.Map<Gateway>(gatewayResponse.Data);

            var response = new GetGatewayResponse()
            {
                Data = gateway
            };

            return response;
        }
    }
}