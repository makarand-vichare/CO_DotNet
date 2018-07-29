using CrossOver.ServiceResponse;
using CrossOver.EntityModels.Core;
using CrossOver.ViewModels.Core;
using MongoDB.Bson;

namespace CrossOver.IDomainServices.Core
{
    public interface IBaseService<T,VM>  where T : BaseEntityModel where VM : BaseViewModel
    {
        ResponseResults<VM> GetAll();
        ResponseResult<VM> GetById(ObjectId id);
        ResponseResult<VM> Save(VM viewModel);
    }
}
