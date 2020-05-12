using NUnit.Framework;
using base_api.V1.Domain;
using base_api.V1.Factory;

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

            Assert.AreEqual(databaseEntity.Id, entity.Id);
            Assert.AreEqual(databaseEntity.CreatedAt, entity.CreatedAt);
        }
    }
}
