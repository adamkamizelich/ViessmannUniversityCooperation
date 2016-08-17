namespace UniversityIot.UsersDataService.Tests.UsersDataServiceTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using UniversityIot.UsersDataAccess.Models;

    [TestFixture]
    public class GetUsersInstallationsAsyncTests : UserDataServiceTestsBase
    {
        [Test]
        public async Task WhenUserHasNoInstallations_ShouldReturnEmptyList()
        {
            // arrange
            var service = GetService();

            var user = await CreateFakeUser();

            // act
            var result = await service.GetUsersInstallationsAsync(user.Id);

            // assert
            Assert.IsFalse(result.Any());
        }

        [Test]
        public async Task WhenUserHasInstallations_ShouldReturnCorrectList()
        {
            // arrange
            var service = GetService();

            var user = await CreateFakeUser();

            var userInstallation = await CreateFakeInstallation(user.Id);

            // act
            var result = await service.GetUsersInstallationsAsync(user.Id);

            // assert
            Assert.AreEqual(userInstallation.InstallationId, result.Single());
        }


        #region Test setup

        private async Task<UserInstallation> CreateFakeInstallation(int userId)
        {
            var userInstallation = new UserInstallation
            {
               InstallationId = 1
            };

            using (var context = this.CreateContext())
            {
                var user = context.Users.Find(userId);

                user.InstallationIds = new List<UserInstallation> {  userInstallation };
                
                await context.SaveChangesAsync();
            }
            return userInstallation;
        } 

        #endregion
    }
}
