namespace DataAccessLayer.BasicADO
{
    using System;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    using DataAccessLayer.Common.DomainModel;
    using DataAccessLayer.Common;
    using DataAccessLayer.Common.DTO;
    using DataAccessLayer.Common.ExternalServices;

    public class BasicAdoService : IService
    {
        // responsibility: storing internal details of database connection.
        private const string ConnectionString = "Data Source=FUE003W1602\\SQLSERVER;Initial Catalog=University; Integrated Security=true";

        private readonly ExternalServiceMock dummyWebService;

        public BasicAdoService()
        {
            this.dummyWebService = new ExternalServiceMock();
        }

        public async Task RegisterNewGatewayWithControllerAsync(GatewayData gatewayData, ControllerData controllerData)
        {
            // check preconditions
            if (string.IsNullOrEmpty(gatewayData.Serial))
            {
                throw new ArgumentNullException(nameof(gatewayData.Serial));
            }

            if (!this.dummyWebService.IsGatewayProduced(gatewayData.Serial))
            {
                throw new InvalidOperationException("Gateway does not exist");
            }

            if (!this.dummyWebService.IsControllerProduced(controllerData.Serial))
            {
                throw new InvalidOperationException("Controller does not exist");
            }

            var controllerStatus = this.dummyWebService.GetControllerStatus(controllerData.Serial);

            // responsibility: validation rules
            switch (controllerStatus)
            {
                case ControllerStatus.Maintenance:
                    // perhaps invoke some additional action
                    // e.g. send email to subscribed people.
                    break;
                case ControllerStatus.Invalid:
                    return;
            }
            
            var type = this.dummyWebService.GetGatewayType(gatewayData.Serial);

            // Activation Busines logic, responsibility: business logic
            if (type == GatewayType.Lancard)
            {
                // Some additional action  like sending notification to audit system.
            }

            if (gatewayData.IsActive)
            {
                if (controllerStatus != ControllerStatus.Operating)
                {
                    throw new InvalidOperationException("Cannot activate non operating gateway");
                }
            }

            // responsibility:  data persistence
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
                        command.Parameters.AddWithValue("@name", gatewayData.Name);
                        command.Parameters.AddWithValue("@isActive", gatewayData.IsActive);
                        command.Parameters.AddWithValue("@type", (int)type);
                        command.Parameters.AddWithValue("@serial", gatewayData.Serial);
                        command.Parameters.AddWithValue("@address", gatewayData.Address);

                        gatewayId = (int)await command.ExecuteScalarAsync();
                    }

                    int controllerTypeId;
                    using (
                        SqlCommand command =
                            new SqlCommand(
                                $"SELECT Id FROM ControllerType WHERE HardwareIndex = {controllerData.HardwareIndex} "
                                + $"AND {controllerData.SoftwareIndex} >= SoftwareIndexMin "
                                + $"AND {controllerData.SoftwareIndex} < SoftwareIndexMax"))

                    {
                        controllerTypeId = (int)await command.ExecuteScalarAsync();
                    }

                    using (SqlCommand command = new SqlCommand(@"INSERT INTO Controller(Serial, GatewayId, Status, ControllerTypeId) VALUES(
                        @serial, @gatewayId, @status, @controllerTypeId"))
                    {
                        command.Parameters.AddWithValue("@serial", controllerData.Serial);
                        command.Parameters.AddWithValue("@gatewayId", gatewayId);
                        command.Parameters.AddWithValue("@status", (int)controllerStatus);
                        command.Parameters.AddWithValue("@controllerTypeId", controllerTypeId);

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
