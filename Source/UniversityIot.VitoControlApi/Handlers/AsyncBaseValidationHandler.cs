namespace UniversityIot.VitoControlApi.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FluentValidation;
    using FluentValidation.Results;
    using UniversityIot.Extensions;
    using UniversityIot.VitoControlApi.Enums;
    using UniversityIot.VitoControlApi.Models;

    /// <summary>
    /// Base handler with validation
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <typeparam name="TInner">The type of the inner object in response.</typeparam>
    public abstract class AsyncBaseValidationHandler<TRequest, TResponse, TInner> : AsyncBaseHandler<TRequest, TResponse>
        where TRequest : AsyncRequestBase<TResponse>
        where TResponse : Response<TInner>, new()
    {
        /// <summary>
        /// The validator factory
        /// </summary>
        private readonly IValidatorFactory validatorFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncBaseValidationHandler{TRequest, TResponse, TInner}"/> class.
        /// </summary>
        /// <param name="validatorFactory">The validator factory.</param>
        protected AsyncBaseValidationHandler(IValidatorFactory validatorFactory)
        {
            this.validatorFactory = validatorFactory;
        }

        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>
        /// Response model
        /// </returns>
        public override async Task<TResponse> Handle(TRequest message)
        {
            var validator = this.validatorFactory.GetValidator<TRequest>();

            if (validator == null)
            {
                throw new InvalidOperationException("Validator required");
            }

            var validationResult = await validator.ValidateAsync(message);
            if (validationResult.IsValid)
            {
                return await this.InternalHandle(message);
            }

            ErrorModel errorModel = null;

            if (validationResult.Errors.Any(x => x.ErrorMessage.Equals(ErrorType.Unauthorized.GetDescription())))
            {
                errorModel = new ErrorModel(ErrorType.Unauthorized);
            }
            else
            {
                errorModel = CreateErrorModel(validationResult.Errors);
            }

            var response = new TResponse()
            {
                ErrorModel = errorModel
            };

            return response;
        }

        /// <summary>
        /// Formats the name of the property.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Formatted property without nested model path</returns>
        private static string FormatPropertyName(string name)
        {
            if (IsCollectionProperty(name))
            {
                int idx = name.IndexOf(".", StringComparison.OrdinalIgnoreCase);
                idx = idx > 0 ? idx + 1 : 0;
                return name.Substring(idx);
            }
            else
            {
                int idx = name.LastIndexOf(".", StringComparison.OrdinalIgnoreCase);
                idx = idx > 0 ? idx + 1 : 0;
                return name.Substring(idx);
            }
        }

        /// <summary>
        /// Determines whether property is in collection.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>true or false</returns>
        private static bool IsCollectionProperty(string name)
        {
            return name.Contains("[") && name.Contains("]");
        }

        /// <summary>
        /// Creates the error model.
        /// </summary>
        /// <param name="results">The results.</param>
        /// <returns>Error Model</returns>
        private static ErrorModel CreateErrorModel(IList<ValidationFailure> results)
        {
            if (results.GroupBy(x => x.PropertyName).Any(g => g.Count() > 1))
            {
                return new ErrorCollectionModel(
                    ErrorType.ValidationError,
                    results
                    .GroupBy(x => x.PropertyName)
                    .ToDictionary(
                        err => FormatPropertyName(err.Key),
                        failures => failures.Select(failure => failure.ErrorMessage)));
            }

            return new ErrorModel(
                ErrorType.ValidationError,
                results.ToDictionary(
                    err => FormatPropertyName(err.PropertyName), 
                    err => err.ErrorMessage));
        }
    }
}