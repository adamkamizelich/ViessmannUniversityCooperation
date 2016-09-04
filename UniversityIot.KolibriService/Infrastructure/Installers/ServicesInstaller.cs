namespace UniversityIot.GatewaysService.Infrastructure.Installers
{
    using System;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Viessmann.Estrella.Components.KolibriApi;
    using Viessmann.Estrella.Components.KolibriApi.Configuration;
    using Viessmann.Estrella.Components.KolibriApi.Interfaces;
    using Viessmann.Estrella.Components.KolibriApi.MessageHandlers;
    using Viessmann.Estrella.Components.Logger;
    using Viessmann.Estrella.Components.Scheduling;

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

            var kolibriConfig = new KolibriConfig();
            var kolibriCredentials = new KolibriCredentials();

            container.Register(
                          Component.For<IKolibriConfig>().Instance(kolibriConfig),
                          Component.For<IKolibriCredentials>().Instance(kolibriCredentials),
                          Classes.FromAssemblyContaining<IKolibriClient>().BasedOn<IMessageHandler>().WithService.Base(),
                          Component.For<IPathsBuilderFactory>().ImplementedBy<PathsBuilderFactory>().LifestyleSingleton(),
                          Component.For<ILogger>().ImplementedBy<Logger>(),
                          Component.For<IIdentifierReaderFactory>().ImplementedBy<IdentifierReaderFactory>().LifestyleSingleton(),
                          Component.For<IDatapointPathFactory>().ImplementedBy<DatapointPathFactory>().LifestyleSingleton(),
                          Component.For<ISubscribersList>().ImplementedBy<SubscribersList>().LifestyleSingleton(),
                          Component.For<ISubscribersOnUserList>().ImplementedBy<SubscribersOnUserList>().LifestyleSingleton(),
                          Component.For<IWebSocketCommunicator>().ImplementedBy<WebSocketCommunicator>(),
                          Component.For<ISequencer>().ImplementedBy<Sequencer>().LifestyleSingleton(),
                          Component.For<IKolibriClient>().ImplementedBy<KolibriClient>().LifestyleSingleton(),

                          Component.For<IScheduler>().ImplementedBy<Scheduler>()
                              .Named("KolibriKeepAliveScheduler")
                              .DependsOn(Dependency.OnAppSettingsValue("interval", "KolibriConfig:KeepAliveInterval")),


                          Component.For<IKolibriCommunicator, IKolibriAcknowledge>()
                              .ImplementedBy<KolibriCommunicator>()
                              .DependsOn(Dependency.OnComponent(typeof(IScheduler), "KolibriKeepAliveScheduler")));

        }
    }
}