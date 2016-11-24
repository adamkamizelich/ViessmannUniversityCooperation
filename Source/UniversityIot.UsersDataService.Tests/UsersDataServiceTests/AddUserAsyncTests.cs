namespace UniversityIot.UsersDataService.Tests.UsersDataServiceTests
{
    using System.Threading.Tasks;
    using NUnit.Framework;

    [TestFixture]
    public class AddUserAsyncTests : UserDataServiceTestsBase
    {
        [Test]
        public async Task WhenAddingUser_ShouldBeStoredInDb()
        {
            // arrange
            var user = CreateFakeUser();

            // act
            var response = await GetService().AddUserAsync(user);

            // assert
            Assert.IsTrue(response.Id != 0);
        }
    }
}