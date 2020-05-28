using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Infrastructure;

namespace BaseApi.V1.Gateways
{
    public class ExampleGateway : IExampleGateway
    {
        private readonly IDatabaseContext _databaseContext;

        public ExampleGateway(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Entity GetEntityById(int id)
        {
            var result = _databaseContext.DatabaseEntities.Find(id);

            return (result != null) ?
                result.ToDomain() :
                null;
        }
    }
}