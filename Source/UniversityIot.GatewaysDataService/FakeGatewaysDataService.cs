namespace UniversityIot.GatewaysDataService
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniversityIot.GatewaysDataService.Models;

    public class FakeGatewaysDataService : IGatewaysDataService
    {
        private static readonly IEnumerable<Gateway> Gateways = new List<Gateway>()
        {
            new Gateway() {Id = 1, Description = "A", SerialNumber = "111"},
            new Gateway() {Id = 2, Description = "B", SerialNumber = "222"},
            new Gateway() {Id = 3, Description = "C", SerialNumber = "333"}
        };

        private static readonly IEnumerable<GatewaySetting> Settings = new List<GatewaySetting>()
        {
            new GatewaySetting() {Id = 1, Description = "Outside temperature", HexAdress = "111", DataType = 1},
            new GatewaySetting() {Id = 2, Description = "Inside temperature", HexAdress = "222",DataType = 1},
            new GatewaySetting() {Id = 3, Description = "Desired temperature", HexAdress = "333",DataType = 1}
        };

        public Task SaveGateway(Gateway gateway)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Gateway>> GetAllGateways()
        {
            return Task.FromResult(Gateways);
        }

        public Task<Gateway> GetGateway(int id)
        {
            var gateway = Gateways.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(gateway);
        }

        public Task<IEnumerable<GatewaySetting>> GetSettings()
        {
            return Task.FromResult(Settings);
        }
    }
}