using System.Linq;
using Bogus;
using NUnit.Framework;
using transactions_api.UseCase.V1;
using transactions_api.V1.Boundary;
using transactions_api.V1.Domain;

namespace UnitTests.V1.UseCase
{
    [TestFixture]
    public class ListTransactionsUsecaseTests
    {
        private ListTransactionsUsecase _classUnderTest;

        [SetUp]
        public void Setup()
        {
            _classUnderTest = new ListTransactionsUsecase();
        }

        [Test]
        public void ListOfTransactionsImplementsBoundaryInterface()
        {
            Assert.True(_classUnderTest is IListTransactions);
        }

        [Test]
        public void CanGetListOfTransactionsByPropertyReference()
        {
            var propertyRef = new Faker().Random.Hash();
            var request = new ListTransactionsRequest {PropertyRef = propertyRef};
            var results = _classUnderTest.Execute(request);

            Assert.NotNull(results);
            Assert.IsInstanceOf<ListTransactionsResponse>(results);
            Assert.IsInstanceOf<Transaction>(results.Transactions.First());

            Assert.IsInstanceOf<ListTransactionsRequest>(results.Request);
            Assert.AreEqual(propertyRef, results.Request.PropertyRef);
        }
    }
}
