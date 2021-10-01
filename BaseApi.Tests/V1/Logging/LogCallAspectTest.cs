using BaseApi.V1.Controllers;
using BaseApi.V1.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BaseApi.Tests.V1.Logging
{
    [TestFixture]
    public class LogCallAspectTest
    {
        private Mock<ILogger<LogCallAspect>> _logger;
        private LogCallAspect _sut;

        private readonly Type _type = typeof(BaseApiController);
        private readonly string _methodName = "SomeMethodName";

        [SetUp]
        public void SetUp()
        {
            _logger = new Mock<ILogger<LogCallAspect>>();
            _sut = new LogCallAspect(_logger.Object);
        }

        private static Attribute[] BuildTriggers(LogLevel? level = null)
        {
            LogCallAttribute attribute = new LogCallAttribute();
            if (level.HasValue)
                attribute = new LogCallAttribute(level.Value);

            return (new List<Attribute> { attribute }).ToArray();
        }

        [Test]
        public void LogCallAspectLogEnterTestNoAttributeLogsTrace()
        {
            _sut.LogEnter(_type, _methodName, new List<Attribute>().ToArray());

            _logger.VerifyExact(LogLevel.Trace,
                $"STARTING {_type.Name}.{_methodName} method", Times.Once());
        }

        [Test]
        public void LogCallAspectLogExitTestNoAttributeLogsTrace()
        {
            _sut.LogExit(_type, _methodName, new List<Attribute>().ToArray());

            _logger.VerifyExact(LogLevel.Trace,
                $"ENDING {_type.Name}.{_methodName} method", Times.Once());
        }
    }
}
