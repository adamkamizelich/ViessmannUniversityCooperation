namespace UniversityIot.GatewaysDataService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UniversityIot.GatewaysDataAccess.Models;

    public interface IGatewaysDataService
    {
        Task<Gateway> GetGateway(int id);

        Task<IEnumerable<Gateway>> GetGateways(IEnumerable<int> ids);

        Task<IEnumerable<Datapoint>> GetDatapoints();

        Task<Datapoint> GetDatapoint(int id);
    }
}
