using System.Collections.Generic;
using System.Linq;
using Bogus;
using NUnit.Framework;
using base_api.UseCase.V1;
using base_api.V1.Boundary;
using base_api.V1.Domain;
using Moq;
using base_api.V1.Gateways;

namespace UnitTests.V1.UseCase
{
    [TestFixture]
    public class ListTransactionsUsecaseTests
    {
        private ListTransactionsUsecase _classUnderTest;
        private Mock<ITransactionsGateway> _transactionsGateway;

        [SetUp]
        public void Setup()
        {
            _transactionsGateway = new Mock<ITransactionsGateway>();
            _classUnderTest = new ListTransactionsUsecase(_transactionsGateway.Object);
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

            List<Transaction> response = new List<Transaction> {new Transaction()};

            _transactionsGateway.Setup(foo => foo.GetTransactionsByPropertyRef(propertyRef)).Returns(response);

            var results = _classUnderTest.Execute(request);

            Assert.NotNull(results);
            Assert.IsInstanceOf<ListTransactionsResponse>(results);
            Assert.IsInstanceOf<Transaction>(results.Transactions.First());

            Assert.IsInstanceOf<ListTransactionsRequest>(results.Request);
            Assert.AreEqual(propertyRef, results.Request.PropertyRef);
        }

        [Test]
        public void ExecuteCallsTransactionGateway()
        {
            var propertyRef = new Faker().Random.Hash();

            var request = new ListTransactionsRequest {PropertyRef = propertyRef};

            _classUnderTest.Execute(request);

            _transactionsGateway.Verify(gateway => gateway.GetTransactionsByPropertyRef(propertyRef));
        }

        [Test]
        public void ExecuteReturnsResponceUsingGatewayResults()
        {
            var propertyRef = new Faker().Random.Hash();

            var request = new ListTransactionsRequest {PropertyRef = propertyRef};

            List<Transaction> response = new List<Transaction>{ new Transaction(), new Transaction()};

            _transactionsGateway.Setup(foo => foo.GetTransactionsByPropertyRef(propertyRef)).Returns(response);


            var result = _classUnderTest.Execute(request);

            Assert.AreEqual(response, result.Transactions);

        }
    }
}
