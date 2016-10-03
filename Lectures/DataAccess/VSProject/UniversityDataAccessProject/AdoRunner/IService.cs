namespace AdoDataAccessLayer
{
    using System.Threading.Tasks;

    using AdoDataAccessLayer.BasicADO.DTO;

    using AdoDataAccessLayer.BasicADO;

    public interface IService
    {
        Task RegisterNewGatewayWithControllerAsync(GatewayData gatewayData, ControllerData controllerData);
    }
}
