namespace UniversityIot.VitoControlApi.Models
{
    using System.Collections.Generic;
    using UniversityIot.VitoControlApi.Models.DataObjects;

    /// <summary>
    /// Gateways datapoints response model
    /// </summary>
    public class GetGatewayDatapointsResponse : Response<IEnumerable<GatewayDatapoint>>
    {
    }
}