namespace UniversityIot.UsersDataService.Tests.UsersDataServiceTests
{
    using System.Threading.Tasks;
    using NUnit.Framework;
    using UniversityIot.UsersDataAccess;
    using UniversityIot.UsersDataAccess.Models;

    [TestFixture]
    public class GetUserByIdTests
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

        #region Test setup

        private static async Task<User> CreateFakeUser()
        {
            var user = new User
            {
                CustomerNumber = "Fake number",
                Name = "Fake name",
                Password = "Fake password"
            };

            using (var context = new UsersContext())
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }
            return user;
        }

        private static UsersDataService GetService()
        {
            var service = new UsersDataService();
            return service;
        }

        #endregion
    }
}
