namespace UniversityIot.GatewaysService.Http.Attributes
{
    using System.Globalization;
    using System.Net.Http.Headers;

    public class BasicAuthenticationHeaderValue : AuthenticationHeaderValue
    {
        /// <summary>
        /// The schema
        /// </summary>
        public const string Schema = "Basic";

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicAuthenticationHeaderValue"/> class.
        /// </summary>
        /// <param name="realm">The realm.</param>
        public BasicAuthenticationHeaderValue(string realm)
            : base(Schema, string.Format(CultureInfo.InvariantCulture, "realm=\"{0}\"", realm))
        {
        }
    }
}