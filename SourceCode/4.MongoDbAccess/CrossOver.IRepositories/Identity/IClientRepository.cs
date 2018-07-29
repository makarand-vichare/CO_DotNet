using CrossOver.EntityModels.Identity;
using CrossOver.IRepositories.Core;

namespace CrossOver.IRepositories.Identity
{
    public interface IClientRepository : IBaseRepository<ClientEntityModel>
    {
        ClientEntityModel FindByClientId(string clientId);

    }
}
