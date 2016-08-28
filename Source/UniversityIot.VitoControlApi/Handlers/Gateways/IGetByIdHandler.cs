namespace UniversityIot.VitoControlApi.Handlers.Gateways
{
    using System.Threading.Tasks;
    using UniversityIot.VitoControlApi.Models;

    public interface IGetByIdHandler
    {
        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        Task<GetGatewayResponse> Handle(GetGatewayRequest message);
    }
}