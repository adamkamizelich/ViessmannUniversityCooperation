namespace UniversityIot.VitoControlApi.Http.Routing
{
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using UniversityIot.VitoControlApi.Http.ExceptionsHandling;

    /// <summary>
    /// Handler to check supported media type
    /// </summary>
    public class MediaTypeMessageHandler : DelegatingHandler
    {
        /// <summary>
        /// The maximum request length exceeded code
        /// </summary>
        private const int MaximumRequestLengthExceededCode = -2147467259;

        /// <summary>
        /// Sends an HTTP request to the inner handler to send to the server as an asynchronous operation.
        /// </summary>
        /// <param name="request">The HTTP request message to send to the server.</param>
        /// <param name="cancellationToken">A cancellation token to cancel operation.</param>
        /// <returns>
        /// Returns <see cref="T:System.Threading.Tasks.Task`1" />. The task object representing the asynchronous operation.
        /// </returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request != null &&
                request.Content != null &&
                request.Content.Headers != null &&
                request.Content.Headers.ContentLength.HasValue && request.Content.Headers.ContentLength.Value > 0)
            {
                if (request.Content.Headers.ContentType == null)
                {
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                }

                var mediaType = request.Content.Headers.ContentType.MediaType;
                var formatters = request.GetConfiguration().Formatters;
                try
                {
                    var requestContentBytes = await request.Content.ReadAsByteArrayAsync();
                    await ValidateContent(mediaType, formatters, requestContentBytes);
                }
                catch (System.Web.HttpException ex)
                {
                    if (ex.ErrorCode == MaximumRequestLengthExceededCode)
                    {
                        throw new HttpException(HttpStatusCode.RequestEntityTooLarge);
                    }

                    throw;
                }
            }

            return await base.SendAsync(request, cancellationToken);
        }

        /// <summary>
        /// Validates the content.
        /// </summary>
        /// <param name="mediaType">Type of the media.</param>
        /// <param name="formatters">The formatters.</param>
        /// <param name="requestContentBytes">The request content bytes.</param>
        /// <returns>Validation task</returns>
        private static Task ValidateContent(string mediaType, MediaTypeFormatterCollection formatters, byte[] requestContentBytes)
        {
            return Task.Run(
                () =>
                {
                    var hasFormatterForContentType = formatters.Any(formatter => formatter.SupportedMediaTypes.Any(e => e.MediaType == mediaType));
                    if (!hasFormatterForContentType)
                    {
                        throw new HttpException(HttpStatusCode.UnsupportedMediaType);
                    }

                    if (mediaType == "multipart/form-data")
                    {
                        return;
                    }

                    string content = Encoding.UTF8.GetString(requestContentBytes);
                    try
                    {
                        JToken.Parse(content);
                    }
                    catch (JsonReaderException)
                    {
                        throw new HttpException(HttpStatusCode.UnsupportedMediaType);
                    }
                });
        }
    }
}