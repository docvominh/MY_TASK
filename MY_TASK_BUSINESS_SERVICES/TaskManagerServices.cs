using MY_TASK_DATA_ACCESS;
using MY_TASK_DTO;
using System.Collections.Generic;

namespace MY_TASK_BUSINESS_SERVICES
{
    public class TaskManagerServices
    {
        // Object transfer data from database
        private DatabaseAccess dbAccess = new DatabaseAccess();

        public IEnumerable<TaskDTO> IndexInitialize(string bossId)
        {
            return dbAccess.GetAllTaskByBoss(bossId);
        }

        public IEnumerable<TaskDTO> NewTask( TaskDTO item)
        {
            dbAccess.NewTask( item);

            // Return bundle of data to client
            return dbAccess.GetAllTaskByBoss(item.CreateUserID);
        }
    }
}