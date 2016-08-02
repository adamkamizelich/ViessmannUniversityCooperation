namespace UniversityIot.VitoControlApi.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Dependencies;
    using Castle.MicroKernel.Lifestyle;
    using Castle.Windsor;

    /// <summary>
    /// Windsor dependency scope
    /// </summary>
    public class WindsorDependencyScope : IDependencyScope
    {
        /// <summary>
        /// The container
        /// </summary>
        private readonly IWindsorContainer container;

        /// <summary>
        /// The scope
        /// </summary>
        private readonly IDisposable scope;

        /// <summary>
        /// The is disposed indication
        /// </summary>
        private bool isDisposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindsorDependencyScope"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public WindsorDependencyScope(IWindsorContainer container)
        {
            this.container = container;            
            this.scope = this.container.BeginScope();
            this.isDisposed = false;
        }

        /// <summary>
        /// Retrieves a service from the scope.
        /// </summary>
        /// <param name="serviceType">The service to be retrieved.</param>
        /// <returns>
        /// The retrieved service.
        /// </returns>
        public object GetService(Type serviceType)
        {
            if (this.container.Kernel.HasComponent(serviceType))
            {
                return this.container.Resolve(serviceType);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves a collection of services from the scope.
        /// </summary>
        /// <param name="serviceType">The collection of services to be retrieved.</param>
        /// <returns>
        /// The retrieved collection of services.
        /// </returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.container.ResolveAll(serviceType).Cast<object>();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    this.scope.Dispose();
                }

                this.isDisposed = true;
            }
        }
    }
}