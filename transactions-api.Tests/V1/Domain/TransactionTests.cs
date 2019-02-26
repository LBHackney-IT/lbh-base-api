using System;
using Bogus;
using NUnit.Framework;
using transactions_api.V1.Domain;
using UnitTests.V1.Helper;

namespace UnitTests.V1.Domain
{
    [TestFixture]
    public class TransactionTests
    {
        Faker _faker = new Faker();

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

        [Test]
        public void TransactionsCanBeCompared()
        {
            Transaction transactionA = TransactionHelper.CreateTransaction();

            Transaction transactionB = new Transaction
            {
                Date = transactionA.Date,
                Code = transactionA.Code,
                Balence = transactionA.Balence
            };

            Assert.True(transactionA.Equals(transactionB));
            Assert.AreEqual(transactionA.GetHashCode(),transactionB.GetHashCode());

            Assert.AreNotSame(transactionA, transactionB);
            Assert.AreEqual(transactionA, transactionB);
        }

        [Test]
        public void CanBeCreatedFromUhTransactions()
        {
            var uhTransaction = new UhTransaction();

            var transaction = Transaction.fromUHTransaction(uhTransaction);

            Assert.AreEqual(uhTransaction.Balence,transaction.Balence);
            Assert.AreEqual(uhTransaction.Code,transaction.Code);
            Assert.AreEqual(uhTransaction.Date,transaction.Date);

        }
    }
}
