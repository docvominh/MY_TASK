using MY_TASK_BUSINESS_SERVICES;
using MY_TASK_DTO;
using System.Web.Http;

namespace MY_TASK.Controllers
{
    public class LoginController : ApiController
    {
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Login([FromBody]LoginDTO loginModel)
        {
            if (!ModelState.IsValid)
            {
                return Ok("W0001");
            }

            HomeServices services = new HomeServices();

            // Check user exist
            UserInfoDTO user = services.CheckLogin(loginModel);

            // Return user data
            return Ok(user);
        }
    }
}