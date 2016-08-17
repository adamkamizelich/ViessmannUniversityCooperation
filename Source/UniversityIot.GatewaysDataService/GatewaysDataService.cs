namespace UniversityIot.GatewaysDataService
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Threading.Tasks;
    using UniversityIot.GatewaysDataAccess;
    using UniversityIot.GatewaysDataAccess.Models;

    public class GatewaysDataService : IGatewaysDataService
    {
        private readonly Func<GatewaysContext> contextLocator;

        public GatewaysDataService(Func<GatewaysContext> contextLocator)
        {
            this.contextLocator = contextLocator;
        }

        public async Task<Gateway> GetGateway(int id)
        {
            using (var context = this.contextLocator())
            {
                var gateway = await context.Gateways.FirstOrDefaultAsync(g => g.Id == id);
                return gateway;
            }
        }

        public async Task<IEnumerable<GatewaySetting>> GetSettings()
        {
            using (var context = this.contextLocator())
            {
                var gatewaySettings = await context.GatewaySettings.ToListAsync();
                return gatewaySettings;
            }
        }
    }
}
