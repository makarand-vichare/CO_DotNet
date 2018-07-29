using CrossOver.EntityModels.UserDemand;
using CrossOver.IRepositories.UserDemand;
using MongoDB.Bson;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CrossOver.Tests.Common.MockRepositories
{
    public class UserDemandRepositoryGenerator
    {
        private static List<UserDemandEntityModel> dataCollection = new List<UserDemandEntityModel>();

        public static Mock<IUserDemandRepository> GetMockRepository()
        {
            GetReadOnlyData();
            var mockRepository = new Mock<IUserDemandRepository>();

            mockRepository.Setup(a => a.Add(It.IsAny<UserDemandEntityModel>())).Callback<UserDemandEntityModel>(userDemandEntity =>
            {
                if(userDemandEntity.BookId != default(ObjectId) && userDemandEntity.UserId != default(ObjectId))
                {
                    dataCollection.Add(userDemandEntity);
                }
            });

            mockRepository.Setup(a => a.GetMany(It.IsAny<Expression<Func<UserDemandEntityModel,bool>>>())).Returns<Expression<Func<UserDemandEntityModel, bool>>>(predicate =>
            {
                return dataCollection.AsQueryable().Where(predicate).ToList();
            });

            mockRepository.Setup(a => a.GetUserDemands(It.IsAny<ObjectId>())).Returns<ObjectId>(userId =>
            {
                return dataCollection.Where(o => o.UserId == userId).ToList();
            });

            return mockRepository;
        }

        public static void ResetDataCollection(List<UserDemandEntityModel> rows = null)
        {
            if (rows == null && MockDB.Collections.UserDemands.Count == 0)
            {
                GetReadOnlyData();
            }

            rows = rows ?? MockDB.Collections.UserDemands;
            EmptyDataCollection();
            dataCollection.AddRange(Helper.DeepClone<List<UserDemandEntityModel>>(rows));
        }

        public static void EmptyDataCollection()
        {
            dataCollection = new List<UserDemandEntityModel>();
        }

        public static List<UserDemandEntityModel> GetDataCollection()
        {
            return dataCollection;
        }

        public static void GetReadOnlyData()
        {
            if (MockDB.Collections.UserDemands.Count == 0)
            {
                Helper.LoadMockData<UserDemandEntityModel>();
            }
            ResetDataCollection();
        }
    }
}
