namespace UniversityIot.VitoControlApi.Handlers.Users
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
    /// Get user by id
    /// </summary>
    public class GetByIdHandler : AsyncBaseHandler<GetUserRequest, GetUserResponse>
    {
        /// <summary>
        /// Internals of handling message
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>
        /// Response model
        /// </returns>
        protected override async Task<GetUserResponse> InternalHandle(GetUserRequest message)
        {
            var restClient = new RestClient(ConfigurationManager.AppSettings["ServiceEndpoints:Users"])
            {
                Authenticator = new HttpBasicAuthenticator(ConfigurationManager.AppSettings["ServiceEndpoints:Username"], ConfigurationManager.AppSettings["ServiceEndpoints:Password"])
            };

            var userRequest = new RestRequest("users/{id}", Method.GET);
            userRequest.AddUrlSegment("id", message.Id);

            var userResponse = await restClient.ExecuteTaskAsync<Messages.User>(userRequest);
            if (userResponse.StatusCode == HttpStatusCode.NotFound)
            {
                return new GetUserResponse()
                {
                    ErrorModel = new ErrorModel(ErrorType.NotFound)
                };
            }

            var user = Mapper.Map<User>(userResponse.Data);

            var response = new GetUserResponse()
            {
                Data = user
            };

            return response;
        }
    }
}