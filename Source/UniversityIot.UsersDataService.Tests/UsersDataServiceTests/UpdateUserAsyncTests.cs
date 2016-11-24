namespace UniversityIot.UsersDataService.Tests.UsersDataServiceTests
{
    using System.Threading.Tasks;
    using NUnit.Framework;

    [TestFixture]
    public class UpdateUserAsyncTests : UserDataServiceTestsBase
    {
        [Test]
        public async Task WhenUserExists_ShouldUpdateHim()
        {
            // arrange
            var user = CreateFakeUser();
            var service = GetService();
            await service.AddUserAsync(user);

            var differentName = "Different name";
            user.Name = differentName;

            // act
            await GetService().UpdateUserAsync(user);

            // assert
            var userFromDb = await service.GetUserAsync(user.Id);
            Assert.AreEqual(differentName, userFromDb.Name);
        }
    }
}