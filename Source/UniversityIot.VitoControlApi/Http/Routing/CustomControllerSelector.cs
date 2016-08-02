namespace UniversityIot.VitoControlApi.Http.Routing
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Dispatcher;

    /// <summary>
    /// Controller sellector that handles no-controller in the matching route for NotFoundError controller
    /// </summary>
    public class CustomControllerSelector : DefaultHttpControllerSelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomControllerSelector"/> class.
        /// </summary>
        /// <param name="configuration">The configuration</param>
        public CustomControllerSelector(HttpConfiguration configuration)
            : base(configuration)
        {
        }

        /// <summary>
        /// Routes the request to the HandleNotFoundError method
        /// </summary>
        /// <param name="request">The request</param>
        /// <returns>
        /// Response with 404Error
        /// </returns>
        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            HttpControllerDescriptor decriptor = null;
            try
            {
                decriptor = base.SelectController(request);
            }
            catch (HttpResponseException ex)
            {
                var code = ex.Response.StatusCode;
                if (code != HttpStatusCode.NotFound)
                {
                    throw;
                }

                var routeValues = request.GetRouteData().Values;
                routeValues["controller"] = "NotFoundError";
                routeValues["action"] = "HandleNotFoundError";
                decriptor = base.SelectController(request);
            }

            return decriptor;
        }
    }
}