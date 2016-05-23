using System;

namespace MY_TASK_DTO
{
    public class SearchConditionDTO
    {
        public DateTime TaskDate { get; set; }

        // Task sort
        public byte SortItem { get; set; }

        public byte SortDirection { get; set; }

        // Task Type
        public bool Easy { get; set; }

        public bool Normal { get; set; }

        public bool Hard { get; set; }

        public bool HardAsHell { get; set; }

        // Task Status
        public bool Free { get; set; }

        public bool Assigned { get; set; }

        public bool Return { get; set; }

        public bool Resolved { get; set; }

        public bool Reopen { get; set; }

        public bool Done { get; set; }
    }
}