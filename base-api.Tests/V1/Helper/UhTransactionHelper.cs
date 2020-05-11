using Bogus;
using base_api.V1.Domain;

namespace UnitTests.V1.Helper
{
    public static class UhTransactionHelper
    {
        public static UhTransaction CreateUhTransaction()
        {
            return CreateUhTransactionFrom(TransactionHelper.CreateTransaction());
        }

        public static UhTransaction CreateUhTransactionFrom(Transaction transaction)
        {
            var faker = new Faker();
            var uhTransaction = CopyTransactionFields(transaction);
            uhTransaction.Id = faker.Random.Int();
            uhTransaction.PropRef = faker.Random.AlphaNumeric(length: 12);
            uhTransaction.transno = faker.Random.Int();
            uhTransaction.line_no = faker.Random.Int();
            uhTransaction.adjustment = faker.Random.Bool();
            uhTransaction.apportion = faker.Random.Bool();
            uhTransaction.prop_deb = faker.Random.Bool();
            uhTransaction.none_rent = faker.Random.Bool();
            uhTransaction.receipted = faker.Random.Bool();
            uhTransaction.line_segno = faker.Random.Decimal();

            return uhTransaction;
        }

        private static UhTransaction CopyTransactionFields(Transaction transaction)
        {
            return new UhTransaction
            {
                Balance = transaction.Balance,
                Code = transaction.Code,
                Date = transaction.Date
            };
        }
    }
}
