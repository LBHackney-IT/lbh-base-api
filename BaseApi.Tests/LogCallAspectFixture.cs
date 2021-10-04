using Hackney.Core.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Tests
{
    public class LogCallAspectFixture
    {
        public Mock<ILogger<LogCallAspect>> MockLogger { get; private set; }

        [OneTimeSetUp]
        public void RunBeforeTests()
        {
            MockLogger = SetupLogCallAspect();
        }

        private static Mock<ILogger<LogCallAspect>> SetupLogCallAspect()
        {
            var mockLogger = new Mock<ILogger<LogCallAspect>>();
            var mockAspect = new Mock<LogCallAspect>(mockLogger.Object);
            var mockAppServices = new Mock<IServiceProvider>();
            var appBuilder = new Mock<IApplicationBuilder>();

            appBuilder.SetupGet(x => x.ApplicationServices).Returns(mockAppServices.Object);
            LogCallAspectServices.UseLogCall(appBuilder.Object);
            mockAppServices.Setup(x => x.GetService(typeof(LogCallAspect))).Returns(mockAspect.Object);
            return mockLogger;
        }
    }
}
