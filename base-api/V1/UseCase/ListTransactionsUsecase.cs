using System;
using transactions_api.V1.Boundary;
using UnitTests.V1.Gateways;

namespace transactions_api.UseCase.V1
{
    public class ListTransactionsUsecase : IListTransactions
    {
        private readonly ITransactionsGateway _transactionsGateway;

        public ListTransactionsUsecase(ITransactionsGateway transactionsGateway)
        {
            _transactionsGateway = transactionsGateway;
        }

        public ListTransactionsResponse Execute(ListTransactionsRequest listTransactionsRequest)
        {
            var results = _transactionsGateway.GetTransactionsByPropertyRef(listTransactionsRequest.PropertyRef);

           return new ListTransactionsResponse(results, listTransactionsRequest, DateTime.Now);
        }
    }
}
