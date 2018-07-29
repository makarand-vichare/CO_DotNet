using CrossOver.DomainServices;
using CrossOver.IDomainServices.AutoMapper;
using CrossOver.Tests.Common;
using CrossOver.Tests.Common.MockRepositories;
using CrossOver.Tests.DomainServices.MockRepositories;
using CrossOver.Utility.ParamViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Reporting.BusinessTier.Tests
{
    [TestClass]
    public class SearchBookServiceTests
    {
        private static SearchBookService domainService;

        [ClassInitialize]
        public static void ClassInit(TestContext textContext)
        {
            domainService = new SearchBookService();
            domainService.UnitOfWork = UnitOfWorkGenerator.MockUnitOfWork();
            AutoMapperInit.BuildMap();
        }

        [TestInitialize]
        public void Initialize()
        {
            BookRepositoryGenerator.ResetDataCollection();
            UserRepositoryGenerator.ResetDataCollection();
        }

        [TestMethod]
        public void GetBooks_ByValidSearchParam_Returns_Records()
        {
            //Arrange
            var userName = UserRepositoryGenerator.GetDataCollection()[0].UserName;
            var author = BookRepositoryGenerator.GetDataCollection()[0].Authors.FirstOrDefault();
            var searchParam = new SearchBookViewModel { UserName = userName, Author = author };

            //Act
            var response = domainService.GetBooks(searchParam);

            //Assert
            Assert.IsTrue(response.IsSucceed);
            Assert.IsTrue(response.ViewModels.Count>0);
        }

        [TestMethod]
        public void GetBooks_ByInvalidSearchParam_Returns_NoRecords()
        {
            //Arrange
            var userName = UserRepositoryGenerator.GetDataCollection()[0].UserName;
            var author = "Author1";
            var searchParam = new SearchBookViewModel { UserName = userName, Author = author };

            //Act
            var response = domainService.GetBooks(searchParam);

            //Assert
            Assert.IsTrue(response.ViewModels.Count == 0);
        }

        [TestMethod]
        public void GetBooks_ByInvalidSearchParam_Check_AlreadyRequested()
        {
            //Arrange
            var bookId = UserDemandRepositoryGenerator.GetDataCollection()[0].BookId;
            var userId = UserDemandRepositoryGenerator.GetDataCollection()[0].UserId;
            var userName = UserRepositoryGenerator.GetDataCollection().FirstOrDefault(o => o.Id == userId).UserName;

            var author = BookRepositoryGenerator.GetDataCollection().FirstOrDefault(o=>o.Id == bookId).Authors.FirstOrDefault();
            var searchParam = new SearchBookViewModel { UserName = userName, Author = author };

            //Act
            var response = domainService.GetBooks(searchParam);

            //Assert
            Assert.IsTrue(response.IsSucceed);
            Assert.IsTrue(response.ViewModels.FirstOrDefault(o=>o.Id == bookId).IsRequested);
        }
    }
}
