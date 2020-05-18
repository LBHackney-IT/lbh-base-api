using System.Collections.Generic;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using BaseApi.Controllers.V1;
using BaseApi.UseCase.V1;

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
            var expected = new Dictionary<string, object> { { "success", true } };
            var response = _classUnderTest.HealthCheck() as OkObjectResult;

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(200);
            response.Value.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ThrowErrorThrows()
        {
            Assert.Throws<TestOpsErrorException>(_classUnderTest.ThrowError);
        }
    }
}
