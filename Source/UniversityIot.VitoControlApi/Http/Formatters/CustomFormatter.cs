namespace UniversityIot.VitoControlApi.Http.Formatters
{
    using System;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using Newtonsoft.Json;

    /// <summary>
    /// Json media type formatter for Estrella
    /// </summary>
    public class CustomFormatter : JsonMediaTypeFormatter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFormatter"/> class.
        /// </summary>
        public CustomFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/json"));
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("multipart/form-data"));
            this.SerializerSettings.Formatting = Formatting.Indented;
        }

        /// <summary>
        /// Sets the default headers for content that will be formatted using this formatter. This method is called from the <see cref="T:System.Net.Http.ObjectContent" /> constructor. This implementation sets the Content-Type header to the value of mediaType if it is not null. If it is null it sets the Content-Type to the default media type of this formatter. If the Content-Type does not specify a charset it will set it using this formatters configured <see cref="T:System.Text.Encoding" />.
        /// </summary>
        /// <param name="type">The type of the object being serialized. See <see cref="T:System.Net.Http.ObjectContent" />.</param>
        /// <param name="headers">The content headers that should be configured.</param>
        /// <param name="mediaType">The authoritative media type. Can be null.</param>
        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            if (headers == null)
            {
                throw new ArgumentNullException(nameof(headers));
            }

            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
        }
    }
}