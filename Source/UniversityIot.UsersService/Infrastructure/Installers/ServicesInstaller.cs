namespace UniversityIot.UsersService.Infrastructure.Installers
{
    using System;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using UniversityIot.Components;
    using UniversityIot.UsersDataAccess;
    using UniversityIot.UsersDataService;
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

            UserServiceMapper.Register();

            container.Register(
                Component.For<IPasswordEncoder>().ImplementedBy<PasswordEncoder>());
            
            const string UsersContextLocatorName = "UsersContextLocator";

            const string ContextLocatorFieldName = "contextLocator";

            container.Register(
                Component.For<Func<UsersContext>>().Instance(() => new UsersContext())
                .Named(UsersContextLocatorName));

            container.Register(
                Component.For<IUsersDataService>().ImplementedBy<UsersDataService>()
                .DependsOn(ServiceOverride.ForKey(ContextLocatorFieldName).Eq(UsersContextLocatorName)));
        }
    }
}