using System.Linq;
using NUnit.Framework;
using BaseApi.V1.Domain;
using UnitTests.V1.Helper;

namespace UnitTests.V1.Infrastructure
{
    [TestFixture]
    public class DatabaseContextTest : DatabaseTests
    {
        [Test]
        public void CanGetADatabaseEntity()
        {
            DatabaseEntity databaseEntity = DatabaseEntityHelper.CreateDatabaseEntity();

            DatabaseContext.Add(databaseEntity);
            DatabaseContext.SaveChanges();

            var result = DatabaseContext.DatabaseEntities.ToList().FirstOrDefault();

            Assert.AreEqual(result, databaseEntity);
        }
    }
}
