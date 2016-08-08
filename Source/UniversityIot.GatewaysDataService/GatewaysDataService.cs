namespace UniversityIot.GatewaysDataService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UniversityIot.GatewaysDataAccess;
    using Entity = UniversityIot.GatewaysDataAccess.Models;
    using UniversityIot.GatewaysDataService.Models;

    public class GatewaysDataService : IGatewaysDataService
    {
        public async Task SaveGateway(Gateway gateway)
        {
            using (var context = new GatewaysContext())
            {
                var gatewayToSave = new Entity.Gateway
                {
                    Description = gateway.Description,
                    SerialNumber = gateway.SerialNumber
                };

                context.Gateways.Add(gatewayToSave);
                await context.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<Gateway>> GetAllGateways()
        {
            throw new System.NotImplementedException();
        }

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
