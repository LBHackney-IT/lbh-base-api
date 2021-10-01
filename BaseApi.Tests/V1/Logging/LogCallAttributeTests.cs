using BaseApi.V1.Logging;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Tests.V1.Logging
{
    [TestFixture]
    public class LogCallAttributeTests
    {
        [Test]
        public void DefaultConstructorTestSetsLogLevelTrace()
        {
            var sut = new LogCallAttribute();
            sut.Level.Should().Be(LogLevel.Trace);
        }

    }
}
