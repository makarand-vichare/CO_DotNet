using CrossOver.EntityModels.Identity;
using CrossOver.EntityModels.SearchBook;
using CrossOver.EntityModels.UserDemand;
using CrossOver.IDomainServices.Services;
using CrossOver.ServiceResponse;
using CrossOver.Utility;
using CrossOver.ViewModels;
using MongoDB.Bson;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrossOver.Tests.Common.MockDomainServices
{
    public class UserDemandServiceGenerator
    {
        private static List<BookEntityModel> bookDataCollection = new List<BookEntityModel>();
        private static List<UserEntityModel> userDataCollection = new List<UserEntityModel>();
        private static List<UserDemandEntityModel> userDemandDataCollection = new List<UserDemandEntityModel>();

        public static Mock<IUserDemandService> GetMockService()
        {
            GetReadOnlyBookData();
            GetReadOnlyUserData();
            GetReadOnlyUserDemandData();

            var mockService = new Mock<IUserDemandService>();

            mockService.Setup(a => a.GetUserDemands(It.IsAny<string>())).Returns<string>(userName =>
            {
                var response = new ResponseResults<UserDemandDetailViewModel> { IsSucceed = true, ViewModels = new System.Collections.Generic.List<UserDemandDetailViewModel>(), Message = AppMessages.RETRIEVED_DETAILS_SUCCESSFULLY };

                if (!string.IsNullOrWhiteSpace(userName))
                {
                    var user = userDataCollection.FirstOrDefault(o=>o.UserName == userName);
                    var models = userDemandDataCollection.Where(o=>o.UserId ==user.Id).ToList();
                    if (models != null && models.Count > 0)
                    {
                        var bookIds = models.Select(o => o.BookId).ToList();
                        var bookLookUp = bookDataCollection.Where(o => bookIds.Contains(o.Id)).ToDictionary(o => o.Id, o => o.Title);
                        response.ViewModels = models.Select(o => new UserDemandDetailViewModel
                        {
                            BookId = o.BookId,
                            IssuedDate = o.IssuedDate,
                            ReturnedDate = o.ReturnedDate,
                            Remark = o.Remark,
                            UpdatedOn = o.UpdatedOn,
                            UserId = o.UserId,
                            RequestStatus = (o.RequestStatus) ? "Approved" : "Pending",
                            BookTitle = bookLookUp[o.BookId]
                        }).ToList();
                    }
                }

                if (response.ViewModels.Count <= 0)
                {
                    response.Message = AppMessages.NO_RECORD_FOUND;
                }
                return response;
            });

            mockService.Setup(a => a.DemandBook(It.IsAny<string>(), It.IsAny<string>())).Returns<string, string>((bookId,userName )=>
            {
                var response = new BaseResponseResult { IsSucceed = true, Message = AppMessages.RETRIEVED_DETAILS_SUCCESSFULLY };

                if (!string.IsNullOrWhiteSpace(userName))
                {
                    var user = userDataCollection.FirstOrDefault(o => o.UserName == userName);
                    var entityModel = new UserDemandEntityModel
                    {
                        BookId = ObjectId.Parse(bookId),
                        UserId = user.Id,
                        RequestStatus = false,
                        UpdatedBy = user.Id,
                        UpdatedOn = DateTime.Now
                    };
                    userDemandDataCollection.Add(entityModel);
                }
                else
                {
                    response.IsSucceed = false;
                    response.Message = AppMessages.INVALID_INPUT;
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

        public static List<BookEntityModel> GetBookDataCollection()
        {
            return bookDataCollection;
        }

        public static List<UserEntityModel> GetUserDataCollection()
        {
            return userDataCollection;
        }

        public static List<UserDemandEntityModel> GetUserDemandDataCollection()
        {
            return userDemandDataCollection;
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
