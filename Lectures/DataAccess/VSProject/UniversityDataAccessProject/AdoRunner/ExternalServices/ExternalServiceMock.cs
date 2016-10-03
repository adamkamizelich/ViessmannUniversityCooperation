namespace AdoDataAccessLayer.ExternalServices
{
    using System;

    using AdoDataAccessLayer.AdvancedADO.DomainModel;

    public class ExternalServiceMock : IExternalService
    {
        public ControllerStatus GetControllerStatus(string serial)
        {
            Random r = new Random();
            var status = r.Next(0, 3);
            return (ControllerStatus)status;
        }

        public bool IsGatewayProduced(string serial)
        {
            return true;
        }

        public GatewayType GetGatewayType(string serial)
        {
            Random r = new Random();
            var type = r.Next(0, 1);
            return (GatewayType)type;
        }
    }
}
