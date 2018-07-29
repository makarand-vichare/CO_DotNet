using CrossOver.EntityModels.Identity;
using CrossOver.EntityModels.SearchBook;
using CrossOver.EntityModels.UserDemand;
using CrossOver.IDomainServices.AutoMapper;
using CrossOver.IDomainServices.Services;
using CrossOver.ServiceResponse;
using CrossOver.Utility;
using CrossOver.Utility.ParamViewModels;
using CrossOver.ViewModels;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace CrossOver.Tests.Common.MockDomainServices
{
    public class SearchBookServiceGenerator
    {
        private static List<BookEntityModel> bookDataCollection = new List<BookEntityModel>();
        private static List<UserEntityModel> userDataCollection = new List<UserEntityModel>();
        private static List<UserDemandEntityModel> userDemandDataCollection = new List<UserDemandEntityModel>();

        public static Mock<ISearchBookService> GetMockService()
        {
            GetReadOnlyBookData();
            GetReadOnlyUserData();
            GetReadOnlyUserDemandData();

            var mockService = new Mock<ISearchBookService>();

            mockService.Setup(a => a.GetBooks(It.IsAny<SearchBookViewModel>())).Returns<SearchBookViewModel>(searchParam =>
            {
                var query = bookDataCollection.AsQueryable();
                var response = new ResponseResults<BookViewModel>() { IsSucceed = true, ViewModels = new List<BookViewModel>() ,  Message = AppMessages.RETRIEVED_DETAILS_SUCCESSFULLY };

                if (!string.IsNullOrWhiteSpace(searchParam.Title))
                {
                    query = query.Where(o => o.Title.ToLower().Trim().Contains(searchParam.Title.ToLower().Trim()));
                }

                if (!string.IsNullOrWhiteSpace(searchParam.Author))
                {
                    query = query.Where(o => o.Authors.Contains(searchParam.Author.Trim()));
                }

                var models = query.ToList();
                if (models != null && models.Count>0)
                { 
                    response.ViewModels = models.ToViewModel<BookEntityModel, BookViewModel>().ToList();
                    if (!string.IsNullOrWhiteSpace(searchParam.UserName))
                    {
                        var user = userDataCollection.FirstOrDefault(o => o.UserName == searchParam.UserName);
                        if (user != null)
                        {
                            var demandedBookLookUp = userDemandDataCollection.Where(o => o.UserId == user.Id).Select(o => o.BookId).ToList();
                            response.ViewModels.ForEach(o => o.IsRequested = demandedBookLookUp.Contains(o.Id));
                        }
                    }
                }

                if (response.ViewModels.Count <= 0)
                {
                    response.Message = AppMessages.NO_RECORD_FOUND;
                }
                return response;
            });

            mockService.Setup(a => a.GetTop10(It.IsAny<string>())).Returns<string>(userName =>
            {
                var response = new ResponseResults<BookViewModel>() { IsSucceed = true, ViewModels = new List<BookViewModel>(), Message = AppMessages.RETRIEVED_DETAILS_SUCCESSFULLY };

                response.ViewModels = bookDataCollection.Take(10).ToViewModel<BookEntityModel, BookViewModel>().ToList();
                if (!string.IsNullOrWhiteSpace(userName))
                {
                    var user = userDataCollection.FirstOrDefault(o => o.UserName == userName);
                    if (user != null)
                    {
                        var demandedBookLookUp = userDemandDataCollection.Where(o => o.UserId == user.Id).Select(o => o.BookId).ToList();
                        response.ViewModels.ForEach(o => o.IsRequested = demandedBookLookUp.Contains(o.Id));
                    }
                }

                if (response.ViewModels.Count <= 0)
                {
                    response.Message = AppMessages.NO_RECORD_FOUND;
                }
                return response;
            });

            return mockService;
        }

        public static void ResetBookDataCollection(List<BookEntityModel> rows = null)
        {
            if (rows == null && MockDB.Collections.Books.Count == 0)
            {
                GetReadOnlyBookData();
            }
            
            rows = rows ?? MockDB.Collections.Books;
            EmptyBookDataCollection();
            bookDataCollection.AddRange(Helper.DeepClone<List<BookEntityModel>>(rows));
        }

        public static void ResetUserDataCollection(List<UserEntityModel> rows = null)
        {
            if (rows == null && MockDB.Collections.Users.Count == 0)
            {
                GetReadOnlyUserData();
            }

            rows = rows ?? MockDB.Collections.Users;
            EmptyUserDataCollection();
            userDataCollection.AddRange(Helper.DeepClone<List<UserEntityModel>>(rows));
        }

        public static void ResetUserDemandDataCollection(List<UserDemandEntityModel> rows = null)
        {
            if (rows == null && MockDB.Collections.Users.Count == 0)
            {
                GetReadOnlyUserDemandData();
            }

            rows = rows ?? MockDB.Collections.UserDemands;
            EmptyUserDemandDataCollection();
            userDemandDataCollection.AddRange(Helper.DeepClone<List<UserDemandEntityModel>>(rows));
        }

        public static void EmptyBookDataCollection()
        {
            bookDataCollection = new List<BookEntityModel>();
        }

        public static void EmptyUserDataCollection()
        {
            userDataCollection = new List<UserEntityModel>();
        }

        public static void EmptyUserDemandDataCollection()
        {
            userDemandDataCollection = new List<UserDemandEntityModel>();
        }

        public static List<BookEntityModel> GetDataCollection()
        {
            return bookDataCollection;
        }

        public static void GetReadOnlyBookData()
        {
            if (MockDB.Collections.Books.Count == 0)
            {
                Helper.LoadMockData<BookEntityModel>();
            }

            ResetBookDataCollection();
        }

        public static void GetReadOnlyUserData()
        {
            if (MockDB.Collections.Users.Count == 0)
            {
                Helper.LoadMockData<UserEntityModel>();
            }

            ResetUserDataCollection();
        }

        public static void GetReadOnlyUserDemandData()
        {
            if (MockDB.Collections.UserDemands.Count == 0)
            {
                Helper.LoadMockData<UserDemandEntityModel>();
            }

            ResetUserDemandDataCollection();
        }
    }
}
