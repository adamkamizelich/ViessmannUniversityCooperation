namespace DataAccessLayer.Common.ExternalServices
{
    using DataAccessLayer.Common.DomainModel;

    public interface IExternalService
    {
        bool IsGatewayProduced(string serial);

        bool IsControllerProduced(string serial);

        ControllerStatus GetControllerStatus(string serial);

        GatewayType GetGatewayType(string serial);
    }
}
