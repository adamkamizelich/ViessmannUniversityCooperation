namespace UniversityIot.VitoControlApi.Models
{
    /// <summary>
    /// Gateway datapont request model
    /// </summary>
    /// <seealso cref="UniversityIot.VitoControlApi.Models.IdAsyncRequestBase{UniversityIot.VitoControlApi.Models.PostGatewaySettingResponse}" />
    public class PostGatewayDatapointRequest
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the datapoint identifier.
        /// </summary>
        /// <value>
        /// The datapoint identifier.
        /// </value>
        public int DatapointId { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }
    }
}