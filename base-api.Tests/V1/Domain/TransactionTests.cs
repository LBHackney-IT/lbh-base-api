using System;
using Bogus;
using NUnit.Framework;
using base_api.V1.Domain;
using base_api.V1.Factory;
using UnitTests.V1.Helper;

namespace UnitTests.V1.Domain
{
    [TestFixture]
    public class TransactionTests
    {
        [Test]
        public void TransactionsHaveABalance()
        {
            var transaction = new Transaction();
            Assert.Zero(transaction.Balance);
        }

        [Test]
        public void TransactionsHaveACode()
        {
            var transaction = new Transaction();
            Assert.IsNull(transaction.Code);
        }

        [Test]
        public void TransactionsHaveADateTime()
        {
            var transaction = new Transaction();
            var date = new DateTime(2019, 02, 21);
            transaction.Date = date;
            Assert.AreEqual(date, transaction.Date);
        }

        [Test]
        public void TransactionsCanBeCompared()
        {
            var transactionA = TransactionHelper.CreateTransaction();

            var transactionB = new Transaction
            {
                Date = transactionA.Date,
                Code = transactionA.Code,
                Balance = transactionA.Balance
            };

            Assert.True(transactionA.Equals(transactionB));
            Assert.AreEqual(transactionA.GetHashCode(), transactionB.GetHashCode());

            Assert.AreNotSame(transactionA, transactionB);
            Assert.AreEqual(transactionA, transactionB);
        }
    }
}
