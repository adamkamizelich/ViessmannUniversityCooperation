namespace UniversityIot.VitoControlApi.Handlers.Users
{
    using System.Threading.Tasks;
    using UniversityIot.VitoControlApi.Models;

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
        protected override Task<GetUserResponse> InternalHandle(GetUserRequest message)
        {
            var response = new GetUserResponse()
            {
                Data = new Models.DataObjects.User()
            };

            return Task.FromResult(response);
        }
    }
}