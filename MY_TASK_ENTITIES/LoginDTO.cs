using System.ComponentModel.DataAnnotations;

namespace MY_TASK_DTO
{
    public class LoginDTO
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Password { get; set; }
    }
}