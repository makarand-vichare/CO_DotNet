using CrossOver.IDomainServices.AutoMapper;
using CrossOver.Tests.Common.MockDomainServices;
using CrossOver.Utility.ParamViewModels;
using CrossOver.ViewModels;
using CrossOver.WebApi2.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Crossover.Tests.WebApi.Controller
{
    [TestClass]
    public class SearchBookControllerTest
    {
        private static SearchBookController controller;

        [ClassInitialize]
        public static void ClassInit(TestContext textContext)
        {
            controller = new SearchBookController(SearchBookServiceGenerator.GetMockService().Object, UserDemandServiceGenerator.GetMockService().Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            AutoMapperInit.BuildMap();

        }

        [TestInitialize]
        public void TestInit()
        {
            UserDemandServiceGenerator.ResetUserDemandDataCollection();
            SearchBookServiceGenerator.ResetBookDataCollection();
            UserManagerGenerator.ResetDataCollection();
        }

        [TestMethod]
        public async Task GetBooks_ValidSearchParam_Returns_Records()
        {
            // Arrange
            var userName = UserManagerGenerator.GetDataCollection()[0].UserName;
            var author = SearchBookServiceGenerator.GetDataCollection()[0].Authors.FirstOrDefault();

            var searchParam = new SearchBookViewModel { UserName = userName, Author = author };
            // Act
            var response = controller.Get(searchParam);
            dynamic responseContent =  await response.Content.ReadAsAsync<ExpandoObject>();
            var selectedItems = responseContent.ViewModels;

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.IsTrue(selectedItems.Count>0);
        }

        [TestMethod]
        public async Task GetBooks_InValidSearchParam_Returns_NoRecords()
        {
            // Arrange
            var userName = UserManagerGenerator.GetDataCollection()[0].UserName;
            var author = "Author1";

            var searchParam = new SearchBookViewModel { UserName = userName, Author = author };
            // Act
            var response = controller.Get(searchParam);
            dynamic responseContent = await response.Content.ReadAsAsync<ExpandoObject>();
            var selectedItems = responseContent.ViewModels;

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.IsTrue(selectedItems.Count == 0);
        }

        [TestMethod]
        public async Task GetTop10_ValidUserName_Returns_Records()
        {
            // Arrange
            var userName = UserManagerGenerator.GetDataCollection()[0].UserName;
            // Act
            var response = controller.GetTop10(userName);
            dynamic responseContent = await response.Content.ReadAsAsync<ExpandoObject>();
            var selectedItems = responseContent.ViewModels;

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.IsTrue(selectedItems.Count > 0);
        }

        [TestMethod]
        public async Task GetTop10_InValidUserName_Returns_Records()
        {
            // Arrange
            var userName = "User1";

            // Act
            var response = controller.GetTop10(userName);
            dynamic responseContent = await response.Content.ReadAsAsync<ExpandoObject>();
            var selectedItems = responseContent.ViewModels;

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.IsTrue(selectedItems.Count > 0);
        }

        [TestMethod]
        public async Task GetBooks_EmptyData_Returns_NoRecords()
        {
            // Arrange
            var userName = UserManagerGenerator.GetDataCollection()[0].UserName;
            var author = SearchBookServiceGenerator.GetDataCollection()[0].Authors.FirstOrDefault();
            var searchParam = new SearchBookViewModel { UserName = userName, Author = author };
            SearchBookServiceGenerator.EmptyBookDataCollection();

            // Act
            var response = controller.Get(searchParam);
            dynamic responseContent = await response.Content.ReadAsAsync<ExpandoObject>();
            var selectedItems = responseContent.ViewModels;

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.IsTrue(selectedItems.Count == 0);
        }

        [TestMethod]
        public async Task DemandBook_ValidInput_Add_Success()
        {
            // Arrange
            var exisitngCount = UserDemandServiceGenerator.GetUserDemandDataCollection().Count;
            var bookId = SearchBookServiceGenerator.GetDataCollection()[0].Id;
            var userName = UserManagerGenerator.GetDataCollection()[2].UserName;
            var requestModel = new DemandBookRequestModel { BookId = bookId.ToString(), UserName = userName };
            // Act
            var response = controller.Post(requestModel);
            dynamic responseContent = await response.Content.ReadAsAsync<ExpandoObject>();

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.IsTrue(exisitngCount + 1 == UserDemandServiceGenerator.GetUserDemandDataCollection().Count);
        }
    }
}
