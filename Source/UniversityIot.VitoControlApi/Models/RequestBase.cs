namespace UniversityIot.VitoControlApi.Models
{
    using MediatR;
    using UniversityIot.VitoControlApi.Http.Attributes;

    /// <summary>
    /// Base request model
    /// </summary>
    /// <typeparam name="TResponse">Type of response model</typeparam>
    [IgnoreQueryBinding]
    public abstract class RequestBase<TResponse> : IRequest<TResponse>
    {        
    }
}
