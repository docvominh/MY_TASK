using MY_TASK_BUSINESS_SERVICES;
using MY_TASK_DTO;
using System.Web.Http;

namespace MY_TASK.Controllers
{
    public class ManagerController : ApiController
    {

        /// <summary>
        /// Initialize screen
        /// </summary>
        /// <param name="bossId"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Initialize([FromUri]string bossId)
        {
            TaskManagerServices services = new TaskManagerServices();
            return Ok(services.IndexInitialize(bossId));
        }

        /// <summary>
        /// Create new task
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult NewTask([FromBody]TaskDTO item)
        {
            TaskManagerServices services = new TaskManagerServices();
            return Ok(services.NewTask(item));
        }
    }
}