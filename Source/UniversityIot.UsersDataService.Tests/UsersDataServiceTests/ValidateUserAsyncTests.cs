namespace UniversityIot.UsersDataService.Tests.UsersDataServiceTests
{
    using System.Threading.Tasks;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class ValidateUserAsyncTests : UserDataServiceTestsBase
    {
        [Test]
        public async Task WhenUserIsNotInDb_ShouldReturnValidationFailed()
        {
            // arrange
            var service = GetService();

            var name = "Fake user name";

            // act
            var result = await service.ValidateUserAsync(name, null);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task WhenPasswordEncoderReturnsFalse_ShouldReturnValidationFailed()
        {
            // arrange
            var service = GetService();

            var user = await CreateFakeUser();

            this.passwordEncoderMock.Setup(x => x.Verify(It.IsAny<string>(), It.IsAny<string>())).Returns(false);

            // act
            var result = await service.ValidateUserAsync(user.Name, "abc");

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task WhenUsersPasswordIsCorrect_ShouldReturnValidationSuccesfull()
        {
            // arrange
            var service = GetService();

            var user = await CreateFakeUser();

            this.passwordEncoderMock.Setup(x => x.Verify(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            // act
            var result = await service.ValidateUserAsync(user.Name, "abc");

            // assert
            Assert.IsTrue(result);
        }
    }
}
