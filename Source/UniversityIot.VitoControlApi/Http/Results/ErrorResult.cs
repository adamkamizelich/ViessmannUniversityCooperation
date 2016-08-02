namespace UniversityIot.VitoControlApi.Http.Results
{
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using UniversityIot.VitoControlApi.Enums;
    using UniversityIot.VitoControlApi.Models;

    /// <summary>
    /// Custom error result
    /// </summary>
    public class ErrorResult : RequestResultBase
    {
        /// <summary>
        /// The HTTP code
        /// </summary>
        private readonly HttpStatusCode httpCode;

        /// <summary>
        /// The error type
        /// </summary>
        private readonly ErrorType errorType;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResult" /> class.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="httpCode">The HTTP code.</param>
        public ErrorResult(HttpRequestMessage request, HttpStatusCode httpCode)
            : base(request)
        {
            this.httpCode = httpCode;
            switch (this.httpCode)
            {
                case HttpStatusCode.NotFound:
                    this.errorType = ErrorType.NotFound;
                    break;

                case HttpStatusCode.UnsupportedMediaType:
                    this.errorType = ErrorType.UnsupportedMediaType;
                    break;

                case HttpStatusCode.MethodNotAllowed:
                    this.errorType = ErrorType.UnsupportedMethod;
                    break;

                default:
                    this.errorType = ErrorType.InternalServerError;
                    break;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResult"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="httpCode">The HTTP code.</param>
        /// <param name="errorType">Type of the error.</param>
        public ErrorResult(HttpRequestMessage request, HttpStatusCode httpCode, ErrorType errorType)
            : base(request)
        {
            this.httpCode = httpCode;
            this.errorType = errorType;
        }

        /// <summary>
        /// Creates an <see cref="T:System.Net.Http.HttpResponseMessage" /> asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>
        /// A task that, when completed, contains the <see cref="T:System.Net.Http.HttpResponseMessage" />.
        /// </returns>
        public override Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(this.httpCode);
            response.RequestMessage = this.Request;
            var errorModel = new ErrorModel(this.errorType);
            response.Content = new StringContent(JsonConvert.SerializeObject(errorModel), Encoding.UTF8, "application/json");
            return Task.FromResult(response);
        }
    }
}