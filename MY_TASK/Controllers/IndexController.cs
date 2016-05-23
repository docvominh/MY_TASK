using MY_TASK_BUSINESS_SERVICES;
using System.Web.Http;

namespace MY_TASK.Controllers
{
    public class IndexController : ApiController
    {
        /// <summary>
        /// Initialize screen, as far as now, no one call this services
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Initialize([FromUri]string userId)
        {
            HomeServices services = new HomeServices();
            return Ok(services.IndexInitialize(userId));
        }
    }
}