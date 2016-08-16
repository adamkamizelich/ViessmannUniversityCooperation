namespace UniversityIot.VitoControlApi.Handlers.Gateways
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using AutoMapper;
    using RestSharp;
    using RestSharp.Authenticators;
    using UniversityIot.VitoControlApi.Enums;
    using UniversityIot.VitoControlApi.Models;
    using UniversityIot.VitoControlApi.Models.DataObjects;

    public class PostDatapointHandler : AsyncBaseHandler<PostGatewayDatapointRequest, PostGatewayDatapointResponse>
    {
        protected override async Task<PostGatewayDatapointResponse> InternalHandle(PostGatewayDatapointRequest message)
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
                return new PostGatewayDatapointResponse()
                {
                    ErrorModel = new ErrorModel(ErrorType.NotFound)
                };
            }

            var gatewaySettingsRequest = new RestRequest("gateways/settings", Method.GET);
            gatewaySettingsRequest.AddUrlSegment("id", message.Id);

            var gatewaySettingsResponse = await restClient.ExecuteTaskAsync<List<Messages.GatewaySetting>>(gatewaySettingsRequest);
            if (gatewaySettingsResponse.StatusCode == HttpStatusCode.NotFound)
            {
                return new PostGatewayDatapointResponse()
                {
                    ErrorModel = new ErrorModel(ErrorType.NotFound)
                };
            }

            var gatewaySettings = Mapper.Map<IEnumerable<GatewayDatapoint>>(gatewaySettingsResponse.Data).ToList();
            if (gatewaySettings.All(x => x.Id.ToString() != message.DatapointId))
            {
                return new PostGatewayDatapointResponse()
                {
                    ErrorModel = new ErrorModel(ErrorType.NotFound)
                };
            }



            var response = new PostGatewayDatapointResponse()
            {
                Data = new SuccessInfo()
                {
                    Success = true
                }
            };

            return response;
        }
    }
}