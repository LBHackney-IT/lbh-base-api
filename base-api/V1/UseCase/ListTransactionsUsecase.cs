using System;
using base_api.V1.Boundary;
using base_api.V1.Gateways;

namespace base_api.UseCase.V1
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
