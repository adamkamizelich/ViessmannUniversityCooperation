namespace UniversityIot.GatewaysService
{
    using System.Web.Http;
    using Castle.MicroKernel.Resolvers.SpecializedResolvers;
    using Castle.Windsor;
    using Castle.Windsor.Installer;
    using UniversityIot.GatewaysService.Infrastructure;

    /// <summary>
    /// Application startup class
    /// </summary>
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// The container
        /// </summary>
        private static IWindsorContainer container;

        /// <summary>
        /// Configures the windsor.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        public static void ConfigureWindsor(HttpConfiguration configuration)
        {
            container = new WindsorContainer();
            container.Install(FromAssembly.This());
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
            var dependencyResolver = new WindsorDependencyResolver(container);
            configuration.DependencyResolver = dependencyResolver;
        }

        /// <summary>
        /// Application_s the start.
        /// </summary>
        protected void Application_Start()
        {            
            ConfigureWindsor(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configure(c => WebApiConfig.Register(c, container));
        }

        /// <summary>
        /// Application_s the end.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        protected void Application_End()
        {
            container.Dispose();
        }
    }
}