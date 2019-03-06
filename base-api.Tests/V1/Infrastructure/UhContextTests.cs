using System.Linq;
using NUnit.Framework;
using base_api.V1.Domain;
using UnitTests.V1.Helper;

namespace UnitTests.V1.Infrastructure
{
    [TestFixture]
    public class UhContextTest : DbTest
    {
        [Test]
        public void CanGetAUhTransaction()
        {
            UhTransaction uhTransaction = UhTransactionHelper.CreateUhTransaction();

            _uhContext.Add(uhTransaction);
            _uhContext.SaveChanges();

            var result = _uhContext.UTransactions.ToList().FirstOrDefault();

            Assert.AreEqual(uhTransaction, result);
        }
    }
}
