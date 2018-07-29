using CrossOver.EntityModels.UserDemand;
using CrossOver.IDomainServices.Core;
using CrossOver.ServiceResponse;
using CrossOver.ViewModels;

namespace CrossOver.IDomainServices.Services
{
    public interface IUserDemandService : IBaseService<UserDemandEntityModel, UserDemandViewModel>
    {
        ResponseResults<UserDemandDetailViewModel> GetUserDemands(string userName);
        BaseResponseResult DemandBook(string bookId, string userName);
    }
}
