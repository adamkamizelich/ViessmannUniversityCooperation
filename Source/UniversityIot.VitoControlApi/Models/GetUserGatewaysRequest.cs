namespace UniversityIot.VitoControlApi.Models
{
    using System.Web.Http.ModelBinding;

    /// <summary>
    /// User gateways request model
    /// </summary>
    public class GetUserGatewaysRequest
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
    }
}