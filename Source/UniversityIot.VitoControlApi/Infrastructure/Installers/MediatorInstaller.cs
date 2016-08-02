namespace UniversityIot.VitoControlApi.Infrastructure.Installers
{
    using System.Collections.Generic;
    using System.Reflection;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using MediatR;

    /// <summary>
    /// Mediator installer
    /// </summary>
    public class MediatorInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            ////https://github.com/jbogard/MediatR/blob/master/src/MediatR.Examples.Windsor/Program.cs
            container.Kernel.AddHandlersFilter(new ContravariantFilter());
            container.Register(Component.For<SingleInstanceFactory>().UsingFactoryMethod<SingleInstanceFactory>(k => t => k.Resolve(t)));
            container.Register(Component.For<MultiInstanceFactory>().UsingFactoryMethod<MultiInstanceFactory>(k => t => (IEnumerable<object>)k.ResolveAll(t)));

            container.Register(Classes.FromAssemblyContaining<IMediator>().Pick().WithServiceAllInterfaces());

            container.Register(Classes.FromAssembly(Assembly.GetExecutingAssembly())
                .BasedOn(typeof(IRequestHandler<,>))
                .WithServiceAllInterfaces());

            container.Register(Classes.FromAssembly(Assembly.GetExecutingAssembly())
             .BasedOn(typeof(IAsyncRequestHandler<,>))
             .WithServiceAllInterfaces());
        }
    }
}