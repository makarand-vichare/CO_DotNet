using CrossOver.EntityModels.Identity;
using CrossOver.IRepositories.Core;
using System.Threading;
using System.Threading.Tasks;

namespace CrossOver.IRepositories.Identity
{
    public interface IRoleRepository : IBaseRepository<RoleEntityModel>
    {
        RoleEntityModel FindByName(string roleName);
        Task<RoleEntityModel> FindByNameAsync(string roleName);
        Task<RoleEntityModel> FindByNameAsync(CancellationToken cancellationToken, string roleName);
    }
}
