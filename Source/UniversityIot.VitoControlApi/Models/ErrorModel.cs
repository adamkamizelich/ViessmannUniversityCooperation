namespace UniversityIot.VitoControlApi.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using UniversityIot.Extensions;
    using UniversityIot.VitoControlApi.Enums;

    /// <summary>
    /// Error model
    /// </summary>
    public class ErrorModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorModel"/> class.
        /// </summary>
        /// <param name="errorType">Type of the error.</param>
        public ErrorModel(ErrorType errorType)
            : this(errorType, new Dictionary<string, string>(0))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorModel"/> class.
        /// </summary>
        /// <param name="errorType">Type of the error.</param>
        /// <param name="errorData">The error data.</param>
        public ErrorModel(ErrorType errorType, Dictionary<string, string> errorData)
        {
            this.ErrorType = errorType;            
            this.ErrorData = errorData;
        }

        /// <summary>
        /// Gets the type of the error.
        /// </summary>
        [JsonIgnore]
        public ErrorType ErrorType { get; private set; }

        /// <summary>
        /// Gets the error type
        /// </summary>
        public string Error => this.ErrorType.GetDescription();

        /// <summary>
        /// Gets the error data.
        /// </summary>
        public Dictionary<string, string> ErrorData { get; private set; }
    }
}