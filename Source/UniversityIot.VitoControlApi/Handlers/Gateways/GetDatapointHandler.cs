namespace UniversityIot.VitoControlApi.Handlers.Gateways
{
    using System.Configuration;
    using System.Net;
    using System.Threading.Tasks;
    using RestSharp;
    using UniversityIot.Messages;
    using UniversityIot.VitoControlApi.Enums;
    using UniversityIot.VitoControlApi.Helpers;
    using UniversityIot.VitoControlApi.Models;
    using UniversityIot.VitoControlApi.Models.DataObjects;

    public class GetDatapointHandler : IGetDatapointHandler
    {
        /// <summary>
        /// The value converter
        /// </summary>
        private readonly IValueConverter valueConverter;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetDatapointHandler"/> class.
        /// </summary>
        /// <param name="valueConverter">The value converter.</param>
        public GetDatapointHandler(IValueConverter valueConverter)
        {
            this.valueConverter = valueConverter;
        }

        public async Task<GetGatewayDatapointResponse> Handle(GetGatewayDatapointRequest message)
        {
            var gatewayResponse = await GetGateway(message.GatewayId.ToString());
            if (gatewayResponse.StatusCode == HttpStatusCode.NotFound)
            {
                return new GetGatewayDatapointResponse()
                {
                    ErrorModel = new ErrorModel(ErrorType.NotFound)
                };
            }

            var gatewaySettingResponse = await GetGatewaySetting(message.DatapointId.ToString());
            if (gatewaySettingResponse.StatusCode == HttpStatusCode.NotFound)
            {
                return new GetGatewayDatapointResponse()
                {
                    ErrorModel = new ErrorModel(ErrorType.NotFound)
                };
            }

            var kolibriResponse = await ReadValuesFromKolibri(gatewaySettingResponse.Data.HexAdress);

            var datapoint = AssignValues(gatewaySettingResponse.Data, kolibriResponse.Data);

            var response = new GetGatewayDatapointResponse()
            {
                Data = datapoint
            };

            return response;
        }

        /// <summary>
        /// Reads the values from kolibri.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        private static Task<IRestResponse<KolibriValue>> ReadValuesFromKolibri(string address)
        {
            var restClient = new RestClient(ConfigurationManager.AppSettings["ServiceEndpoints:Kolibri"]);
            var kolibriRequest = new RestRequest("kolibri", Method.GET);
            kolibriRequest.AddQueryParameter("addresses", address);

            return restClient.ExecuteTaskAsync<KolibriValue>(kolibriRequest);
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
        /// Gets the gateway setting.
        /// </summary>
        /// <param name="settingId">The setting identifier.</param>
        /// <returns></returns>
        private static Task<IRestResponse<GatewaySetting>> GetGatewaySetting(string settingId)
        {
            var restClient = new RestClient(ConfigurationManager.AppSettings["ServiceEndpoints:Gateways"]);

            var gatewaySettingRequest = new RestRequest("gateways/settings/{id}", Method.GET);
            gatewaySettingRequest.AddUrlSegment("id", settingId);

            return restClient.ExecuteTaskAsync<GatewaySetting>(gatewaySettingRequest);
        }

        /// <summary>
        /// Assigns the values.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <param name="kolibriValue">The kolibri values.</param>
        /// <returns></returns>
        private GatewayDatapoint AssignValues(GatewaySetting setting, KolibriValue kolibriValue)
        {
            var datapoint = new GatewayDatapoint()
            {
                Id = setting.Id,
                Description = setting.Description,
                HexAdress = setting.HexAdress,
                IsReadOnly = setting.IsReadOnly,
                Value = this.valueConverter.ConvertFromDevice(setting, kolibriValue.Value)
            };

            return datapoint;
        }
    }
}