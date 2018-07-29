using CrossOver.EntityModels.SearchBook;
using CrossOver.IRepositories.Core;
using CrossOver.Utility.ParamViewModels;
using System.Collections.Generic;

namespace CrossOver.IRepositories.SearchBook
{
    public interface IBookRepository : IBaseRepository<BookEntityModel>
    {
        List<BookEntityModel> GetBooks(SearchBookViewModel searchParam);
    }
}
