using BaseApi.V1.Domain;
using BaseApi.V1.Factory;
using BaseApi.V1.Infrastructure;

namespace BaseApi.V1.Gateways
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
