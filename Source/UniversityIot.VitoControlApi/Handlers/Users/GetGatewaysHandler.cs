namespace UniversityIot.VitoControlApi.Handlers.Users
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Net;
    using System.Threading.Tasks;
    using AutoMapper;
    using RestSharp;
    using UniversityIot.VitoControlApi.Enums;
    using UniversityIot.VitoControlApi.Models;
    using UniversityIot.VitoControlApi.Models.DataObjects;

    /// <summary>
    /// Get user gateways
    /// </summary>
    public class GetGatewaysHandler : IGetGatewaysHandler
    {
        /// <summary>
        /// Internals of handling message
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>User gateways model</returns>
        public async Task<GetUserGatewaysResponse> Handle(GetUserGatewaysRequest message)
        {
            var userInstallationsResponse = await GetUserInstallations(message);
            if (userInstallationsResponse.StatusCode == HttpStatusCode.NotFound)
            {
                return new GetUserGatewaysResponse()
                {
                    ErrorModel = new ErrorModel(ErrorType.NotFound)
                };
            }

            var userInstallations = userInstallationsResponse.Data;

            var gatewaysResponse = await GetGatewaysDetails(userInstallations);

            var gateways = Mapper.Map<IEnumerable<Gateway>>(gatewaysResponse.Data);

            var response = new GetUserGatewaysResponse()
            {
                Data = gateways
            };

            return response;
        }

        /// <summary>
        /// Gets the gateways details.
        /// </summary>
        /// <param name="userInstallations">The user installations.</param>
        /// <returns>User installations</returns>
        private static Task<IRestResponse<List<Messages.Gateway>>> GetGatewaysDetails(List<int> userInstallations)
        {
            var restClient = new RestClient(ConfigurationManager.AppSettings["ServiceEndpoints:Gateways"]);

            var gatewaysRequest = new RestRequest("gateways", Method.GET);

            foreach (var userInstallation in userInstallations)
            {
                gatewaysRequest.AddQueryParameter("ids", userInstallation.ToString());
            }

            return restClient.ExecuteTaskAsync<List<Messages.Gateway>>(gatewaysRequest);
        }

        /// <summary>
        /// Gets the user installations.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>List of gateways details</returns>
        private static Task<IRestResponse<List<int>>> GetUserInstallations(GetUserGatewaysRequest message)
        {
            var restClient = new RestClient(ConfigurationManager.AppSettings["ServiceEndpoints:Users"]);

            var userInstallationsRequest = new RestRequest("users/{id}/installations", Method.GET);
            userInstallationsRequest.AddUrlSegment("id", message.Id.ToString());

            return restClient.ExecuteTaskAsync<List<int>>(userInstallationsRequest);
        }
    }
}