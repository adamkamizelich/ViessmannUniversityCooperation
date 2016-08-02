namespace UniversityIot.VitoControlApi.Controllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Http;
    using MediatR;
    using Newtonsoft.Json;
    using UniversityIot.VitoControlApi.Enums;
    using UniversityIot.VitoControlApi.Models;

    /// <summary>
    /// Base controller
    /// </summary>
    public abstract class ApiControllerBase : ApiController
    {
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiControllerBase" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        [CLSCompliant(false)]
        protected ApiControllerBase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Handles the request.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request.</typeparam>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="request">The request.</param>
        /// <returns>
        /// Response task
        /// </returns>
        protected async Task<TResponse> HandleRequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest : AsyncRequestBase<TResponse>
        {
            return await this.mediator.SendAsync(request);
        }        

        /// <summary>
        /// Creates a bad request response with a specified response model
        /// </summary>
        /// <param name="errorModel">The error model.</param>
        /// <returns>
        /// Http bad request result
        /// </returns>
        protected IHttpActionResult BadRequest(ErrorModel errorModel)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
            httpResponseMessage.Content = new StringContent(JsonConvert.SerializeObject(errorModel), Encoding.UTF8, "application/json");
            IHttpActionResult result = this.ResponseMessage(httpResponseMessage);
            return result;
        }

        /// <summary>
        /// Creates the HTTP action result.
        /// </summary>
        /// <param name="responseModel">The response model.</param>
        /// <returns>Http action result</returns>
        protected IHttpActionResult CreateHttpActionResult(ResponseBase responseModel)
        {
            if (responseModel == null)
            {
                throw new ArgumentNullException(nameof(responseModel));
            }

            if (responseModel.HasError)
            {
                var errorModel = responseModel.ErrorModel;
                if (errorModel.ErrorType == ErrorType.Unauthorized)
                {
                    return this.Unauthorized();
                }

                return this.BadRequest(responseModel.ErrorModel);
            }

            return this.Ok(responseModel);
        }
    }
}