namespace UniversityIot.VitoControlApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;
    using MediatR;
    using UniversityIot.VitoControlApi.Models;
    using UniversityIot.VitoControlApi.Models.DataObjects;

    [RoutePrefix("gateways")]
    public class GatewaysController : ApiControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GatewaysController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        [CLSCompliant(false)]
        public GatewaysController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Gets the user
        /// </summary>
        /// <param name="gateway">The gateway.</param>
        /// <returns>
        /// User model
        /// </returns>
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Get([FromUri]GetGatewayRequest gateway)
        {
            GetGatewayResponse responseModel = await this.HandleRequestAsync<GetGatewayRequest, GetGatewayResponse>(gateway);
            return this.CreateHttpActionResult(responseModel);
        }

        /// <summary>
        /// Gets the user
        /// </summary>
        /// <param name="gatewayDatapoints">The gateway datapoints.</param>
        /// <returns>
        /// User model
        /// </returns>
        [Route("{id:int}/datapoints")]
        public async Task<IHttpActionResult> GetDatapoints([FromUri]GetGatewayDatapointsRequest gatewayDatapoints)
        {
            GetGatewayDatapointsResponse responseModel = await this.HandleRequestAsync<GetGatewayDatapointsRequest, GetGatewayDatapointsResponse>(gatewayDatapoints);
            return this.CreateHttpActionResult(responseModel);
        }

        /// <summary>
        /// Gets the user
        /// </summary>
        /// <param name="gatewayDatapoint">The gateway setting.</param>
        /// <param name="body">The body.</param>
        /// <returns>
        /// User model
        /// </returns>
        [Route("{id:int}/datapoints/{datapointId}")]
        [HttpPost]
        public async Task<IHttpActionResult> PostDatapoint(PostGatewayDatapointRequest gatewayDatapoint, [FromBody] PostGatewayDatapointBody body)
        {
            gatewayDatapoint.Value = body.Value;
            PostGatewayDatapointResponse responseModel = await this.HandleRequestAsync<PostGatewayDatapointRequest, PostGatewayDatapointResponse>(gatewayDatapoint);
            return this.CreateHttpActionResult(responseModel);
        }
    }
}