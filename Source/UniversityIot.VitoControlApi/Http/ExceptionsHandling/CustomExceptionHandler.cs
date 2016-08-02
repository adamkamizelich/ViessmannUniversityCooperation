namespace UniversityIot.VitoControlApi.Http.ExceptionsHandling
{
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Http.ExceptionHandling;
    using UniversityIot.VitoControlApi.Http.Results;

    /// <summary>
    /// Global exception handler
    /// </summary>
    public class CustomExceptionHandler : IExceptionHandler
    {
        /// <summary>
        /// Process an unhandled exception, either allowing it to propagate or handling it by providing a response message to return instead.
        /// </summary>
        /// <param name="context">The exception handler context.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>
        /// A task representing the asynchronous exception handling operation.
        /// </returns>
        public Task HandleAsync(ExceptionHandlerContext context, System.Threading.CancellationToken cancellationToken)
        {
            Handle(context);
            return Task.FromResult(0);
        }

        /// <summary>
        /// Handles the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        private static void Handle(ExceptionHandlerContext context)
        {
            ExceptionContext exceptionContext = context.ExceptionContext;            
            if (exceptionContext.CatchBlock == ExceptionCatchBlocks.IExceptionFilter)
            {
                // The exception filter stage propagates unhandled exceptions by default (when no filter handles the
                // exception).
                return;
            }

            RequestResultBase result = null;
            var exception = context.Exception as HttpException;
            if (exception == null)
            {
                result = new ErrorResult(context.Request, HttpStatusCode.InternalServerError);
            }
            else
            {
                result = new ErrorResult(context.Request, exception.StatusCode);
            }

            context.Result = result;
        }
    }
}