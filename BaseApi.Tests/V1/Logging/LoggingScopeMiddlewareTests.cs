using BaseApi.V1.Controllers;
using BaseApi.V1.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Tests.V1.Logging
{
    [TestFixture]
    public class LoggingScopeMiddlewareTests
    {
        private readonly string _correlationId = Guid.NewGuid().ToString();
        private readonly string _userId = Guid.NewGuid().ToString();
        private HttpContext _httpContext;
        private Mock<ILogger<LoggingScopeMiddleware>> _mockLogger;

        [SetUp]
        public void SetUp()
        {
            _httpContext = new DefaultHttpContext();
            _httpContext.Request.Headers.Add(Constants.CorrelationId, new StringValues(_correlationId));
            _httpContext.Request.Headers.Add(Constants.UserId, new StringValues(_userId));

            _mockLogger = new Mock<ILogger<LoggingScopeMiddleware>>();
        }

        [Test]
        public async Task InvokeAsyncTestBeginsLoggingScope()
        {
            var sut = new LoggingScopeMiddleware(null);
            await sut.InvokeAsync(_httpContext, _mockLogger.Object).ConfigureAwait(false);

            var expectedState = $"CorrelationId: {_correlationId}; UserId: {_userId}";
            _mockLogger.Verify(x => x.BeginScope(It.Is<object>(y => y.ToString() == expectedState)), Times.Once());
        }
    }
}
