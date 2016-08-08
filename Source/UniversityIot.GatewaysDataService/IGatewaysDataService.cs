namespace UniversityIot.GatewaysDataService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UniversityIot.GatewaysDataService.Models;

    public interface IGatewaysDataService
    {
        Task SaveGateway(Gateway gateway);

        Task<IEnumerable<Gateway>> GetAllGateways();

        Task<Gateway> GetGateway(int id);

        Task<IEnumerable<GatewaySetting>> GetSettings();
    }
}
