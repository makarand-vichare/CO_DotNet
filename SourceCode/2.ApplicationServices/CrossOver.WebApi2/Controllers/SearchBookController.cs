using CrossOver.IDomainServices.Services;
using CrossOver.Utility.ParamViewModels;
using CrossOver.ViewModels;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrossOver.WebApi2.Controllers
{
    [RoutePrefix("api/Books")]
    public class SearchBookController : ApiController
    {
        private readonly ISearchBookService searchBookService;
        private readonly IUserDemandService userDemandService;

        public SearchBookController(ISearchBookService searchBookService, IUserDemandService userDemandService)
        {
            this.searchBookService = searchBookService;
            this.userDemandService = userDemandService;
        }

        [Route("GetBooks")]
        [HttpGet]
        public HttpResponseMessage Get([FromUri]SearchBookViewModel searchParam)
        {
            var response = searchBookService.GetBooks(searchParam);

            return Request.CreateResponse(HttpStatusCode.OK, new { response.ViewModels, message = response.Message });
        }

        [Route("GetTop10")]
        [HttpGet]
        public HttpResponseMessage GetTop10(string userName)
        {
            var response = searchBookService.GetTop10(userName);

            return Request.CreateResponse(HttpStatusCode.OK, new { response.ViewModels, message = response.Message });
        }

        [Route("DemandBook")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]DemandBookRequestModel requestModel)
        {
            var response = userDemandService.DemandBook(requestModel.BookId, requestModel.UserName);

            return Request.CreateResponse(HttpStatusCode.OK, new { response.IsSucceed, message = response.Message });
        }
    }
}
