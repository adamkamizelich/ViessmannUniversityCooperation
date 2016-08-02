namespace UniversityIot.VitoControlApi.Models
{
    using MediatR;

    /// <summary>
    /// Base request model
    /// </summary>
    /// <typeparam name="TResponse">Type of response model</typeparam>
    public abstract class AsyncRequestBase<TResponse> : IAsyncRequest<TResponse>
    {        
    }
}
