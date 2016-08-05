namespace UniversityIot.UsersDataService.Tests.UsersDataServiceTests
{
    using System.Threading.Tasks;
    using NUnit.Framework;
    using UniversityIot.UsersDataService.Models;

    [TestFixture]
    public class SaveUserTests
    {
        [Test]
        public async Task WhenUserIsCorrect_ShouldSaveItToDbSuccesfully()
        {
            // arrange
            var service = new UsersDataService();

            var user = new User
            {
                CustomerNumber = "Fake number",
                Name = "Fake name"
            };

            // act
            await service.SaveUser(user);
        }
    }
}
