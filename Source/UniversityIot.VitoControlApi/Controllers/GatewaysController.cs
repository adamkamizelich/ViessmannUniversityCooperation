namespace UniversityIot.VitoControlApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;
    using UniversityIot.VitoControlApi.Handlers.Gateways;
    using UniversityIot.VitoControlApi.Http.Attributes;
    using UniversityIot.VitoControlApi.Models;
    using UniversityIot.VitoControlApi.Models.DataObjects;

    [RoutePrefix("gateways")]
    [BasicAuthentication]
    public class GatewaysController : ApiControllerBase
    {
        /// <summary>
        /// The get by identifier handler
        /// </summary>
        private readonly IGetByIdHandler getByIdHandler;

        /// <summary>
        /// The get datapoints handler
        /// </summary>
        private readonly IGetDatapointsHandler getDatapointsHandler;

        /// <summary>
        /// The get datapoint handler
        /// </summary>
        private readonly IGetDatapointHandler getDatapointHandler;

        /// <summary>
        /// The post datapoint handler
        /// </summary>
        private readonly IPostDatapointHandler postDatapointHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="GatewaysController" /> class.
        /// </summary>
        /// <param name="getByIdHandler">The get by identifier handler.</param>
        /// <param name="getDatapointsHandler">The get datapoints handler.</param>
        /// <param name="getDatapointHandler">The get datapoint handler.</param>
        /// <param name="postDatapointHandler">The post datapoint handler.</param>
        [CLSCompliant(false)]
        public GatewaysController(
            IGetByIdHandler getByIdHandler, 
            IGetDatapointsHandler getDatapointsHandler, 
            IPostDatapointHandler postDatapointHandler,
            IGetDatapointHandler getDatapointHandler)
        {
            this.getByIdHandler = getByIdHandler;
            this.getDatapointsHandler = getDatapointsHandler;
            this.getDatapointHandler = getDatapointHandler;
            this.postDatapointHandler = postDatapointHandler;
        }

        /// <summary>
        /// Gets the user
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// User model
        /// </returns>
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Get([FromUri]int id)
        {
            var request = new GetGatewayRequest()
            {
                Id = id
            };

            var responseModel = await this.getByIdHandler.Handle(request);
            return this.CreateHttpActionResult(responseModel);
        }

        /// <summary>
        /// Gets the user
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// User model
        /// </returns>
        [Route("{id:int}/datapoints")]
        public async Task<IHttpActionResult> GetDatapoints([FromUri]int id)
        {
            var request = new GetGatewayDatapointsRequest()
            {
                Id = id
            };

            var responseModel = await this.getDatapointsHandler.Handle(request);
            return this.CreateHttpActionResult(responseModel);
        }

        /// <summary>
        /// Gets the single datapoint
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="datapointId">The datapoint identifier.</param>
        /// <returns>
        /// Datapoint model
        /// </returns>
        [Route("{id:int}/datapoints/{datapointId:int}")]
        public async Task<IHttpActionResult> GetDatapoint([FromUri]int id, [FromUri] int datapointId)
        {
            var request = new GetGatewayDatapointRequest()
            {
                GatewayId = id,
                DatapointId = datapointId
            };

            var responseModel = await this.getDatapointHandler.Handle(request);
            return this.CreateHttpActionResult(responseModel);
        }

        /// <summary>
        /// Gets the user
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="datapointId">The datapoint identifier.</param>
        /// <param name="body">The body.</param>
        /// <returns>
        /// User model
        /// </returns>
        [Route("{id:int}/datapoints/{datapointId:int}")]
        [HttpPost]
        public async Task<IHttpActionResult> PostDatapoint([FromUri]int id, [FromUri] int datapointId, [FromBody] PostGatewayDatapointBody body)
        {
            var request = new PostGatewayDatapointRequest()
            {
                Id = id,
                DatapointId = datapointId,
                Value = body.Value
            };

            var responseModel = await this.postDatapointHandler.Handle(request);
            return this.CreateHttpActionResult(responseModel);
        }
    }
}