using CrossOver.EntityModels.UserDemand;
using CrossOver.IRepositories.UserDemand;
using CrossOver.Repositories.Core;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using MongoDB.Bson;

namespace CrossOver.Repositories.UserDemand
{
    public class UserDemandRepository : BaseRepository<UserDemandEntityModel>, IUserDemandRepository
    {

        public IList<UserDemandEntityModel> GetUserDemands(ObjectId userId)
        {
            var entityList = DbSet.AsQueryable().Where(o => o.UserId == userId).ToList();
            return entityList;
        }

    }
 
}
