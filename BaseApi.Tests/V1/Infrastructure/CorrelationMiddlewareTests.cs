using System.Threading.Tasks;
using BaseApi.V1.Controllers;
using BaseApi.V1.Infrastructure;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace BaseApi.Tests.V1.Infrastructure
{
    [TestFixture]
    public class CorrelationMiddlewareTest
    {
        private CorrelationMiddleware _sut;

        [SetUp]
        public void Init()
        {
            _sut = new CorrelationMiddleware(null);
        }

        [Test]
        public async Task DoesNotReplaceCorrelationIdIfOneExists()
        {
            // Arrange
            var httpContext = new DefaultHttpContext();
            var headerValue = "123";

            httpContext.HttpContext.Request.Headers.Add(Constants.CorrelationId, headerValue);

            // Act
            await _sut.InvokeAsync(httpContext).ConfigureAwait(false);

            // Assert
            httpContext.HttpContext.Request.Headers[Constants.CorrelationId].Should().BeEquivalentTo(headerValue);
        }

        [Test]
        public async Task AddsCorrelationIdIfOneDoesNotExist()
        {
            // Arrange
            var httpContext = new DefaultHttpContext();

            // Act
            await _sut.InvokeAsync(httpContext).ConfigureAwait(false);

            // Assert
            httpContext.HttpContext.Request.Headers[Constants.CorrelationId].Should().HaveCountGreaterThan(0);
        }
    }
}
