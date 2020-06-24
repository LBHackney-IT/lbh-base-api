using System.Collections.Generic;
using BaseApi.V1.Domain;

namespace BaseApi.V1.Gateways
{
    public interface IExampleGateway
    {
        Entity GetEntityById(int id);

        List<Entity> GetAll();
    }
}
