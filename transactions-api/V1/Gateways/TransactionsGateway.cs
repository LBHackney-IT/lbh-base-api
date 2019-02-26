
using System.Collections.Generic;
using System.Linq;
using transactions_api.V1.Domain;
using UnitTests.V1.Infrastructure;

namespace UnitTests.V1.Gateways
{
    public class TransactionsGateway : ITransactionsGateway
    {
        private readonly IUHContext _uhcontext;

        public TransactionsGateway(IUHContext uhcontext)
        {
            _uhcontext = uhcontext;
        }

        public List<Transaction> GetTransactionsByPropertyRef(string propertyRef)
        {
            var result = _uhcontext.UTransactions.Where(t => t.PropRef == propertyRef).ToList();

            return ConvertToTransactions(result);
        }

        private static List<Transaction> ConvertToTransactions(IEnumerable<UhTransaction> result)
        {
            return result.Select(Transaction.fromUHTransaction).ToList();
        }
    }
}
