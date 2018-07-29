using CrossOver.EntityModels.SearchBook;
using CrossOver.IDomainServices.Core;
using CrossOver.ServiceResponse;
using CrossOver.Utility.ParamViewModels;
using CrossOver.ViewModels;

namespace CrossOver.IDomainServices.Services
{
    public interface ISearchBookService : IBaseService<BookEntityModel, BookViewModel>
    {
        ResponseResults<BookViewModel> GetBooks(SearchBookViewModel searchParam);
        ResponseResults<BookViewModel> GetTop10(string userName);
    }
}
