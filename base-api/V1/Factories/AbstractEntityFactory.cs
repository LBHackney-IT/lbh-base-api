using System.Collections.Generic;
using System.Linq;
using base_api.V1.Domain;

namespace base_api.V1.Factory
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
