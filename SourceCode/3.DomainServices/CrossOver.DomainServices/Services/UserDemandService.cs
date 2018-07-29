using CrossOver.DomainServices.Core;
using CrossOver.EntityModels.UserDemand;
using CrossOver.IDomainServices.Services;
using CrossOver.ServiceResponse;
using CrossOver.Utility;
using CrossOver.ViewModels;
using MongoDB.Bson;
using System;
using System.Linq;

namespace CrossOver.DomainServices
{
    public class UserDemandService : BaseService<UserDemandEntityModel, UserDemandViewModel>, IUserDemandService
    {

        public  ResponseResults<UserDemandDetailViewModel> GetUserDemands(string userName)
        {
            var response = new ResponseResults<UserDemandDetailViewModel> { IsSucceed = true, ViewModels= new System.Collections.Generic.List<UserDemandDetailViewModel>(), Message = AppMessages.RETRIEVED_DETAILS_SUCCESSFULLY };
            try
            {
                if (!string.IsNullOrWhiteSpace(userName))
                {
                    var user = UnitOfWork.UserRepository.FindByUserName(userName);
                    var models = UnitOfWork.UserDemandRepository.GetUserDemands(user.Id).ToList();
                    if (models != null && models.Count > 0)
                    {
                        var bookIds = models.Select(o => o.BookId).ToList();
                        var bookLookUp = UnitOfWork.BookRepository.GetMany(o => bookIds.Contains(o.Id)).ToDictionary(o => o.Id, o => o.Title);
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
            }
            catch (Exception ex)
            {
                response.IsSucceed = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public BaseResponseResult DemandBook(string bookId, string userName)
        {
            var response = new BaseResponseResult { IsSucceed = true, Message = AppMessages.RETRIEVED_DETAILS_SUCCESSFULLY };
            try
            {
                if (!string.IsNullOrWhiteSpace(userName) && ObjectId.Parse(bookId) != default(ObjectId))
                {
                    var user = UnitOfWork.UserRepository.FindByUserName(userName);
                    var entityModel = new UserDemandEntityModel
                    {
                        BookId = ObjectId.Parse(bookId),
                        UserId = user.Id,
                        RequestStatus = false,
                        UpdatedBy = user.Id,
                        UpdatedOn = DateTime.Now
                    };
                    UnitOfWork.UserDemandRepository.Add(entityModel);
                }
                else
                {
                    response.IsSucceed = false;
                    response.Message = AppMessages.INVALID_INPUT;
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
