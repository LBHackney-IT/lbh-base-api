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
            Faker _faker = new Faker();
            UhTransaction uhTransaction = CopyTransactionFields(transaction);
            uhTransaction.Id = _faker.Random.Int();
            uhTransaction.PropRef = _faker.Random.AlphaNumeric(length: 12);
            uhTransaction.transno = _faker.Random.Int();
            uhTransaction.line_no = _faker.Random.Int();
            uhTransaction.adjustment = _faker.Random.Bool();
            uhTransaction.apportion = _faker.Random.Bool();
            uhTransaction.prop_deb = _faker.Random.Bool();
            uhTransaction.none_rent = _faker.Random.Bool();
            uhTransaction.receipted = _faker.Random.Bool();
            uhTransaction.line_segno = _faker.Random.Decimal();

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
