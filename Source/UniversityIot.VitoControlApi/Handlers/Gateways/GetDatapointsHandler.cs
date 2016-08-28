namespace UniversityIot.VitoControlApi.Handlers.Gateways
{
    using System;
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

    public class GetDatapointsHandler : IGetDatapointsHandler
    {
        public async Task<GetGatewayDatapointsResponse> Handle(GetGatewayDatapointsRequest message)
        {
            var restClient = new RestClient(ConfigurationManager.AppSettings["ServiceEndpoints:Gateways"])
            {
                Authenticator = new HttpBasicAuthenticator(ConfigurationManager.AppSettings["ServiceEndpoints:Username"], ConfigurationManager.AppSettings["ServiceEndpoints:Password"])
            };

            var gatewayRequest = new RestRequest("gateways/{id}", Method.GET);
            gatewayRequest.AddUrlSegment("id", message.Id.ToString());

            var gatewayResponse = await restClient.ExecuteTaskAsync<Messages.Gateway>(gatewayRequest);
            if (gatewayResponse.StatusCode == HttpStatusCode.NotFound)
            {
                return new GetGatewayDatapointsResponse()
                {
                    ErrorModel = new ErrorModel(ErrorType.NotFound)
                };
            }

            var gatewaySettingsRequest = new RestRequest("gateways/settings", Method.GET);
            gatewaySettingsRequest.AddUrlSegment("id", message.Id.ToString());

            var gatewaySettingsResponse = await restClient.ExecuteTaskAsync<List<Messages.GatewaySetting>>(gatewaySettingsRequest);
            if (gatewaySettingsResponse.StatusCode == HttpStatusCode.NotFound)
            {
                return new GetGatewayDatapointsResponse()
                {
                    ErrorModel = new ErrorModel(ErrorType.NotFound)
                };
            }

            var datapoints = Mapper.Map<IEnumerable<GatewayDatapoint>>(gatewaySettingsResponse.Data).ToList();

            var random = new Random();

            foreach (var datapoint in datapoints)
            {
                datapoint.Value = random.Next(15, 30).ToString();
            }

            var response = new GetGatewayDatapointsResponse()
            {
                Data = datapoints
            };

            return response;
        }
    }
}