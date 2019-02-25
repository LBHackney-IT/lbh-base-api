using transactions_api.V1.Domain;

namespace UnitTests.V1.Gateways
{
    public class TransactionsGateway : ITransactionsGateway
    {
        public Transaction[] GetTransactionsByPropertyRef(string propertyRef)
        {
            Transaction[] response = {new Transaction()};
            return response;
        }
    }
}
