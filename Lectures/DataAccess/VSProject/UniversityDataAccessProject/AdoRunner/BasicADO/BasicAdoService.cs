namespace AdoDataAccessLayer.BasicADO
{
    using System;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    using AdoDataAccessLayer.AdvancedADO.DomainModel;
    using AdoDataAccessLayer.BasicADO.DTO;
    using AdoDataAccessLayer.ExternalServices;

    public class BasicAdoService : IService
    {
        private const string ConnectionString = "Data Source=FUE003W1602\\SQLSERVER;Initial Catalog=University; Integrated Security=true";

        private readonly IExternalService dummyService;

        public BasicAdoService()
        {
            this.dummyService = new ExternalServiceMock();
        }

        public async Task RegisterNewGatewayWithControllerAsync(ControllerData controllerData, string gatewaySerial)
        {
            if (string.IsNullOrEmpty(gatewaySerial))
            {
                throw new ArgumentNullException(nameof(gatewaySerial));
            }

            if (!this.dummyService.IsGatewayProduced(gatewaySerial))
            {
                throw new InvalidOperationException("Gateway does not exist");
            }

            if (!this.dummyService.IsControllerProduced(controllerData.Serial))
            {
                throw new InvalidOperationException("Controller does not exist");
            }

            var controllerStatus = this.dummyService.GetControllerStatus(controllerData.Serial);

            switch (controllerStatus)
            {
                case ControllerStatus.Maintenance:
                    // perhaps invoke some additional action
                    // e.g. send email to subscribed people.
                    break;
                case ControllerStatus.Invalid:
                    return;
            }
            
            var type = this.dummyService.GetGatewayType(gatewaySerial);
            if (type == GatewayType.Lancard)
            {
                // Some additional action
            }

            var isActive = true;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                var transaction = connection.BeginTransaction();
                try
                {
                    int gatewayId;
                    using (SqlCommand command = new SqlCommand(@"INSERT INTO Gateway(Name, Address, Serial, Type, IsActive) 
                            VALUES(@name, @address, @serial, @type, @isActive);
                      SELECT CAST(scope_identity() AS int)"))
                    {
                        command.Parameters.AddWithValue("@name", "defaultName");
                        command.Parameters.AddWithValue("@isActive", isActive);
                        command.Parameters.AddWithValue("@type", (int)type);
                        command.Parameters.AddWithValue("@serial", gatewaySerial);
                        command.Parameters.AddWithValue("@address", null);

                        gatewayId = (int)await command.ExecuteScalarAsync();
                    }

                    using (SqlCommand command = new SqlCommand(@"SELECT * FROM ControllerType"))
                    {
                        command.Parameters.AddWithValue("@gatewayId", gatewayId);
                        command.Parameters.AddWithValue("@status", controllerStatus);

                        await command.ExecuteScalarAsync();
                    }

                    using (SqlCommand command = new SqlCommand(@"INSERT INTO Controller(...)"))
                    {
                        command.Parameters.AddWithValue("@gatewayId", gatewayId);
                        command.Parameters.AddWithValue("@status", controllerStatus);

                        await command.ExecuteScalarAsync();
                    }

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
