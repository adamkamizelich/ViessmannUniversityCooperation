namespace UniversityIot.GatewaysDataService.Tests.GatewaysDataServiceTests
{
    using System.Threading.Tasks;
    using NUnit.Framework;
    using UniversityIot.Enums;
    using UniversityIot.GatewaysDataAccess;
    using UniversityIot.GatewaysDataAccess.Models;

    public class GatewaysDataServiceTestsBase
    {
        public virtual GatewaysDataService GetService()
        {
            var service = new GatewaysDataService();
            return service;
        }
        
        public async Task<Gateway> CreateGateway()
        {
            var gateway = new Gateway
            {
                Id = 1,
                Description = "Fake description",
                SerialNumber = "Fake serial number"
            };

            using (var context = new GatewaysContext())
            {
                context.Gateways.Add(gateway);
                await context.SaveChangesAsync();
            }

            return gateway;
        }

        public async Task<Datapoint> CreateGatewaySetting()
        {
            var gatewaySetting = new Datapoint
            {
                Id = 1,
                Description = "Fake description",
                IsReadonly = true,
                DataType = SettingDataType.Div10,
                HexAdress = "123"
            };

            using (var context = new GatewaysContext())
            {
                context.GatewaySettings.Add(gatewaySetting);
                await context.SaveChangesAsync();
            }

            return gatewaySetting;
        }

        [SetUp]
        public virtual void Setup()
        {
            this.Teardown();
        }

        [TearDown]
        public virtual void Teardown()
        {
            using (var context = new GatewaysContext())
            {
                context.Database.ExecuteSqlCommand("delete from Gateways");
                context.Database.ExecuteSqlCommand("delete from Datapoints");
            }
        }
    }
}
