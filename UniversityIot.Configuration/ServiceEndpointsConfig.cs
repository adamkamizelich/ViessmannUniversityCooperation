namespace UniversityIot.Configuration
{
    using System.Configuration;

    /// <summary>
    /// Service endpoints configuration
    /// </summary>
    public sealed class ServiceEndpointsConfig : IServiceEndpointsConfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceEndpointsConfig"/> class.
        /// </summary>
        public ServiceEndpointsConfig()
        {
            this.LoadConfiguration();
        }

        /// <summary>
        /// Gets the users service endpoint.
        /// </summary>
        public string UsersServiceEndpoint { get; private set; }

        /// <summary>
        /// Gets the gateways service endpoint.
        /// </summary>
        public string GatewaysServiceEndpoint { get; private set; }

        /// <summary>
        /// Loads the configuration from common application settings.
        /// </summary>
        private void LoadConfiguration()
        {
            this.UsersServiceEndpoint = ConfigurationManager.AppSettings["ServiceEndpoints:Users"];
            this.GatewaysServiceEndpoint = ConfigurationManager.AppSettings["ServiceEndpoints:Gateways"];
        }
    }
}