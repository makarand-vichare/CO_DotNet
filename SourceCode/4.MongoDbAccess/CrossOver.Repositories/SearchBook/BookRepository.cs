using CrossOver.EntityModels.SearchBook;
using CrossOver.IRepositories.SearchBook;
using CrossOver.Repositories.Core;
using CrossOver.Utility.ParamViewModels;
using MongoDB.Driver;
using System.Collections.Generic;
using MongoDB.Driver.Linq;
using System.Linq;

namespace CrossOver.Repositories.SearchBook
{
    public class BookRepository : BaseRepository<BookEntityModel>, IBookRepository
    {
        public List<BookEntityModel> GetBooks(SearchBookViewModel searchParam)
        {
            var query = DbSet.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchParam.Title))
            {
                query = query.Where(o => o.Title.ToLower().Trim().Contains(searchParam.Title.ToLower().Trim()));
            }

            if (!string.IsNullOrWhiteSpace(searchParam.Author))
            {
                query = query.Where(o => o.Authors.Any(s=>s.StartsWith(searchParam.Author.Trim())));
            }

            return query.ToList();
        }
    }
}
