using transactions_api.V1.Domain;

namespace UnitTests.V1.Gateways
{
    public interface ITransactionsGateway
    {
        Transaction[] GetTransactionsByPropertyRef(string propertyRef);
    }
}
