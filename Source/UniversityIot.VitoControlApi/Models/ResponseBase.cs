namespace UniversityIot.VitoControlApi.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Base class for responses
    /// </summary>
    public class ResponseBase
    {
        /// <summary>
        /// Gets a value indicating whether this instance has error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has error; otherwise, <c>false</c>.
        /// </value>
        [JsonIgnore]
        public bool HasError => this.ErrorModel != null;

        /// <summary>
        /// Gets or sets the error model.
        /// </summary>
        /// <value>
        /// The error model.
        /// </value>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ErrorModel ErrorModel { get; set; }
    }
}