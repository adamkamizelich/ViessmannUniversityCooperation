namespace UniversityIot.GatewaysDataAccess
{
    using System.Data.Entity;
    using UniversityIot.GatewaysDataAccess.Models;

    public class GatewaysContext : DbContext
    {
        public IDbSet<Gateway> Gateways { get; set; }

        public IDbSet<Datapoint> GatewaySettings { get; set; }
    }
}
