namespace UniversityIot.VitoControlApi.Models
{
    using System.Web.Http.ModelBinding;
    using UniversityIot.VitoControlApi.Http.Binders;

    /// <summary>
    /// User request model
    /// </summary>
    [ModelBinder(typeof(CustomModelBinder<GetUserRequest, GetUserResponse>))]
    public class GetUserRequest : IdAsyncRequestBase<GetUserResponse>
    {
    }
}