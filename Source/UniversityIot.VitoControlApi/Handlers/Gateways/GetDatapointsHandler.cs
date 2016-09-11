namespace UniversityIot.VitoControlApi.Handlers.Gateways
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using RestSharp;
    using UniversityIot.Messages;
    using UniversityIot.VitoControlApi.Enums;
    using UniversityIot.VitoControlApi.Helpers;
    using UniversityIot.VitoControlApi.Models;
    using UniversityIot.VitoControlApi.Models.DataObjects;

    public class GetDatapointsHandler : IGetDatapointsHandler
    {
        /// <summary>
        /// The value converter
        /// </summary>
        private readonly IValueConverter valueConverter;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetDatapointsHandler"/> class.
        /// </summary>
        /// <param name="valueConverter">The value converter.</param>
        public GetDatapointsHandler(IValueConverter valueConverter)
        {
            this.valueConverter = valueConverter;
        }

        public async Task<GetGatewayDatapointsResponse> Handle(GetGatewayDatapointsRequest message)
        {
            var gatewayResponse = await GetGateway(message.Id.ToString());
            if (gatewayResponse.StatusCode == HttpStatusCode.NotFound)
            {
                return new GetGatewayDatapointsResponse()
                {
                    ErrorModel = new ErrorModel(ErrorType.NotFound)
                };
            }

            var gatewaySettingsResponse = await GetGatewaySettings(message.Id.ToString());
            if (gatewaySettingsResponse.StatusCode == HttpStatusCode.NotFound)
            {
                return new GetGatewayDatapointsResponse()
                {
                    ErrorModel = new ErrorModel(ErrorType.NotFound)
                };
            }

            var kolibriResponse = await ReadValuesFromKolibri(gatewaySettingsResponse.Data.Select(x => x.HexAdress));

            var datapoints = AssignValues(gatewaySettingsResponse.Data, kolibriResponse.Data);

            var response = new GetGatewayDatapointsResponse()
            {
                Data = datapoints
            };

            return response;
        }

        /// <summary>
        /// Reads the values from kolibri.
        /// </summary>
        /// <param name="addressList">The address list.</param>
        /// <returns></returns>
        private static Task<IRestResponse<List<Messages.KolibriValue>>> ReadValuesFromKolibri(IEnumerable<string> addressList)
        {
            var restClient = new RestClient(ConfigurationManager.AppSettings["ServiceEndpoints:Kolibri"]);
            var kolibriRequest = new RestRequest("kolibri", Method.GET);
            foreach (var address in addressList)
            {
                kolibriRequest.AddQueryParameter("addresses", address);
            }

            return restClient.ExecuteTaskAsync<List<Messages.KolibriValue>>(kolibriRequest);
        }

        /// <summary>
        /// Gets the gateway.
        /// </summary>
        /// <param name="gatewayId">The gateway identifier.</param>
        /// <returns></returns>
        private static Task<IRestResponse<Messages.Gateway>> GetGateway(string gatewayId)
        {
            var restClient = new RestClient(ConfigurationManager.AppSettings["ServiceEndpoints:Gateways"]);

            var gatewayRequest = new RestRequest("gateways/{id}", Method.GET);
            gatewayRequest.AddUrlSegment("id", gatewayId);

            return restClient.ExecuteTaskAsync<Messages.Gateway>(gatewayRequest);
        }

        /// <summary>
        /// Gets the gateway settings.
        /// </summary>
        /// <param name="gatewayId">The gateway identifier.</param>
        /// <returns></returns>
        private static Task<IRestResponse<List<Messages.GatewaySetting>>> GetGatewaySettings(string gatewayId)
        {
            var restClient = new RestClient(ConfigurationManager.AppSettings["ServiceEndpoints:Gateways"]);

            var gatewaySettingsRequest = new RestRequest("gateways/settings", Method.GET);
            gatewaySettingsRequest.AddUrlSegment("id", gatewayId);

            return restClient.ExecuteTaskAsync<List<Messages.GatewaySetting>>(gatewaySettingsRequest);
        }

        /// <summary>
        /// Assigns the values.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="kolibriValues">The kolibri values.</param>
        /// <returns></returns>
        private List<GatewayDatapoint> AssignValues(IEnumerable<GatewaySetting> settings, IEnumerable<KolibriValue> kolibriValues)
        {
            var datapoints = new List<GatewayDatapoint>();

            foreach (var setting in settings)
            {
                var datapoint = new GatewayDatapoint()
                {
                    Id = setting.Id,
                    Description = setting.Description,
                    HexAdress = setting.HexAdress,
                    IsReadOnly = setting.IsReadOnly,
                    Value = this.valueConverter.ConvertFromDevice(setting, kolibriValues.FirstOrDefault(y => y.HexAddress.Equals(setting.HexAdress))?.Value)
                };

                datapoints.Add(datapoint);
            }

            return datapoints;
        }
    }
}