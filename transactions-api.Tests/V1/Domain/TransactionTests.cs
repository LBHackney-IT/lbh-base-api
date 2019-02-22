using System;
using NUnit.Framework;
using transactions_api.V1.Domain;

namespace UnitTests.V1.Domain
{
    [TestFixture]
    public class TransactionTests
    {
        [Test]
        public void TransactionsHaveABalance()
        {
            Transaction transaction = new Transaction();
            Assert.Zero(transaction.Balence);
        }

        [Test]
        public void TransactionsHaveACode()
        {
            Transaction transaction = new Transaction();
            Assert.IsNull(transaction.Code);
        }

        [Test]
        public void TransactionsHaveADateTime()
        {
            Transaction transaction = new Transaction();
            DateTime date = new DateTime(2019, 02, 21);
            transaction.Date = date;
            Assert.AreEqual(date, transaction.Date);
        }
    }
}
