using base_api.V1.Domain;

namespace base_api.V1.Gateways
{
    public interface IExampleGateway
    {
        Entity GetEntityById(int id);
    }
}
