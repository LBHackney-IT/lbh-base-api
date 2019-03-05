using System.Collections.Generic;
using transactions_api.V1.Domain;

namespace UnitTests.V1.Gateways
{
    public interface ITransactionsGateway
    {
        List<Transaction> GetTransactionsByPropertyRef(string propertyRef);
    }
}
