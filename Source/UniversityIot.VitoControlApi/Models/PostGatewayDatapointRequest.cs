namespace UniversityIot.VitoControlApi.Models
{
    using System.Web.Http.ModelBinding;
    using UniversityIot.VitoControlApi.Http.Binders;

    /// <summary>
    /// Gateway datapont request model
    /// </summary>
    /// <seealso cref="UniversityIot.VitoControlApi.Models.IdAsyncRequestBase{UniversityIot.VitoControlApi.Models.PostGatewaySettingResponse}" />
    [ModelBinder(typeof(CustomModelBinder<PostGatewayDatapointRequest, PostGatewayDatapointResponse>))]
    public class PostGatewayDatapointRequest : IdAsyncRequestBase<PostGatewayDatapointResponse>
    {
        /// <summary>
        /// Gets or sets the datapoint identifier.
        /// </summary>
        /// <value>
        /// The datapoint identifier.
        /// </value>
        public string DatapointId { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }
    }
}