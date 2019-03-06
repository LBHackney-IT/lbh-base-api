using Bogus;
using base_api.V1.Domain;

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
                Balance = faker.Finance.Amount(),
            };
            return transaction;
        }
    }
}
