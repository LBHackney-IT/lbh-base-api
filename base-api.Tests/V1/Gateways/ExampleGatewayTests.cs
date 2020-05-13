using AutoFixture;
using Bogus;
using FluentAssertions;
using NUnit.Framework;
using UnitTests.V1.Helper;
using base_api.V1.Domain;
using base_api.V1.Gateways;

namespace UnitTests.V1.Gateways
{
    [TestFixture]
    public class ExampleGatewayTests : DbTest
    {
        private readonly Faker _faker = new Faker();
        private Fixture _fixture = new Fixture();
        private ExampleGateway _classUnderTest;

        [SetUp]
        public void Setup()
        {
            _classUnderTest = new ExampleGateway(_databaseContext);
        }

        [Test]
        public void GatewayImplementsBoundaryInterface()
        {
            Assert.NotNull(_classUnderTest is IExampleGateway);
        }

        [Test]
        public void GetEntityById_ReturnsEmptyArray()
        {
            var response = _classUnderTest.GetEntityById(123);

            response.Should().BeNull();
        }

        [Test]
        public void GetEntityById_ReturnsCorrectResponse()
        {
            var entity = _fixture.Create<Entity>();
            var databaseEntity = DatabaseEntityHelper.CreateDatabaseEntityFrom(entity);

            _databaseContext.DatabaseEntities.Add(databaseEntity);
            _databaseContext.SaveChanges();

            var response = _classUnderTest.GetEntityById(databaseEntity.Id);

            databaseEntity.Id.Should().Be(response.Id);
            databaseEntity.CreatedAt.Should().BeSameDateAs(response.CreatedAt);
        }
    }
}
