namespace UniversityIot.GatewaysDataService.Tests.GatewaysDataServiceTests
{
    using System.Threading.Tasks;
    using NUnit.Framework;
    using UniversityIot.Enums;
    using UniversityIot.GatewaysDataAccess;
    using UniversityIot.GatewaysDataAccess.Models;
    using UniversityIot.Tests.Common.DataAccessMocks;

    public class GatewaysDataServiceTestsBase
    {
        public virtual GatewaysContext CreateContext()
        {
            return new GatewaysContextMock();
        }

        public virtual GatewaysDataService GetService()
        {
            var service = new GatewaysDataService(() => this.CreateContext());
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

            using (var context = this.CreateContext())
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

            using (var context = this.CreateContext())
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
            using (var context = this.CreateContext())
            {
                context.Database.ExecuteSqlCommand("delete from Gateways");
                context.Database.ExecuteSqlCommand("delete from GatewaySettings");
            }
        }
    }
}
