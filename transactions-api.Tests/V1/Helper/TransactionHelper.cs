using Bogus;
using transactions_api.V1.Domain;

namespace UnitTests.V1.Helper
{
    public class TransactionHelper
    {
        public static Transaction CreateTransaction()
        {
            var faker = new Faker();
            var transaction = new Transaction
            {
                Date = faker.Date.Past(),
                Code = faker.Random.String(length: 3),
                Balence = faker.Finance.Amount(),
            };
            return transaction;
        }
    }
}
