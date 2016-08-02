namespace UniversityIot.VitoControlApi.Handlers
{
    using System.Threading.Tasks;
    using MediatR;
    using UniversityIot.VitoControlApi.Models;

    /// <summary>
    /// Base handler with validation
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public abstract class AsyncBaseHandler<TRequest, TResponse> : IAsyncRequestHandler<TRequest, TResponse>
        where TRequest : AsyncRequestBase<TResponse>
        where TResponse : ResponseBase
    {
        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>Response model</returns>
        public virtual async Task<TResponse> Handle(TRequest message)
        {
            return await this.InternalHandle(message);
        }

        /// <summary>
        /// Internals of handling message
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>Response model</returns>
        protected abstract Task<TResponse> InternalHandle(TRequest message);        
    }
}