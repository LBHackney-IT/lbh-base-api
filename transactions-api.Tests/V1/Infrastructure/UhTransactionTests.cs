using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NUnit.Framework;
using transactions_api.V1.Domain;
using UnitTests.V1.Helper;

namespace UnitTests.V1.Infrastructure
{
    [TestFixture]
    public class UhTransactionTests
    {
        [Test]
        public void canCreateFromATransactionDomain()
        {
            Transaction transaction = TransactionHelper.CreateTransaction();
            var result = UhTransaction.fromTransaction(transaction);

            Assert.AreEqual(transaction.Balance, result.Balance);
            Assert.AreEqual(transaction.Code, result.Code);
            Assert.AreEqual(transaction.Date, result.Date);
        }

    }
 }
