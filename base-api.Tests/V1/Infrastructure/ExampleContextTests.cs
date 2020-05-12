using System.Linq;
using NUnit.Framework;
using base_api.V1.Domain;
using UnitTests.V1.Helper;

namespace UnitTests.V1.Infrastructure
{
    [TestFixture]
    public class DatabaseContextTest : DbTest
    {
        [Test]
        public void CanGetADatabaseEntity()
        {
            DatabaseEntity databaseEntity = DatabaseEntityHelper.CreateDatabaseEntity();

            _databaseContext.Add(databaseEntity);
            _databaseContext.SaveChanges();

            var result = _databaseContext.DatabaseEntities.ToList().FirstOrDefault();

            Assert.AreEqual(result, databaseEntity);
        }
    }
}
