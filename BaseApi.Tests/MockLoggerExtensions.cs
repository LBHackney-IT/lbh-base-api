using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Tests
{
    public static class MockLoggerExtensions
    {
        /// <summary>
        /// Verifies if the exact log message was logged for the stated level, a specific number of times.
        /// </summary>
        /// <typeparam name="T">The class type for which the logger is dedicated</typeparam>
        /// <param name="logger">The mock logger object</param>
        /// <param name="level">The log level</param>
        /// <param name="msg">The log message</param>
        /// <param name="times">The expected number of times the mock was called.</param>
        public static void VerifyExact<T>(this Mock<ILogger<T>> logger, LogLevel level, string msg, Times times) where T : class
        {
            logger.Verify(
                x => x.Log(level,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => o.ToString() == msg),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                times);
        }
        public static void VerifyExact(this Mock<ILogger> logger, LogLevel level, string msg, Times times)
        {
            logger.Verify(
                x => x.Log(level,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => o.ToString() == msg),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                times);
        }

        /// <summary>
        /// Verifies if the stated string appears anywhere in a logged log message for the stated level, a specific number of times.
        /// </summary>
        /// <typeparam name="T">The class type for which the logger is dedicated</typeparam>
        /// <param name="logger">The mock logger object</param>
        /// <param name="level">The log level</param>
        /// <param name="msg">The log message</param>
        /// <param name="times">The expected number of times the mock was called.</param>
        public static void VerifyContains<T>(this Mock<ILogger<T>> logger, LogLevel level, string msg, Times times) where T : class
        {
            logger.Verify(
                x => x.Log(level,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => o.ToString().Contains(msg)),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                times);
        }
        public static void VerifyContains(this Mock<ILogger> logger, LogLevel level, string msg, Times times)
        {
            logger.Verify(
                x => x.Log(level,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => o.ToString().Contains(msg)),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                times);
        }

        /// <summary>
        /// Verifies if *any* log messages were logged for the stated level, a specific number of times.
        /// </summary>
        /// <typeparam name="T">The class type for which the logger is dedicated</typeparam>
        /// <param name="logger">The mock logger object</param>
        /// <param name="level">The log level</param>
        /// <param name="times">The expected number of times the mock was called.</param>
        public static void VerifyAny<T>(this Mock<ILogger<T>> logger, LogLevel level, Times times) where T : class
        {
            logger.Verify(
                x => x.Log(level,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                times);
        }
        public static void VerifyAny(this Mock<ILogger> logger, LogLevel level, Times times)
        {
            logger.Verify(
                x => x.Log(level,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                times);
        }
    }
}
