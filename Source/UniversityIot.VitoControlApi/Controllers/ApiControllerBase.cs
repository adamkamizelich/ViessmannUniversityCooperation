namespace UniversityIot.VitoControlApi.Controllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Web.Http;
    using Newtonsoft.Json;
    using UniversityIot.VitoControlApi.Enums;
    using UniversityIot.VitoControlApi.Models;

    /// <summary>
    /// Base controller
    /// </summary>
    public abstract class ApiControllerBase : ApiController
    { 
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