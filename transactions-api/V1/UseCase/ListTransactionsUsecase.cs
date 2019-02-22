using System;
using transactions_api.V1.Boundary;
using transactions_api.V1.Domain;

namespace transactions_api.UseCase.V1
{
    public class ListTransactionsUsecase : IListTransactions
    {
        public ListTransactionsResponse Execute(ListTransactionsRequest listTransactionsRequest)
        {
           return new ListTransactionsResponse(new[] { new Transaction() }, listTransactionsRequest, DateTime.Now);
        }
    }
}
