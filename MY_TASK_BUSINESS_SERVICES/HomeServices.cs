using MY_TASK_DATA_ACCESS;
using MY_TASK_DTO;
using System;
using System.Collections.Generic;

namespace MY_TASK_BUSINESS_SERVICES
{
    public class HomeServices
    {
        // Object transfer data from database
        private DatabaseAccess dbAccess = new DatabaseAccess();

        public UserInfoDTO CheckLogin(LoginDTO loginModel)
        {
            // Return user from db
            return dbAccess.GetUserLogin(loginModel);
        }

        public IndexInitDTO IndexInitialize(string userId)
        {
            IndexInitDTO obj = new IndexInitDTO();
            obj.ListAllTaskToday = GetAllTaskByDate(DateTime.Today);
            obj.ListTask = GetTaskByUser(userId);

            // Return bundle of data to client
            return obj;
        }

        public IEnumerable<TaskDTO> SearchTask(SearchConditionDTO condtion)
        {
            IEnumerable<TaskDTO> listTask = new List<TaskDTO>();
            listTask = dbAccess.SearchTask(condtion);

            // Return bundle of data to client
            return listTask;
        }

        public IEnumerable<TaskDTO> GetAllTaskByDate(DateTime date)
        {
            // Return all task type from db
            return dbAccess.GetAllTaskByDate(date);
        }

        public IEnumerable<TaskDTO> GetTaskByUser(string userId)
        {
            // Return all task type from db
            return dbAccess.GetTaskByUser(userId);
        }

        public IndexInitDTO UserGetTask(string userId, int taskId)
        {
            DateTime userChoiseDate = new DateTime();
            dbAccess.InsertNewUserTask(userId, taskId, ref userChoiseDate);

            // For update screen
            IndexInitDTO obj = new IndexInitDTO();
            obj.ListTask = dbAccess.GetTaskByUser(userId);
            obj.ListAllTaskToday = GetAllTaskByDate(userChoiseDate);
            return obj;
        }

        public IndexInitDTO UserReturnTask(string userId, int taskId)
        {
            DateTime userChoiseDate = new DateTime();
            dbAccess.DeleteUserTask(userId, taskId, ref userChoiseDate);

            // For update screen
            IndexInitDTO obj = new IndexInitDTO();
            obj.ListTask = dbAccess.GetTaskByUser(userId);
            obj.ListAllTaskToday = GetAllTaskByDate(userChoiseDate);
            return obj;
        }

        public IndexInitDTO UserResolveTask(string userId, int taskId)
        {
            DateTime userChoiseDate = new DateTime();
            dbAccess.UpdateWhenResolve(userId, taskId, ref userChoiseDate);

            // For update screen
            IndexInitDTO obj = new IndexInitDTO();
            obj.ListTask = dbAccess.GetTaskByUser(userId);
            obj.ListAllTaskToday = GetAllTaskByDate(userChoiseDate);
            return obj;
        }
    }
}