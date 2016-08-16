namespace UniversityIot.GatewaysService.Http
{
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;

    /// <summary>
    /// Result for setting challege header
    /// </summary>
    public class AddChallengeOnUnauthorizedResult : IHttpActionResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddChallengeOnUnauthorizedResult" /> class.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="challenge">The challenge.</param>
        /// <param name="innerResult">The inner result.</param>
        public AddChallengeOnUnauthorizedResult(HttpRequestMessage request, AuthenticationHeaderValue challenge, IHttpActionResult innerResult)
        {
            this.Challenge = challenge;
            this.InnerResult = innerResult;
        }

        /// <summary>
        /// Gets the challenge.
        /// </summary>
        /// <value>
        /// The challenge.
        /// </value>
        public AuthenticationHeaderValue Challenge { get; private set; }

        /// <summary>
        /// Gets the inner result.
        /// </summary>
        /// <value>
        /// The inner result.
        /// </value>
        public IHttpActionResult InnerResult { get; private set; }

        /// <summary>
        /// Creates an <see cref="T:System.Net.Http.HttpResponseMessage" /> asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>
        /// A task that, when completed, contains the <see cref="T:System.Net.Http.HttpResponseMessage" />.
        /// </returns>
        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = await this.InnerResult.ExecuteAsync(cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                //// Only add one challenge per authentication scheme.
                if (response.Headers.WwwAuthenticate.All(h => h.Scheme != this.Challenge.Scheme))
                {
                    response.Headers.WwwAuthenticate.Add(this.Challenge);
                }
            }
            return response;
        }
    }
}