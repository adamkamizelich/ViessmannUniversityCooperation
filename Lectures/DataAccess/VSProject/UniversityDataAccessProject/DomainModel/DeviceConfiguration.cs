namespace DomainModel
{
    using System.Data.Entity;
    using System.Data.Entity.SqlServer;

    /// <summary>
    /// Device configuration for database.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbConfiguration" />
    public class DeviceConfiguration : DbConfiguration
    {
        private const string SqlClient = "System.Data.SqlClient";

        public DeviceConfiguration()
        {
            this.SetExecutionStrategy(SqlClient, () => new SqlAzureExecutionStrategy());
        }
    }
}
