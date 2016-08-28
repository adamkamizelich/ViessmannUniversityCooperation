namespace UniversityIot.VitoControlApi.Handlers.Users
{
    using System.Threading.Tasks;
    using UniversityIot.VitoControlApi.Models;

    public interface IGetGatewaysHandler
    {
        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>User gateways model</returns>
        Task<GetUserGatewaysResponse> Handle(GetUserGatewaysRequest message);
    }
}