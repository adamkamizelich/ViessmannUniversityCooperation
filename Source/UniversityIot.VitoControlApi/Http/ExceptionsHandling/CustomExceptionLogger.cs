namespace UniversityIot.VitoControlApi.Http.ExceptionsHandling
{
    using System.Web.Http.ExceptionHandling;
    using Castle.Core.Logging;

    /// <summary>
    /// Global exception logger
    /// </summary>
    public class CustomExceptionLogger : ExceptionLogger
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomExceptionLogger"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public CustomExceptionLogger(ILogger logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// When overridden in a derived class, logs the exception synchronously.
        /// </summary>
        /// <param name="context">The exception logger context.</param>
        public override void Log(ExceptionLoggerContext context)
        {
            if (context == null || context.Exception is HttpException)
            {
                return;
            }

            this.logger.Error("Vitocontrol Api exception", context.Exception);
        }
    }
}