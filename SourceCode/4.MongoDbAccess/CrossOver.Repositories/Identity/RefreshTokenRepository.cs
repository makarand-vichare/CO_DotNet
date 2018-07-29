using CrossOver.EntityModels.Identity;
using CrossOver.IRepositories.Identity;
using CrossOver.Repositories.Core;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Threading.Tasks;

namespace CrossOver.Repositories.Identity
{
    public class RefreshTokenRepository : BaseRepository<RefreshTokenEntityModel>, IRefreshTokenRepository
    {
        public Task<RefreshTokenEntityModel> FindByTokenIdAsync(string tokenId)
        {
            return DbSet.AsQueryable().FirstOrDefaultAsync(x => x.TokenId == tokenId);
        }
    }
}
