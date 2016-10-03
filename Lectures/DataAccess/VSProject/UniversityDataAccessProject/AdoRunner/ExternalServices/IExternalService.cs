namespace AdoDataAccessLayer.ExternalServices
{
    using AdoDataAccessLayer.AdvancedADO.DomainModel;

    public interface IExternalService
    {
        ControllerStatus GetControllerStatus(string serial);

        bool IsGatewayProduced(string serial);

        bool IsControllerProduced(string serial);

        GatewayType GetGatewayType(string serial);
    }
}
