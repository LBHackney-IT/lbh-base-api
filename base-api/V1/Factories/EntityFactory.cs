using base_api.V1.Domain;

namespace base_api.V1.Factory
{
    public class EntityFactory : AbstractEntityFactory
    {
        public override Entity ToDomain(DatabaseEntity databaseEntity)
        {
            return new Entity
            {
                Id = databaseEntity.Id,
                CreatedAt = databaseEntity.CreatedAt,
            };
        }
    }
}
