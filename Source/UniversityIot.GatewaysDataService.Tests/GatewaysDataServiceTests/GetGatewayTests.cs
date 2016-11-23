namespace UniversityIot.GatewaysDataService.Tests.GatewaysDataServiceTests
{
    using System.Threading.Tasks;
    using NUnit.Framework;

    [TestFixture]
    public class GetGatewayTests : GatewaysDataServiceTestsBase
    {
        [Test]
        public async Task WhenGatewayExists_ShouldReturnIt()
        {
            // arrange
            var service = this.GetService();

            var gateway = await this.CreateGateway();

            // act
            var result = await service.GetGateway(gateway.Id);

            // assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task WhenGatewayNotExists_ShouldReturnNull()
        {
            // arrange
            var service = this.GetService();

            var fakeId = 1;

            // act
            var result = await service.GetGateway(fakeId);

            // assert
            Assert.IsNull(result);
        }
    }
}
