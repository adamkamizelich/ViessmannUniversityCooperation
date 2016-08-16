namespace UniversityIot.VitoControlApi.Models
{
    using System.Web.Http.ModelBinding;
    using UniversityIot.VitoControlApi.Http.Binders;

    /// <summary>
    /// Gateway's datapoints request model
    /// </summary>
    [ModelBinder(typeof(CustomModelBinder<GetGatewayDatapointsRequest, GetGatewayDatapointsResponse>))]
    public class GetGatewayDatapointsRequest : IdAsyncRequestBase<GetGatewayDatapointsResponse>
    {
    }
}