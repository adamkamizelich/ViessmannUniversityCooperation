namespace UniversityIot.VitoControlApi.Enums
{
    using System.ComponentModel;

    /// <summary>
    /// General http error types
    /// </summary>
    public enum ErrorType
    {
        /// <summary>
        /// The internal server error
        /// </summary>
        [Description("INTERNAL_SERVER_ERROR")]
        InternalServerError,

        /// <summary>
        /// The validation error
        /// </summary>
        [Description("VALIDATION_ERROR")]
        ValidationError,

        /// <summary>
        /// The unsupported method
        /// </summary>
        [Description("UNSUPPORTED_METHOD")]
        UnsupportedMethod,

        /// <summary>
        /// The unauthorized
        /// </summary>
        [Description("UNAUTHORIZED")]
        Unauthorized,

        /// <summary>
        /// The not found error
        /// </summary>
        [Description("NOT_FOUND")]
        NotFound,

        /// <summary>
        /// The specified resource is unknown
        /// </summary>
        [Description("UNKNOWN_RESOURCE")]
        UnknownResource,

        /// <summary>
        /// The unsupported media type
        /// </summary>
        [Description("UNSUPPORTED_MEDIA_TYPE")]
        UnsupportedMediaType
    }
}