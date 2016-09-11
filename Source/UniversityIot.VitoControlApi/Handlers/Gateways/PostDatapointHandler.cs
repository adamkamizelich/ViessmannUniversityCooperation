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

    public class PostDatapointHandler : IPostDatapointHandler
    {
        /// <summary>
        /// The value converter
        /// </summary>
        private readonly IValueConverter valueConverter;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostDatapointHandler"/> class.
        /// </summary>
        /// <param name="valueConverter">The value converter.</param>
        public PostDatapointHandler(IValueConverter valueConverter)
        {
            this.valueConverter = valueConverter;
        }

        public async Task<PostGatewayDatapointResponse> Handle(PostGatewayDatapointRequest message)
        {
            var gatewayResponse = await GetGateway(message.Id.ToString());
            if (gatewayResponse.StatusCode == HttpStatusCode.NotFound)
            {
                return new PostGatewayDatapointResponse()
                {
                    ErrorModel = new ErrorModel(ErrorType.NotFound)
                };
            }

            var gatewaySettingsResponse = await GetGatewaySettings(message.Id.ToString());
            if (gatewaySettingsResponse.StatusCode == HttpStatusCode.NotFound)
            {
                return new PostGatewayDatapointResponse()
                {
                    ErrorModel = new ErrorModel(ErrorType.NotFound)
                };
            }

            var datapoint = gatewaySettingsResponse.Data.FirstOrDefault(x => x.Id == message.DatapointId);
            if (datapoint == null)
            {
                return new PostGatewayDatapointResponse()
                {
                    ErrorModel = new ErrorModel(ErrorType.NotFound)
                };
            }

            if (datapoint.IsReadOnly)
            {
                return new PostGatewayDatapointResponse()
                {
                    ErrorModel = new ErrorModel(ErrorType.UnsupportedMethod)
                };
            }

            var kolibriResponse = await SaveValueToKolibri(datapoint, message.Value);
            var response = new PostGatewayDatapointResponse()
            {
                Data = new SuccessInfo()
                {
                    Success = kolibriResponse.StatusCode == HttpStatusCode.OK
                }
            };

            return response;
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
        /// Saves the value to kolibri.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private Task<IRestResponse> SaveValueToKolibri(GatewaySetting setting, string value)
        {
            var restClient = new RestClient(ConfigurationManager.AppSettings["ServiceEndpoints:Kolibri"]);
            var kolibriRequest = new RestRequest("kolibri", Method.POST);

            var body = new KolibriValue()
            {
                Value = this.valueConverter.ConvertToDevice(setting, value),
                HexAddress = setting.HexAdress
            };

            kolibriRequest.RequestFormat = DataFormat.Json;
            kolibriRequest.AddBody(body);

            return restClient.ExecuteTaskAsync(kolibriRequest);
        }
    }
}