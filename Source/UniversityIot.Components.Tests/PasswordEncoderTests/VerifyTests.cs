namespace UniversityIot.Components.Tests.PasswordEncoderTests
{
    using NUnit.Framework;

    [TestFixture]
    public class VerifyTests
    {
        [Test]
        public void WhenPasswordIsCorrect_ShouldReturnTrue()
        {
            // arrange
            var encoder = new PasswordEncoder();

            var input = "Some password";
            var hashOfInput = "15cccc70f04946238246f31a22c94883";

            // act
            var result = encoder.Verify(input, hashOfInput);

            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void WhenPasswordIsIncorrect_ShouldReturnFalse()
        {
            // arrange
            var encoder = new PasswordEncoder();

            var input = "Some password";
            var someIncorrectHash = "15ccdc70f04946238246f31a22c94883";

            // act
            var result = encoder.Verify(input, someIncorrectHash);

            // assert
            Assert.IsFalse(result);
        }
    }
}
