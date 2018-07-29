using CrossOver.EntityModels.SearchBook;
using CrossOver.IRepositories.SearchBook;
using CrossOver.Utility.ParamViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CrossOver.Tests.Common.MockRepositories
{
    public class BookRepositoryGenerator
    {
        private static List<BookEntityModel> dataCollection = new List<BookEntityModel>();

        public static Mock<IBookRepository> GetMockRepository()
        {
            GetReadOnlyData();
            var mockRepository = new Mock<IBookRepository>();

            mockRepository.Setup(a => a.GetBooks(It.IsAny<SearchBookViewModel>())).Returns<SearchBookViewModel>(searchParam =>
            {
                var query = dataCollection.AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchParam.Title))
                {
                    query = query.Where(o => o.Title.ToLower().Trim().Contains(searchParam.Title.ToLower().Trim()));
                }

                if (!string.IsNullOrWhiteSpace(searchParam.Author))
                {
                    query = query.Where(o => o.Authors.Contains(searchParam.Author.Trim()));
                }

                return query.ToList();
            });

            mockRepository.Setup(a => a.PageAll(It.IsAny<int>(), It.IsAny<int>())).Returns<int,int>((skip,take) =>
            {
                return dataCollection.Skip(skip).Take(take).ToList();
            });

            mockRepository.Setup(a => a.GetMany(It.IsAny<Expression<Func<BookEntityModel, bool>>>())).Returns<Expression<Func<BookEntityModel, bool>>>(predicate =>
            {
                return dataCollection.AsQueryable().Where(predicate).ToList();
            });

            return mockRepository;
        }

        public static void ResetDataCollection(List<BookEntityModel> rows = null)
        {
            if (rows == null && MockDB.Collections.Books.Count == 0)
            {
                GetReadOnlyData();
            }

            rows = rows ?? MockDB.Collections.Books;
            EmptyDataCollection();
            dataCollection.AddRange(Helper.DeepClone<List<BookEntityModel>>(rows));
        }

        public static void EmptyDataCollection()
        {
            dataCollection = new List<BookEntityModel>();
        }

        public static List<BookEntityModel> GetDataCollection()
        {
            return dataCollection;
        }

        public static void GetReadOnlyData()
        {
            if (MockDB.Collections.Books.Count == 0)
            {
                Helper.LoadMockData<BookEntityModel>();
            }
            ResetDataCollection();
        }
    }
}
