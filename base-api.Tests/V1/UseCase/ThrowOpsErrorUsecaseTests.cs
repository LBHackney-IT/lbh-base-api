using NUnit.Framework;
using base_api.UseCase.V1;

namespace UnitTests.V1.UseCase
{
    [TestFixture]
    public class ThrowOpsErrorUsecaseTests
    {
        [Test]
        public void ThrowsTestOpsErrorException()
        {
            TestOpsErrorException ex = Assert.Throws<TestOpsErrorException>(
                delegate { ThrowOpsErrorUsecase.Execute(); });

            Assert.That(ex.Message, Is.EqualTo("This is a test exception to test our integrations"));
        }
    }
}
