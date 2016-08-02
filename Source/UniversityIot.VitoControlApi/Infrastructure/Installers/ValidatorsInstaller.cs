namespace UniversityIot.VitoControlApi.Infrastructure.Installers
{
    using System;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using FluentValidation;

    /// <summary>
    /// Validators installer
    /// </summary>
    public class ValidatorsInstaller : IWindsorInstaller
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

            container.Register(Component.For<IValidatorFactory>().Instance(new WindsorValidatorFactory(container.Kernel)));
            container.Register(Classes
                    .FromThisAssembly()
                    .BasedOn(typeof(IValidator<>))
                    .WithServiceBase());
        }
    }
}