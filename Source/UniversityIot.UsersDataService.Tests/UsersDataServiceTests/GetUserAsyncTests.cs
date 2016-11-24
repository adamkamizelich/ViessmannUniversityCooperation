namespace UniversityIot.UsersDataService.Tests.UsersDataServiceTests
{
    using System.Threading.Tasks;
    using NUnit.Framework;
    using UniversityIot.Enums;
    using UniversityIot.UsersDataAccess.Models;

    [TestFixture]
    public class GetUserAsyncTests : UserDataServiceTestsBase
    {
        [Test]
        public async Task WhenUserExists_ShouldGetItFromDb()
        {
            // arrange
            var user = CreateFakeUser();
            var service = this.GetService();
            await service.AddUserAsync(user);

            // act
            var response = await GetService().GetUserAsync(user.Id);

            // assert
            Assert.AreEqual(response.Id, user.Id);
            Assert.AreEqual(response.CustomerNumber, user.CustomerNumber);
        }

        [Test]
        public async Task WhenUserDontExists_ShouldReturnNull()
        {
            // arrange
            var user = CreateFakeUser();

            // act
            var response = await GetService().GetUserAsync(user.Id);

            // assert
            Assert.IsNull(response);
        }


        //[Test]
        //public async Task WhenUserHasGateways_ShouldGetThemFromDb()
        //{
        //    // arrange
        //    var user = CreateFakeUser();

        //    var userGateway = new UserGateway
        //    {
        //        AccessType = GatewayAccessType.Owner,
        //        GatewaySerial = "1234567"
        //    };
        //    user.UserGateways.Add(userGateway);
            
        //    var service = this.GetService();
        //    await service.AddUserAsync(user);

        //    // act
        //    var response = await GetService().GetUserAsync(user.Id);

        //    // assert
        //    Assert.AreEqual(1, response.UserGateways.Count);
        //}
    }
}