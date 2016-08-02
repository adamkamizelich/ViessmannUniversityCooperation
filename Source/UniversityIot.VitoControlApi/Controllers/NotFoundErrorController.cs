namespace UniversityIot.VitoControlApi.Controllers
{
    using System.Net;
    using System.Web.Http;
    using UniversityIot.VitoControlApi.Http.Results;

    /// <summary>
    /// Not_Found Error Api controller
    /// </summary>
    public class NotFoundErrorController : ApiController
    {
        /// <summary>
        /// Responsible for sending HTTP 404 response message to the client.
        /// </summary>
        /// <returns>
        /// Response with appropriate status code.
        /// </returns>
        [HttpGet, HttpPost, HttpPut, HttpDelete, HttpHead, HttpOptions, AcceptVerbs("PATCH")]
        public IHttpActionResult HandleNotFoundError()
        {
            return new ErrorResult(this.Request, HttpStatusCode.NotFound);
        }
    }
}