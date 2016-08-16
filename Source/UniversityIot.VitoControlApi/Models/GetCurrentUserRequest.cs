namespace UniversityIot.VitoControlApi.Models
{
    using System.Web.Http.ModelBinding;
    using UniversityIot.VitoControlApi.Http.Binders;

    [ModelBinder(typeof(CustomModelBinder<GetCurrentUserRequest, GetUserResponse>))]
    public class GetCurrentUserRequest : AsyncRequestBase<GetUserResponse>
    {
    }
}