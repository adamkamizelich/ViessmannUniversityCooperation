namespace UniversityIot.UsersService
{
    using System.Web.Http;
    using System.Web.Http.Dispatcher;
    using Castle.Windsor;
    using UniversityIot.UsersService.Infrastructure;

    /// <summary>
    /// WebApi configuration
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="container">The container.</param>
        public static void Register(HttpConfiguration config, IWindsorContainer container)
        {
            MapRoutes(config);            
            RegisterControllerActivator(container);
        }

        /// <summary>
        /// Maps the routes.
        /// </summary>
        /// <param name="config">The configuration.</param>
        private static void MapRoutes(HttpConfiguration config)
        {            
            config.MapHttpAttributeRoutes();
        }

        /// <summary>
        /// Registers the controller activator.
        /// </summary>
        /// <param name="container">The container.</param>
        private static void RegisterControllerActivator(IWindsorContainer container)
        {
            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new WindsorCompositionRoot(container));
        }
    }
}
