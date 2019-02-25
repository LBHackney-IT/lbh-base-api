using System;
using Bogus;
using NUnit.Framework;
using transactions_api.V1.Domain;

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
            DateTime date = new DateTime(2019, 02, 21);
            string words = _faker.Random.Words();
            decimal balance = _faker.Finance.Amount();

            Transaction transactionA = new Transaction
            {
                Date = date,
                Code = words,
                Balence = balance
            };

            Transaction transactionB = new Transaction
            {
                Date = date,
                Code = words,
                Balence = balance
            };

            Assert.True(transactionA.Equals(transactionB));
            Assert.AreEqual(transactionA.GetHashCode(),transactionB.GetHashCode());

            Assert.AreNotSame(transactionA, transactionB);
            Assert.AreEqual(transactionA, transactionB);
        }
    }
}
