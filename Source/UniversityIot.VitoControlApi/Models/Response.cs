namespace UniversityIot.VitoControlApi.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Base response model
    /// </summary>
    /// <typeparam name="T">Inner object</typeparam>
    public class Response<T> : ResponseBase
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public T Data { get; set; }
    }
}