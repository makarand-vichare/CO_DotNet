using CrossOver.IDomainServices.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrossOver.WebApi2.Controllers
{
    [Authorize]
    public class UserDemandController : ApiController
    {
        private readonly IUserDemandService userDemandService;

        public UserDemandController(IUserDemandService userDemandService)
        {
            this.userDemandService = userDemandService;
        }

        [HttpGet]
        public HttpResponseMessage GetUserDemands(string userName)
        {
            var response = userDemandService.GetUserDemands(userName);
            return Request.CreateResponse(HttpStatusCode.OK, new { response.ViewModels, message = response.Message });
        }

    }
}
