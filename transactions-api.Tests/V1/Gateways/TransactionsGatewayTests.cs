
using Bogus;
using NUnit.Framework;
using transactions_api.V1.Domain;
using UnitTests.V1.Infrastructure;

namespace UnitTests.V1.Gateways
{
    [TestFixture]
    public class TransactionsGatewayTests
    {
        private readonly Faker _faker = new Faker();
        private TransactionsGateway _classUnderTest;

        [SetUp]
        public void Setup()
        {
            _classUnderTest = new TransactionsGateway(new UHContext());
        }

        [Test]
        public void ListOfTransactionsImplementsBoundaryInterface()
        {
            Assert.True(_classUnderTest is ITransactionsGateway);
        }

        [Test]
        public void GetTransactionsByPropertyRef_ReturnsCorrectResponse()
        {
            var propRef = _faker.Random.Hash();

            Transaction[] expectedResponse = {new Transaction()};

            var responce = _classUnderTest.GetTransactionsByPropertyRef(propRef);

            Assert.AreEqual(expectedResponse, responce);
        }
    }
}
