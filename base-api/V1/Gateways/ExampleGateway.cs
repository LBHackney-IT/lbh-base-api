
using base_api.V1.Domain;
using base_api.V1.Factory;
using base_api.V1.Infrastructure;

namespace base_api.V1.Gateways
{
    public class ExampleGateway : IExampleGateway
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly EntityFactory _entityFactory;

        public ExampleGateway(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _entityFactory = new EntityFactory();
        }

        public Entity GetEntityById(int id)
        {
            var result = _databaseContext.DatabaseEntities.Find(id);

            return (result != null) ?
                _entityFactory.ToDomain(result) :
                null;
        }
    }
}
