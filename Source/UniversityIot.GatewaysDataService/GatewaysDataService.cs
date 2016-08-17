namespace UniversityIot.GatewaysDataService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UniversityIot.GatewaysDataAccess.Models;

    public class GatewaysDataService : IGatewaysDataService
    {
        public Task<Gateway> GetGateway(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<GatewaySetting>> GetSettings()
        {
            throw new System.NotImplementedException();
        }
    }
}
