namespace UniversityIot.VitoControlApi
{
    using System.Globalization;
    using System.Linq;
    using System.Net.Http.Formatting;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using System.Web.Http.Dispatcher;
    using System.Web.Http.ExceptionHandling;
    using Castle.Core.Logging;
    using Castle.Windsor;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using UniversityIot.VitoControlApi.Http.ExceptionsHandling;
    using UniversityIot.VitoControlApi.Http.Formatters;
    using UniversityIot.VitoControlApi.Http.Routing;
    using UniversityIot.VitoControlApi.Infrastructure;

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
            EnableCors(config);
            MapRoutes(config);
            RegisterControllerActivator(container);
            RegisterExceptionHandling(config, container);
            RegisterFormatters(config);
            RegisterContractResolver(config);
            RegisterFiltersAndHandlers(config);
        }

        /// <summary>
        /// Enables the cors support
        /// </summary>
        /// <param name="config">The configuration.</param>
        private static void EnableCors(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*", "*");
            config.EnableCors(cors);
        }

        /// <summary>
        /// Maps the routes.
        /// </summary>
        /// <param name="config">The configuration.</param>
        private static void MapRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Error404",
                routeTemplate: "{*url}",
                defaults: new
                {
                    controller = "NotFoundError"
                });
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

        /// <summary>
        /// Registers the exception handling.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="container">The container.</param>
        private static void RegisterExceptionHandling(HttpConfiguration config, IWindsorContainer container)
        {
            var logger = container.Resolve<ILogger>();
            config.Services.Add(typeof(IExceptionLogger), new CustomExceptionLogger(logger));
            config.Services.Replace(typeof(IExceptionHandler), new CustomExceptionHandler());
        }

        /// <summary>
        /// Registers the contract resolver.
        /// </summary>
        /// <param name="config">The configuration.</param>
        private static void RegisterContractResolver(HttpConfiguration config)
        {
            config.Formatters.OfType<JsonMediaTypeFormatter>().First().SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                Culture = new CultureInfo("de-DE"),
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        /// <summary>
        /// Registers the filters.
        /// </summary>
        /// <param name="config">The configuration.</param>
        private static void RegisterFiltersAndHandlers(HttpConfiguration config)
        {
            config.MessageHandlers.Add(new MediaTypeMessageHandler());
        }

        /// <summary>
        /// Registers the formatters.
        /// </summary>
        /// <param name="config">The configuration.</param>
        private static void RegisterFormatters(HttpConfiguration config)
        {
            var estrellaFormatter = new CustomFormatter();
            config.Formatters.Clear();
            config.Formatters.Add(estrellaFormatter);
        }
    }
}
