using System.Threading.Tasks;
using UniversityIot.VitoControlApi.Models;

namespace UniversityIot.VitoControlApi.Handlers.Gateways
{
    public interface IPostDatapointHandler
    {
        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        Task<PostGatewayDatapointResponse> Handle(PostGatewayDatapointRequest message);
    }
}