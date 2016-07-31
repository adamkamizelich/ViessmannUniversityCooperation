namespace UniversityIot.Configuration
{
    /// <summary>
    /// Service endpoints configuration
    /// </summary>
    public interface IServiceEndpointsConfig
    {
        /// <summary>
        /// Gets the users service endpoint.
        /// </summary>
        string UsersServiceEndpoint { get; }

        /// <summary>
        /// Gets the gateways service endpoint.
        /// </summary>
        string GatewaysServiceEndpoint { get; }
    }
}