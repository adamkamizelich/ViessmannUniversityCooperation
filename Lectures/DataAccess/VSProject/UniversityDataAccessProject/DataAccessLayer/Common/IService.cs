namespace DataAccessLayer.Common
{
    using System.Threading.Tasks;

    using DataAccessLayer.Common.DTO;

    public interface IService
    {
        Task RegisterNewGatewayWithControllerAsync(GatewayData gatewayData, ControllerData controllerData);
    }
}
