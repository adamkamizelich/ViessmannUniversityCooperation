namespace DomainModel
{
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    using DomainModel.Entities;

    /// <summary>
    /// Device context.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class DeviceContext : DbContext
    {
        public DeviceContext() : base("name=DeviceConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DeviceContext, DbMigrationsConfiguration<DeviceContext>>());
            Database.SetInitializer<DeviceContext>(null);
        }

        /// <summary>
        /// Gets or sets the controllers.
        /// </summary>
        public DbSet<Controller> Controllers { get; set; }

        /// <summary>
        /// Gets or sets the datapoints.
        /// </summary>
        public DbSet<Datapoint> Datapoints { get; set; }

        /// <summary>
        /// Gets or sets the gateways.
        /// </summary>
        public DbSet<Gateway> Gateways { get; set; }

        /// <summary>
        /// Gets or sets the controller types.
        /// </summary>
        public DbSet<ControllerType> ControllerTypes { get; set; }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ControllerType>().HasMany<Datapoint>(d => d.Datapoints).WithMany().Map(
                cs =>
                    {
                        cs.MapLeftKey("ControllerTypeId");
                        cs.MapRightKey("DatapointId");
                        cs.ToTable("ControllerTypeToDatapoint");
                    });
        }

    }
}
