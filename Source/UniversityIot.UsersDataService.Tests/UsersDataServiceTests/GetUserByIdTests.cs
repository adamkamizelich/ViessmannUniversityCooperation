namespace UniversityIot.UsersDataService.Tests.UsersDataServiceTests
{
    using System.Threading.Tasks;
    using NUnit.Framework;

    [TestFixture]
    public class GetUserByIdTests : UserDataServiceTestsBase
    {
        [Test]
        public async Task WhenUserIsInDb_ShouldGetItFromDb()
        {
            // arrange
            var service = GetService();

            var user = await CreateFakeUser();

            // act
            var result = await service.GetUserAsync(user.Id);

            // assert
            Assert.AreEqual(user.Name, result.Name);
        }

        [Test]
        public async Task WhenUserIsNotInDb_ShouldReturnNull()
        {
            // arrange
            var service = GetService();

            var fakeUserId = 10;

            // act
            var result = await service.GetUserAsync(fakeUserId);

            // assert
            Assert.IsNull(result);
        }
    }
}
