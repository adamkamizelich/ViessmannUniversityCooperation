using System.Threading.Tasks;
using UniversityIot.VitoControlApi.Models;

namespace UniversityIot.VitoControlApi.Handlers.Gateways
{
    public interface IGetDatapointsHandler
    {
        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        Task<GetGatewayDatapointsResponse> Handle(GetGatewayDatapointsRequest message);
    }
}