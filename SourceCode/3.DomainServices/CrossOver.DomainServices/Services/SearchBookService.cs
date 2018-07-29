using CrossOver.DomainServices.Core;
using CrossOver.EntityModels.SearchBook;
using CrossOver.IDomainServices.AutoMapper;
using CrossOver.IDomainServices.Services;
using CrossOver.ServiceResponse;
using CrossOver.Utility;
using CrossOver.Utility.ParamViewModels;
using CrossOver.ViewModels;
using System;
using System.Linq;

namespace CrossOver.DomainServices
{
    public class SearchBookService : BaseService<BookEntityModel, BookViewModel>, ISearchBookService
    {

        public ResponseResults<BookViewModel> GetBooks(SearchBookViewModel searchParam)
        {
            var response = new ResponseResults<BookViewModel> { IsSucceed = true, Message = AppMessages.RETRIEVED_DETAILS_SUCCESSFULLY };
            try
            {
                var models = UnitOfWork.BookRepository.GetBooks(searchParam);
                response.ViewModels = models.ToViewModel<BookEntityModel, BookViewModel>().ToList();

                if (!string.IsNullOrWhiteSpace(searchParam.UserName))
                {
                    var user = UnitOfWork.UserRepository.FindByUserName(searchParam.UserName);
                    var demandedBookLookUp = UnitOfWork.UserDemandRepository.GetMany(o => o.UserId == user.Id).Select(o => o.BookId).ToList();
                    response.ViewModels.ForEach(o => o.IsRequested = demandedBookLookUp.Contains(o.Id));
                }

                if (response.ViewModels.Count <= 0)
                {
                    response.Message = AppMessages.NO_RECORD_FOUND;
                }
            }
            catch (Exception ex)
            {
                response.IsSucceed = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public  ResponseResults<BookViewModel> GetTop10(string userName)
        {
            var response = new ResponseResults<BookViewModel>() { IsSucceed = true, Message = AppMessages.RETRIEVED_DETAILS_SUCCESSFULLY };
            try
            {
                var models = UnitOfWork.SetDbContext(BaseRepository).PageAll(0, 10);
                response.ViewModels = models.ToViewModel<BookEntityModel, BookViewModel>().ToList();

                if (!string.IsNullOrWhiteSpace(userName))
                {
                    var user = UnitOfWork.UserRepository.FindByUserName(userName);
                    var demandedBookLookUp = UnitOfWork.UserDemandRepository.GetMany(o => o.UserId == user.Id).Select(o => o.BookId).ToList();
                    response.ViewModels.ForEach(o => o.IsRequested = demandedBookLookUp.Contains(o.Id));
                }
            }
            catch (Exception ex)
            {
                response.IsSucceed = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
