namespace UniversityIot.GatewaysService.Infrastructure.Installers
{
    using System;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using UniversityIot.GatewaysDataService;
    using UniversityIot.UsersService.Mapping;

    public class ServicesInstaller : IWindsorInstaller
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

            GatewayServiceMapper.Register();

            container.Register(
                Component.For<IGatewaysDataService>().ImplementedBy<GatewaysDataService>());
        }
    }
}