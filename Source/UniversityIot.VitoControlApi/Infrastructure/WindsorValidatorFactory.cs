namespace UniversityIot.VitoControlApi.Infrastructure
{
    using System;
    using Castle.MicroKernel;
    using FluentValidation;

    /// <summary>
    /// Validator factory
    /// </summary>
    public class WindsorValidatorFactory : ValidatorFactoryBase
    {
        /// <summary>
        /// Container kernel
        /// </summary>
        private readonly IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindsorValidatorFactory"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public WindsorValidatorFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        /// <summary>
        /// Creates the instance.
        /// </summary>
        /// <param name="validatorType">Type of validator.</param>
        /// <returns>Validator, if available</returns>
        public override IValidator CreateInstance(Type validatorType)
        {
            if (this.kernel.HasComponent(validatorType))
            {
                var validtor = this.kernel.Resolve(validatorType) as IValidator;
                return validtor;
            }

            return null;
        }
    }
}