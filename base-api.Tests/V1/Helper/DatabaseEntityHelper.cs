using base_api.V1.Domain;

namespace UnitTests.V1.Helper
{
    public static class DatabaseEntityHelper
    {
        public static DatabaseEntity CreateDatabaseEntity()
        {
            return CreateDatabaseEntityFrom(EntityHelper.CreateEntity());
        }

        public static DatabaseEntity CreateDatabaseEntityFrom(Entity entity)
        {
            return new DatabaseEntity
            {
                Id = entity.Id,
                CreatedAt = entity.CreatedAt,
            };
        }
    }
}
