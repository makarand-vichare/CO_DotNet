using CrossOver.EntityModels.Identity;
using CrossOver.IRepositories.Identity;
using CrossOver.Repositories.Core;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CrossOver.Repositories.Identity
{
    public class UserRepository : BaseRepository<UserEntityModel>, IUserRepository
    {

        public UserEntityModel FindByUserName(string username)
        {
            return DbSet.AsQueryable().Where(x => x.UserName == username).FirstOrDefault();
        }

        public Task<UserEntityModel> FindByUserNameAsync(string username)
        {
            return DbSet.AsQueryable().FirstOrDefaultAsync(x => x.UserName == username);
        }

        public Task<UserEntityModel> FindByUserNameAsync(CancellationToken cancellationToken, string username)
        {
            return DbSet.AsQueryable().FirstOrDefaultAsync(x => x.UserName == username, cancellationToken);
        }
    }
}
