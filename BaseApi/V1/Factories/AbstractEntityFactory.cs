using System.Collections.Generic;
using System.Linq;
using BaseApi.V1.Domain;

namespace BaseApi.V1.Factory
{
    public abstract class AbstractEntityFactory
    {
        public abstract Entity ToDomain(DatabaseEntity databaseEntity);

        public List<Entity> ToDomain(IEnumerable<DatabaseEntity> result)
        {
            return result.Select(ToDomain).ToList();
        }
    }
}
