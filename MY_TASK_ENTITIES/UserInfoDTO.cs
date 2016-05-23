namespace MY_TASK_DTO
{
    public class UserInfoDTO
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public short UserLevel { get; set; }

        public byte UserRole { get; set; }

        public bool BlockFlag { get; set; }

        public bool DeleteFlag { get; set; }
    }
}