using base_api.V1.Domain;

namespace base_api.V1.Factory
{
    public class TransactionFactory : AbstractTransactionFactory
    {
        public override Transaction FromUhTransaction(UhTransaction transaction)
        {
            return new Transaction
            {
                Balance = transaction.Balance,
                Code = transaction.Code,
                Date = transaction.Date
            };
        }
    }
}
