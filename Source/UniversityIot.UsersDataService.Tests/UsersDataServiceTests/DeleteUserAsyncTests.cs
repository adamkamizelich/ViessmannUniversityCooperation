namespace UniversityIot.UsersDataService.Tests.UsersDataServiceTests
{
    using System.Threading.Tasks;
    using NUnit.Framework;
    using UniversityIot.Enums;
    using UniversityIot.UsersDataAccess.Models;

    [TestFixture]
    public class DeleteUserAsyncTests : UserDataServiceTestsBase
    {
        [Test]
        public async Task WhenUserExists_ShouldBeDeletedFromDb()
        {
            // arrange
            var user = CreateFakeUser();
            var service = this.GetService();
            await service.AddUserAsync(user);

            // act
            await GetService().DeleteUserAsync(user.Id);

            // assert
            var userFromDb = await service.GetUserAsync(user.Id);
            Assert.IsNull(userFromDb);
        }

        [Test]
        public async Task WhenUserDontExists_ShouldNotThrowException()
        {
            // arrange
            var user = CreateFakeUser();

            // act & assert
            Assert.DoesNotThrowAsync(() => GetService().DeleteUserAsync(user.Id));
        }   
    }
}