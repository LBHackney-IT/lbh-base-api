using Amazon.DynamoDBv2.DataModel;
using AutoFixture;
using BaseApi.Tests.V1.Helper;
using BaseApi.V1.Domain;
using BaseApi.V1.Gateways;
using BaseApi.V1.Infrastructure;
using FluentAssertions;
using Hackney.Core.Testing.Shared;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace BaseApi.Tests.V1.Gateways
{
    //TODO: Remove this file if DynamoDb gateway not being used
    //TODO: Rename Tests to match gateway name
    //For instruction on how to run tests please see the wiki: https://github.com/LBHackney-IT/lbh-base-api/wiki/Running-the-test-suite.
    [TestFixture]
    public class DynamoDbGatewayTests : DynamoDbIntegrationTests<Startup>
    {
        private readonly Fixture _fixture = new Fixture();
        private DynamoDbGateway _classUnderTest;

        private Mock<ILogger<DynamoDbGateway>> _logger;
        private LogCallAspectFixture _logCallAspectFixture;

        [SetUp]
        public void Setup()
        {
            _logCallAspectFixture = new LogCallAspectFixture();
            _logger = new Mock<ILogger<DynamoDbGateway>>();
            _classUnderTest = new DynamoDbGateway(DynamoDbContext, _logger.Object);
        }

        [Test]
        [Ignore("Enable if using DynamoDb")]

        public async Task GetEntityByIdReturnsNullIfEntityDoesntExist()
        {
            var response = await _classUnderTest.GetEntityById(123).ConfigureAwait(false);

            response.Should().BeNull();
            _logger.VerifyExact(LogLevel.Debug, $"Calling IDynamoDBContext.LoadAsync for id parameter 123", Times.Once());

        }

        [Test]
        [Ignore("Enable if using DynamoDb")]
        public async Task VerifiesGatewayMethodsAddtoDB()
        {
            var entity = _fixture.Build<DatabaseEntity>()
                                   .With(x => x.CreatedAt, DateTime.UtcNow).Create();
            InsertDatatoDynamoDB(entity);

            var result = await _classUnderTest.GetEntityById(entity.Id).ConfigureAwait(false);
            result.Should().BeEquivalentTo(entity);
            _logger.VerifyExact(LogLevel.Debug, $"Calling IDynamoDBContext.LoadAsync for id parameter {entity.Id}", Times.Once());
        }

        private void InsertDatatoDynamoDB(DatabaseEntity entity)
        {
            DynamoDbContext.SaveAsync<DatabaseEntity>(entity).GetAwaiter().GetResult();
            CleanupActions.Add(async () => await DynamoDbContext.DeleteAsync(entity).ConfigureAwait(false));
        }
    }
}
