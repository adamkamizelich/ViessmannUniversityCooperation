namespace UniversityIot.VitoControlApi.Models
{
    using System.Collections.Generic;
    using UniversityIot.VitoControlApi.Enums;

    /// <summary>
    /// Different kind of error model. Collects error under one key for each property
    /// </summary>
    public sealed class ErrorCollectionModel : ErrorModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorCollectionModel" /> class.
        /// </summary>
        /// <param name="errorType">Type of the error.</param>
        public ErrorCollectionModel(ErrorType errorType)
            : this(errorType, new Dictionary<string, IEnumerable<string>>(0))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorCollectionModel" /> class.
        /// </summary>
        /// <param name="errorType">Type of the error.</param>
        /// <param name="errorData">The error data.</param>
        public ErrorCollectionModel(ErrorType errorType, Dictionary<string, IEnumerable<string>> errorData) 
            : base(errorType)
        {    
            this.ErrorData = errorData;
        }

        /// <summary>
        /// Gets the error data.
        /// </summary>
        public new Dictionary<string, IEnumerable<string>> ErrorData { get; private set; }
    }
}