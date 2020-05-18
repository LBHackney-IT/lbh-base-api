using BaseApi.V1.Domain;

namespace BaseApi.V1.Factory
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
