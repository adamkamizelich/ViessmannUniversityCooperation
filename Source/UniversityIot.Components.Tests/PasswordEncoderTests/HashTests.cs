namespace UniversityIot.Components.Tests.PasswordEncoderTests
{
    using NUnit.Framework;

    [TestFixture]
    public class HashTests
    {
        [Test]
        public void WhenPasswordIsNotEmpty_ShouldReturnCorrectHash()
        {
            // arrange
            var encoder = new PasswordEncoder();

            var input = "Some password";
            var expectedHash = "15cccc70f04946238246f31a22c94883";

            // act
            var result = encoder.Hash(input);

            // assert
            Assert.AreEqual(expectedHash, result);
        }
    }
}
