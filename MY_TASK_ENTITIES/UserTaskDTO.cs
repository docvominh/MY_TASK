using System;

namespace MY_TASK_DTO
{
    public class UserTaskDTO
    {
        public string UserTakeID { get; set; }

        public int TaskID { get; set; }

        public byte TaskStatus { get; set; }

        public string CreateUser { get; set; }

        public DateTime CreateDate { get; set; }

        public bool DeleteFlag { get; set; }
    }
}