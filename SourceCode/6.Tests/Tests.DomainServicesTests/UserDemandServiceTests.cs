using CrossOver.DomainServices;
using CrossOver.IDomainServices.AutoMapper;
using CrossOver.Tests.Common;
using CrossOver.Tests.Common.MockRepositories;
using CrossOver.Tests.DomainServices.MockRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;

namespace Reporting.BusinessTier.Tests
{
    [TestClass]
    public class UserDemandServiceTests
    {
        private static UserDemandService domainService;

        [ClassInitialize]
        public static void ClassInit(TestContext textContext)
        {
            domainService = new UserDemandService();
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
        public void GetUserDemands_ByValidUser_Returns_Records()
        {
            //Arrange
            var userName = UserRepositoryGenerator.GetDataCollection()[2].UserName;

            //Act
            var response = domainService.GetUserDemands(userName);

            //Assert
            Assert.IsTrue(response.IsSucceed);
            Assert.IsTrue(response.ViewModels.Count>0);
        }

        [TestMethod]
        public void GetBooks_ByInvalidUser_Returns_NoRecords()
        {
            //Arrange
            var userName = "User1";

            //Act
            var response = domainService.GetUserDemands(userName);

            //Assert
            Assert.IsTrue(response.ViewModels.Count == 0);
        }

        [TestMethod]
        public void DemandBook_ValidInput_Add_Success()
        {
            //Arrange
            var exisitngCount = UserDemandRepositoryGenerator.GetDataCollection().Count;
            var bookId = BookRepositoryGenerator.GetDataCollection()[0].Id;
            var userName = UserRepositoryGenerator.GetDataCollection()[2].UserName;
            //Act
            var response = domainService.DemandBook(bookId.ToString(), userName);

            //Assert
            Assert.IsTrue(response.IsSucceed);
            Assert.IsTrue(exisitngCount + 1 == UserDemandRepositoryGenerator.GetDataCollection().Count);
        }

        [TestMethod]
        public void DemandBook_InvalidInput_Add_Failure()
        {
            //Arrange
            var exisitngCount = UserDemandRepositoryGenerator.GetDataCollection().Count;
            var bookId = new ObjectId();
            var userName = UserRepositoryGenerator.GetDataCollection()[2].UserName;
            //Act
            var response = domainService.DemandBook(bookId.ToString(), userName);

            //Assert
            Assert.IsTrue(!response.IsSucceed);
            Assert.IsTrue(exisitngCount  == UserDemandRepositoryGenerator.GetDataCollection().Count);
        }
    }
}
