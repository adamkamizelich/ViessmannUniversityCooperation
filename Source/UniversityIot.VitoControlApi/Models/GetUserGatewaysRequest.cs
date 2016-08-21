namespace UniversityIot.VitoControlApi.Models
{
    using System.Web.Http.ModelBinding;
    using UniversityIot.VitoControlApi.Http.Binders;

    /// <summary>
    /// User gateways request model
    /// </summary>
    [ModelBinder(typeof(CustomModelBinder<GetUserGatewaysRequest, GetUserGatewaysResponse>))]
    public class GetUserGatewaysRequest : IdAsyncRequestBase<GetUserGatewaysResponse>
    {
    }
}