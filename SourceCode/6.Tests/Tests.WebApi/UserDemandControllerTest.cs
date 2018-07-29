using CrossOver.IDomainServices.AutoMapper;
using CrossOver.Tests.Common.MockDomainServices;
using CrossOver.WebApi2.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Dynamic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Crossover.Tests.WebApi.Controller
{
    [TestClass]
    public class UserDemandControllerTests
    {
        private static UserDemandController controller;

        [ClassInitialize]
        public static void ClassInit(TestContext textContext)
        {
            controller = new UserDemandController(UserDemandServiceGenerator.GetMockService().Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            AutoMapperInit.BuildMap();

        }

        [TestInitialize]
        public void TestInit()
        {
            UserDemandServiceGenerator.ResetUserDemandDataCollection();
            UserManagerGenerator.ResetDataCollection();
        }

        [TestMethod]
        public async Task GetUserDemands_ValidUserName_Returns_Records()
        {
            // Arrange
            var userName = UserManagerGenerator.GetDataCollection()[2].UserName;
            // Act
            var response = controller.GetUserDemands(userName);
            dynamic responseContent = await response.Content.ReadAsAsync<ExpandoObject>();
            var selectedItems = responseContent.ViewModels;

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.IsTrue(selectedItems.Count>0);
        }

        [TestMethod]
        public async Task GetUserDemands_ValidUserName_Returns_NoRecords()
        {
            // Arrange
            var userName = UserManagerGenerator.GetDataCollection()[0].UserName;
            UserDemandServiceGenerator.EmptyUserDemandDataCollection();
            // Act
            var response = controller.GetUserDemands(userName);
            dynamic responseContent = await response.Content.ReadAsAsync<ExpandoObject>();
            var selectedItems = responseContent.ViewModels;

            // Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.IsTrue(selectedItems.Count == 0);
        }

    }
}
