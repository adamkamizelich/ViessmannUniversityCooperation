namespace UniversityIot.GatewaysDataService.Tests.GatewaysDataServiceTests
{
    using System.Linq;
    using System.Threading.Tasks;
    using NUnit.Framework;

    [TestFixture]
    public class GetSettingsTests : GatewaysDataServiceTestsBase
    {
        [Test]
        public async Task WhenGatewaySettingsNotExists_ShouldReturnEmptyList()
        {
            // arrange
            var service = this.GetService();

            // act
            var result = await service.GetDatapoints();

            // assert
            Assert.IsFalse(result.Any());
        }

        [Test]
        public async Task WhenGatewaySettingsExists_ShouldReturnNotEmptyList()
        {
            // arrange
            var service = this.GetService();

            await this.CreateGatewaySetting();

            // act
            var result = await service.GetDatapoints();

            // assert
            Assert.IsTrue(result.Any());
        }
    }
}
