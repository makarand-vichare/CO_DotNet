using CrossOver.EntityModels.Identity;
using CrossOver.IRepositories.Identity;
using CrossOver.Repositories.Core;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace CrossOver.Repositories.Identity
{
    public class ClientRepository : BaseRepository<ClientEntityModel>, IClientRepository
    {
        public ClientEntityModel FindByClientId(string clientId)
        {
            return DbSet.AsQueryable().Where(x => x.ClientId == clientId).FirstOrDefault();
        }
    }
}
