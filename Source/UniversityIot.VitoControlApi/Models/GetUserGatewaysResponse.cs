namespace UniversityIot.VitoControlApi.Models
{
    using System.Collections.Generic;
    using UniversityIot.VitoControlApi.Models.DataObjects;

    /// <summary>
    /// User gateways response model
    /// </summary>
    public class GetUserGatewaysResponse : Response<IEnumerable<Gateway>>
    {
    }
}