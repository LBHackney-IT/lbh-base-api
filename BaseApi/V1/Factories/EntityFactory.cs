using BaseApi.V1.Domain;
using BaseApi.V1.Infrastructure;

namespace BaseApi.V1.Factories
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
