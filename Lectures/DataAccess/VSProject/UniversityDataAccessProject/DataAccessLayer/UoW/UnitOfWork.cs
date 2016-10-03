namespace DataAccessLayer.UoW
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;

    using DataAccessLayer.Common.DomainModel;
    using DataAccessLayer.UoW.CommanBuilder;
    using DataAccessLayer.UoW.DAL;

    public class UnitOfWork : IUnitOfWork
    {
        private const string ConnectionString = "Data Source=FUE003W1602\\SQLSERVER;Initial Catalog=University; Integrated Security=true";

        private readonly SqlConnection sqlConnection;

        private readonly IDataAccessAdapter dataAccessAdapter;

        private readonly ICommandBuilder commandBuilder;

        private bool disposed = false;

        public UnitOfWork() : this(new CommandBuilder(), new DataAccessAdapter())
        {
        }

        public UnitOfWork(ICommandBuilder commandBuilder, IDataAccessAdapter dataAccessAdapter)
        {
            this.dataAccessAdapter = new DataAccessAdapter();
            this.commandBuilder = new CommandBuilder();

            this.Gateways = new Tracker<Gateway>();
            this.Controllers = new Tracker<Controller>();
            this.ControllerTypes = new Tracker<ControllerType>();
            this.Datapoints = new Tracker<Datapoint>();
            this.Factory = new RepositoryFactory(this);
            
            this.sqlConnection = new SqlConnection(ConnectionString);
        }

        public RepositoryFactory Factory { get; set; }

        internal Tracker<Gateway> Gateways { get; set; }

        internal Tracker<Controller> Controllers { get; set; }

        internal Tracker<ControllerType> ControllerTypes { get; set; }

        internal Tracker<Datapoint> Datapoints { get; set; }

        public async Task SaveAsync()
        {
            // 1. add gateways.
            foreach (var gateway in this.Gateways.Added)
            {
                var gatewayId = (int)await this.dataAccessAdapter.ExecuteScalarAsync(this.commandBuilder.BuildAdd(gateway));
                gateway.Id = gatewayId;
            }

            foreach (var controller in this.Controllers.Added)
            {
                var controllerId = (int)await this.dataAccessAdapter.ExecuteScalarAsync(this.commandBuilder.BuildAdd(controller));
                controller.Id = controllerId;
            }

            foreach (var datapoint in this.Datapoints.Added)
            {
                var datapointId = (int)await this.dataAccessAdapter.ExecuteScalarAsync(this.commandBuilder.BuildAdd(datapoint));
                datapoint.Id = datapointId;
            }

            foreach (var controllerType in this.ControllerTypes.Added)
            {
                var controllerTypeId = (int)await this.dataAccessAdapter.ExecuteScalarAsync(this.commandBuilder.BuildAdd(controllerType));
                controllerType.Id = controllerTypeId;

                // 2. Fix-Up references.
                foreach (var datapointReference in controllerType.Datapoints)
                {
                    await this.dataAccessAdapter.ExecuteNonQueryAsync(this.commandBuilder.BuildManyToManyConnection(controllerType, datapointReference));
                }
            }

            // Updates
            foreach (var gateway in this.Gateways.Updated)
            {
                await this.dataAccessAdapter.ExecuteNonQueryAsync(this.commandBuilder.BuildUpdate(gateway));
            }

            foreach (var controller in this.Controllers.Updated)
            {
                await this.dataAccessAdapter.ExecuteNonQueryAsync(this.commandBuilder.BuildUpdate(controller));
            }

            foreach (var controllerType in this.ControllerTypes.Updated)
            {
                await this.dataAccessAdapter.ExecuteNonQueryAsync(this.commandBuilder.BuildUpdate(controllerType));
            }

            // need to handle updating reference types.

            // Deletes
            foreach (var controllerType in this.ControllerTypes.Deleted)
            {
                await this.dataAccessAdapter.ExecuteNonQueryAsync(this.commandBuilder.BuildDelete<ControllerType>(controllerType.Id));
            }

            foreach (var controller in this.Controllers.Deleted)
            {
                await this.dataAccessAdapter.ExecuteNonQueryAsync(this.commandBuilder.BuildDelete<Controller>(controller.Id));
            }

            foreach (var gateway in this.Gateways.Deleted)
            {
                await this.dataAccessAdapter.ExecuteNonQueryAsync(this.commandBuilder.BuildDelete<Gateway>(gateway.Id));
            }

            // need to handle referential integrity (CASCADE delete)
        }


        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (this.sqlConnection != null)
                    {
                        if (this.sqlConnection.State == ConnectionState.Open)
                        {
                            this.sqlConnection.Close();
                        }

                        this.sqlConnection.Dispose();
                    }
                }
            }

            this.disposed = true;
        }
    }
}
