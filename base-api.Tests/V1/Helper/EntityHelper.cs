using Bogus;
using base_api.V1.Domain;

namespace UnitTests.V1.Helper
{
    public class EntityHelper
    {
        public static Entity CreateEntity()
        {
            var faker = new Faker();
            var entity = new Entity
            {
                Id = faker.Random.Int(),
                CreatedAt = faker.Date.Past(),
            };

            return entity;
        }
    }
}
