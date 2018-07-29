using CrossOver.EntityModels.UserDemand;
using CrossOver.IRepositories.Core;
using MongoDB.Bson;
using System.Collections.Generic;

namespace CrossOver.IRepositories.UserDemand
{
    public interface IUserDemandRepository : IBaseRepository<UserDemandEntityModel>
    {
        IList<UserDemandEntityModel> GetUserDemands(ObjectId userId);
    }
}
