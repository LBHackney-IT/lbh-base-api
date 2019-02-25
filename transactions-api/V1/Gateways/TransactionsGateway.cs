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

        public Transaction[] GetTransactionsByPropertyRef(string propertyRef)
        {
            Transaction[] response = {new Transaction()};
            return response;
        }
    }
}
