using System;
using transactions_api.V1.Domain;

namespace transactions_api.V1.Boundary
{
    public class ListTransactionsResponse
    {
        public readonly ListTransactionsRequest Request;
        public readonly DateTime GeneratedAt;
        public readonly Transaction[] Transactions;

        public ListTransactionsResponse(Transaction[] transactions, ListTransactionsRequest request, DateTime generatedAt)
        {
            Request = request;
            GeneratedAt = generatedAt;
            Transactions = transactions;
        }
    }
}
