using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Tests.V1
{
    [TestFixture]
    public class HttpHeadersExtensionsTests
    {
        private const string KEY = "someHeaderKey";
        private const string VALUE = "some value";
        private readonly Mock<IHeaderDictionary> _mockHeaders = new Mock<IHeaderDictionary>();
        delegate void SubmitCallback(string x, out StringValues y);

        [Test]
        public void GetHeaderValueThrowsNullHeaders()
        {
            Func<string> func = () => HttpHeadersExtensions.GetHeaderValue(null, KEY);
            func.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void GetHeaderValueKeyNotFoundReturnsNull()
        {
            StringValues outVal;
            _mockHeaders.Setup(x => x.TryGetValue(KEY, out outVal)).Returns(false);
            _mockHeaders.Object.GetHeaderValue(KEY).Should().BeNull();
        }

        [Test]
        public void GetHeaderValueFounddNullKeyValue()
        {
            StringValues outVal;
            _mockHeaders.Setup(x => x.TryGetValue(KEY, out outVal)).Returns(true);
            _mockHeaders.Object.GetHeaderValue(KEY).Should().BeNull();
        }

        [Test]
        public void GetHeaderValueFoundEmptyKeyValue()
        {
            StringValues outVal = new StringValues("");
            _mockHeaders.Setup(x => x.TryGetValue(KEY, out outVal)).Returns(true);
            _mockHeaders.Object.GetHeaderValue(KEY).Should().Be(string.Empty);
        }

        [Test]
        public void GetHeaderValueFoundSingleKeyValue()
        {
            StringValues outVal;
            _mockHeaders.Setup(x => x.TryGetValue(KEY, out outVal))
                .Callback(new SubmitCallback((string x, out StringValues y) => y = new StringValues(VALUE)))
                .Returns(true);
            _mockHeaders.Object.GetHeaderValue(KEY).Should().Be(VALUE);
        }

        [Test]
        public void GetHeaderValueFoundManyKeyValuesReturnsFirst()
        {
            StringValues outVal;
            _mockHeaders.Setup(x => x.TryGetValue(KEY, out outVal))
                .Callback(new SubmitCallback((string x, out StringValues y) => y = new StringValues(new[] { VALUE, "val 2", "val 3" })))
                .Returns(true);
            _mockHeaders.Object.GetHeaderValue(KEY).Should().Be(VALUE);
        }

    }
}
