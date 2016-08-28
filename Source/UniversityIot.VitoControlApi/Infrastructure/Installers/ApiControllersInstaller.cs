namespace UniversityIot.VitoControlApi.Infrastructure.Installers
{
    using System;
    using System.Web.Http;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using UniversityIot.UsersService.Mapping;
    using UniversityIot.VitoControlApi.Controllers;
    using UniversityIot.VitoControlApi.Handlers.Gateways;
    using UniversityIot.VitoControlApi.Handlers.Users;
    using GetByIdHandler = UniversityIot.VitoControlApi.Handlers.Users.GetByIdHandler;
    using IGetByIdHandler = UniversityIot.VitoControlApi.Handlers.Users.IGetByIdHandler;

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

            ExternalServiceMapper.Register();

            container.Register(Classes.FromThisAssembly()
             .BasedOn<ApiControllerBase>()
             .LifestylePerWebRequest());

            container.Register(Classes.FromThisAssembly()
             .BasedOn<ApiController>()
             .LifestylePerWebRequest());

            container.Register(
                Component.For<IGetByIdHandler>().ImplementedBy<GetByIdHandler>(), 
                Component.For<IGetGatewaysHandler>().ImplementedBy<GetGatewaysHandler>(), 
                Component.For<IPostDatapointHandler>().ImplementedBy<PostDatapointHandler>(), 
                Component.For<IGetDatapointsHandler>().ImplementedBy<GetDatapointsHandler>(), 
                Component.For<Handlers.Gateways.IGetByIdHandler>().ImplementedBy<Handlers.Gateways.GetByIdHandler>()
                );
        }
    }
}