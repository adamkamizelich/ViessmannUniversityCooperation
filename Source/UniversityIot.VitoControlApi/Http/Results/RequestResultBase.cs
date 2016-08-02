namespace UniversityIot.VitoControlApi.Http.Results
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;

    /// <summary>
    /// Base class for request results
    /// </summary>
    public abstract class RequestResultBase : IHttpActionResult
    {        
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestResultBase"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        protected RequestResultBase(HttpRequestMessage request)
        {
            this.Request = request;
        }

        /// <summary>
        /// Gets the request.
        /// </summary>
        protected HttpRequestMessage Request { get; private set; }

        /// <summary>
        /// Creates an <see cref="T:System.Net.Http.HttpResponseMessage" /> asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>
        /// A task that, when completed, contains the <see cref="T:System.Net.Http.HttpResponseMessage" />.
        /// </returns>
        public abstract Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken);
    }
}