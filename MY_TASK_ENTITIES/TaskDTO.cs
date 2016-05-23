using System;

namespace MY_TASK_DTO
{
    public class TaskDTO
    {
        // Database property
        public int TaskID { get; set; }

        public string TaskName { get; set; }

        public byte TaskType { get; set; }

        public byte TaskLevel { get; set; }

        public string TaskContent { get; set; }

        public Nullable<int> TaskReworkMoney { get; set; }

        public string TaskRewordOther { get; set; }

        public int ViewCount { get; set; }

        public byte TaskStatus { get; set; }

        public Nullable<double> TimeToFinish { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreateUserID { get; set; }

        public string CreateUserName { get; set; }

        public string OwnUserID { get; set; }

        public string OwnUserName { get; set; }

        public bool DeleteFlag { get; set; }

        // Another property
        public bool ShowOtherReward { get; set; }

        public bool ShowGetButton { get; set; }

        public bool ShowOwnUser { get; set; }

        public bool ShowOwnUserResolve { get; set; }

        public bool ShowOwnUserDone { get; set; }

        public string TaskStatusName { get; set; }
    }
}