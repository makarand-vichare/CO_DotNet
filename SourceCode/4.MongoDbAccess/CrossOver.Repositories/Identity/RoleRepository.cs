using CrossOver.EntityModels.Identity;
using CrossOver.IRepositories.Identity;
using CrossOver.Repositories.Core;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Threading.Tasks;

namespace CrossOver.Repositories.Identity
{
    public class RoleRepository : BaseRepository<RoleEntityModel>, IRoleRepository
    {

        public RoleEntityModel FindByName(string roleName)
        {
            return DbSet.AsQueryable().Where(x => x.Name == roleName).FirstOrDefault();
        }

        public Task<RoleEntityModel> FindByNameAsync(string roleName)
        {
            return DbSet.AsQueryable().FirstOrDefaultAsync(x => x.Name == roleName);
        }

        public Task<RoleEntityModel> FindByNameAsync(System.Threading.CancellationToken cancellationToken, string roleName)
        {
            return DbSet.AsQueryable().FirstOrDefaultAsync(x => x.Name == roleName, cancellationToken);
        }
    }
}
