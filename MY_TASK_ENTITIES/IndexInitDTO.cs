using System.Collections.Generic;

namespace MY_TASK_DTO
{
    public class IndexInitDTO
    {
        public IEnumerable<TaskDTO> ListAllTaskToday { get; set; }

        public IEnumerable<TaskDTO> ListTask { get; set; }
    }
}