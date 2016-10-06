namespace DomainModel.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Configuration for migration
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<DeviceContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DeviceContext context)
        {
        }
    }
}
