using System;
using NUnit.Framework;
using base_api.V1.Domain;

namespace UnitTests.V1.Domain
{
    [TestFixture]
    public class EntityTests
    {
        [Test]
        public void EntitiesHaveAnId()
        {
            var entity = new Entity();
            Assert.IsNotNull(entity.Id);
        }

        [Test]
        public void EntitiesHaveACreatedAt()
        {
            var entity = new Entity();
            var date = new DateTime(2019, 02, 21);
            entity.CreatedAt = date;
            Assert.AreEqual(date, entity.CreatedAt);
        }
    }
}
