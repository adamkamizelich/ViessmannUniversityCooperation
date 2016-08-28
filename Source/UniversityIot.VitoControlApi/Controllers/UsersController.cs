namespace UniversityIot.VitoControlApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;
    using UniversityIot.VitoControlApi.Enums;
    using UniversityIot.VitoControlApi.Handlers.Users;
    using UniversityIot.VitoControlApi.Http;
    using UniversityIot.VitoControlApi.Http.Attributes;
    using UniversityIot.VitoControlApi.Models;

    /// <summary>
    /// Users controller
    /// </summary>
    [RoutePrefix("users")]
    [BasicAuthentication]
    public class UsersController : ApiControllerBase
    {
        /// <summary>
        /// The get by identifier handler
        /// </summary>
        private readonly IGetByIdHandler getByIdHandler;

        /// <summary>
        /// The get gateways handler
        /// </summary>
        private readonly IGetGatewaysHandler getGatewaysHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController" /> class.
        /// </summary>
        /// <param name="getByIdHandler">The get by identifier handler.</param>
        /// <param name="getGatewaysHandler">The get gateways handler.</param>
        [CLSCompliant(false)]
        public UsersController(IGetByIdHandler getByIdHandler, IGetGatewaysHandler getGatewaysHandler)
        {
            this.getByIdHandler = getByIdHandler;
            this.getGatewaysHandler = getGatewaysHandler;
        }

        /// <summary>
        /// Gets the user
        /// </summary>
        /// <returns>
        /// User model
        /// </returns>
        [Route("me")]
        public async Task<IHttpActionResult> GetMe()
        {
            var idPrincipal = this.RequestContext.Principal as IdPrincipal;

            return await this.Get(idPrincipal.UserId);
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
            var idPrincipal = this.RequestContext.Principal as IdPrincipal;
            if (idPrincipal.UserId != id)
            {
                return this.CreateHttpActionResult(new GetUserResponse()
                {
                    ErrorModel = new ErrorModel(ErrorType.Unauthorized)
                });
            }

            var request = new GetUserRequest()
            {
                Id = id
            };

            var responseModel = await this.getByIdHandler.Handle(request);
            return this.CreateHttpActionResult(responseModel);
        }

        /// <summary>
        /// Gets the user gateways
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// User gateways model
        /// </returns>
        [Route("{id:int}/gateways")]
        public async Task<IHttpActionResult> GetGateways([FromUri]int id)
        {
            var idPrincipal = this.RequestContext.Principal as IdPrincipal;
            if (idPrincipal.UserId != id)
            {
                return this.CreateHttpActionResult(new GetUserResponse()
                {
                    ErrorModel = new ErrorModel(ErrorType.Unauthorized)
                });
            }

            var request = new GetUserGatewaysRequest()
            {
                Id = id
            };

            var responseModel = await this.getGatewaysHandler.Handle(request);
            return this.CreateHttpActionResult(responseModel);
        }
    }
}