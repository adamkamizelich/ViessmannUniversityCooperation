namespace UniversityIot.VitoControlApi.Enums
{
    using System.ComponentModel;

    /// <summary>
    /// Validation error types
    /// </summary>
    public enum ValidationErrorType
    {
        /// <summary>
        /// The empty error
        /// </summary>
        [Description("EMPTY")]
        Empty,

        /// <summary>
        /// The invalid error
        /// </summary>
        [Description("INVALID")]
        Invalid,

        /// <summary>
        /// The invalid collection element
        /// </summary>
        [Description("INVALID_COLLECTION_ELEMENT")]
        InvalidCollectionElement,

        /// <summary>
        /// The invalid collection element
        /// </summary>
        [Description("REGEX_MATCH_REQUIRED_{0}")]
        NotMatched,

        /// <summary>
        /// The string value is to long
        /// </summary>
        [Description("STRING_TOO_LONG")]
        StringTooLong,

        /// <summary>
        /// The value is out of range
        /// </summary>
        [Description("OUT_OF_RANGE")]
        OutOfRange
    }
}