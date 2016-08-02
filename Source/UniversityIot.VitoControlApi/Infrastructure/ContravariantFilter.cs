namespace UniversityIot.VitoControlApi.Infrastructure
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Castle.MicroKernel;

    /// <summary>
    /// Contravariant filter
    /// </summary>
    public class ContravariantFilter : IHandlersFilter
    {
        /// <summary>
        /// Whatever the selector has an opinion about resolving a component with the
        /// specified service and key.
        /// </summary>
        /// <param name="service">The service interface that we want to resolve</param>
        /// <returns>Boolean value</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        public bool HasOpinionAbout(Type service)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            if (!service.IsGenericType)
            {
                return false;   
            }                

            var genericType = service.GetGenericTypeDefinition();
            var genericArguments = genericType.GetGenericArguments();
            return genericArguments.Count() == 1
                   && genericArguments.Single().GenericParameterAttributes.HasFlag(GenericParameterAttributes.Contravariant);
        }

        /// <summary>
        /// Select the appropriate handlers (if any) from the list of defined handlers,
        /// returning them in the order they should be executed.
        /// The returned handlers should members from the <paramref name="handlers" /> array.
        /// </summary>
        /// <param name="service">The service interface that we want to resolve</param>
        /// <param name="handlers">The defined handlers</param>
        /// <returns>
        /// The selected handlers, or an empty array, or null
        /// </returns>
        public IHandler[] SelectHandlers(Type service, IHandler[] handlers)
        {
            return handlers;
        }
    }
}