using CrossOver.EntityModels.Identity;
using CrossOver.IRepositories.Core;
using System.Threading.Tasks;

namespace CrossOver.IRepositories.Identity
{
    public interface IRefreshTokenRepository : IBaseRepository<RefreshTokenEntityModel>
    {
        Task<RefreshTokenEntityModel> FindByTokenIdAsync(string tokenId);
    }
}
