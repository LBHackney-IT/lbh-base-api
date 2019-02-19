using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using transactions_api.Controllers.V1;

namespace UnitTests.V1.Controllers
{

    [TestFixture]
    public class HealthCheckControllerTests
    {
        private HealthCheckController _classUnderTest;


        [SetUp]
        public void SetUp()
        {
            _classUnderTest = new HealthCheckController();
        }

        [Test]
        public void ReturnsResponseWithStatus()
        {
            var response = _classUnderTest.HealthCheck() as OkObjectResult;

            Assert.NotNull(response);
            Assert.AreEqual(response.StatusCode, 200);
            Assert.AreEqual(new Dictionary<string, object> {{"success", true}}, response.Value);

        }
    }
}
