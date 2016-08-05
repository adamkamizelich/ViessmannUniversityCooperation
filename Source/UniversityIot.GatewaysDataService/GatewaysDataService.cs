namespace UniversityIot.GatewaysDataService
{
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
    }
}
