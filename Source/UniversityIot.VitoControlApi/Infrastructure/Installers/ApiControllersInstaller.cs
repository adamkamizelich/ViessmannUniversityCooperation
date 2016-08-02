namespace UniversityIot.VitoControlApi.Infrastructure.Installers
{
    using System;
    using System.Web.Http;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using UniversityIot.VitoControlApi.Controllers;

    /// <summary>
    /// Api Controllers Installer
    /// </summary>
    public class ApiControllersInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            container.Register(Classes.FromThisAssembly()
             .BasedOn<ApiControllerBase>()
             .LifestylePerWebRequest());

            container.Register(Classes.FromThisAssembly()
             .BasedOn<ApiController>()
             .LifestylePerWebRequest());
        }
    }
}