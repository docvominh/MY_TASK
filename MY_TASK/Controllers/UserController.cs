using MY_TASK_BUSINESS_SERVICES;
using MY_TASK_DTO;
using System.Web.Http;

namespace MY_TASK.Controllers
{
    public class UserController : ApiController
    {
        /// <summary>
        /// Initialize screen
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Initialize([FromUri]string userId)
        {
            HomeServices services = new HomeServices();
            return Ok(services.IndexInitialize(userId));
        }

        /// <summary>
        /// User get a task
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult UserGetTask([FromUri]string userId, [FromUri]int taskId)
        {
            HomeServices services = new HomeServices();
            return Ok(services.UserGetTask(userId, taskId));
        }

        /// <summary>
        /// User Return Task
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult UserReturnTask([FromUri]string userId, [FromUri]int taskId)
        {
            HomeServices services = new HomeServices();
            return Ok(services.UserReturnTask(userId, taskId));
        }

        /// <summary>
        /// User Resolve Task
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult UserResolveTask([FromUri]string userId, [FromUri]int taskId)
        {
            HomeServices services = new HomeServices();
            return Ok(services.UserResolveTask(userId, taskId));
        }

        /// <summary>
        /// Search task
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult SearchTask([FromBody]SearchConditionDTO condition)
        {
            HomeServices services = new HomeServices();
            return Ok(services.SearchTask(condition));
        }
    }
}