namespace UniversityIot.VitoControlApi.Http.Routing
{    
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using UniversityIot.VitoControlApi.Http.ExceptionsHandling;

    /// <summary>
    /// Passes the request to the HandleNotFoundError method if no matching action method found in CustomHttpControllerSelector
    /// </summary>
    public class CustomActionSelector : ApiControllerActionSelector
    {
        /// <summary>
        /// Routes the request to the HandleNotFoundError method
        /// </summary>
        /// <param name="controllerContext">The controllerContext</param>
        /// <returns>Response with 404Error</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]

        public override HttpActionDescriptor SelectAction(HttpControllerContext controllerContext)
        {
            try
            {
                return base.SelectAction(controllerContext);
            }
            catch (HttpResponseException ex)
            {
                throw new HttpException(ex.Response.StatusCode);
            }
        }
    }
}