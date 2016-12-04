namespace UniversityIot.UsersService.Infrastructure
{
    using System;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Dispatcher;
    using Castle.Windsor;

    /// <summary>
    /// Root class of Windsor Container
    /// </summary>
    public class WindsorCompositionRoot : IHttpControllerActivator
    {
        /// <summary>
        /// The windsor container
        /// </summary>
        private readonly IWindsorContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindsorCompositionRoot"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public WindsorCompositionRoot(IWindsorContainer container)
        {
            this.container = container;
        }

        /// <summary>
        /// Creates an <see cref="T:System.Web.Http.Controllers.IHttpController" /> object.
        /// </summary>
        /// <param name="request">The message request.</param>
        /// <param name="controllerDescriptor">The HTTP controller descriptor.</param>
        /// <param name="controllerType">The type of the controller.</param>
        /// <returns>
        /// An <see cref="T:System.Web.Http.Controllers.IHttpController" /> object.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            var controller = (IHttpController)this.container.Resolve(controllerType);
            request.RegisterForDispose(new Release(() => this.container.Release(controller)));
            return controller;
        }

        /// <summary>
        /// Release class
        /// </summary>
        private sealed class Release : IDisposable
        {
            /// <summary>
            /// The release
            /// </summary>
            private readonly Action release;

            /// <summary>
            /// Initializes a new instance of the <see cref="Release"/> class.
            /// </summary>
            /// <param name="release">The release.</param>
            public Release(Action release)
            {
                this.release = release;
            }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                this.release();
            }
        }
    }
}