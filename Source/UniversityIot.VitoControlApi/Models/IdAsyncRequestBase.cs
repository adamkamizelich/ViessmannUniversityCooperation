namespace UniversityIot.VitoControlApi.Models
{
    /// <summary>
    /// Base class for models with id
    /// </summary>
    /// <typeparam name="TResponse">Type of response model</typeparam>
    public abstract class IdAsyncRequestBase<TResponse> : AsyncRequestBase<TResponse>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public string Id { get; set; }
    }
}