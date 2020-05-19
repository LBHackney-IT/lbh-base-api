using FluentAssertions;
using NUnit.Framework;
using BaseApi.V1.Domain;
using BaseApi.V1.Factory;

namespace UnitTests.V1.Factories
{
    [TestFixture]
    public class EntityFactoryTest
    {
        [Test]
        public void CanBeCreatedFromDatabaseEntity()
        {
            var databaseEntity = new DatabaseEntity();
            var entity = new EntityFactory().ToDomain(databaseEntity);

            databaseEntity.Id.Should().Be(entity.Id);
            databaseEntity.CreatedAt.Should().BeSameDateAs(entity.CreatedAt);
        }
    }
}
