namespace UniversityIot.VitoControlApi.Models
{
    using System.Web.Http.ModelBinding;
    using UniversityIot.VitoControlApi.Http.Binders;

    /// <summary>
    /// Gateway request model
    /// </summary>
    [ModelBinder(typeof(CustomModelBinder<GetGatewayRequest, GetGatewayResponse>))]
    public class GetGatewayRequest : IdAsyncRequestBase<GetGatewayResponse>
    {
    }
}