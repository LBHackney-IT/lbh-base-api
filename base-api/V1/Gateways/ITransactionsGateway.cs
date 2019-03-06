using System.Collections.Generic;
using base_api.V1.Domain;

namespace base_api.V1.Gateways
{
    public interface ITransactionsGateway
    {
        List<Transaction> GetTransactionsByPropertyRef(string propertyRef);
    }
}
