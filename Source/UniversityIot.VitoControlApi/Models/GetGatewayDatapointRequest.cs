namespace UniversityIot.VitoControlApi.Models
{

    /// <summary>
    /// Gateway's datapoints request model
    /// </summary>
    public class GetGatewayDatapointRequest
    {
        /// <summary>
        /// Gets or sets the gateway identifier.
        /// </summary>
        /// <value>
        /// The gateway identifier.
        /// </value>
        public int GatewayId { get; set; }

        /// <summary>
        /// Gets or sets the datapoint identifier.
        /// </summary>
        /// <value>
        /// The datapoint identifier.
        /// </value>
        public int DatapointId { get; set; }
    }
}