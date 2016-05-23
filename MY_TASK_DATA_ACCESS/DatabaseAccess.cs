//When it comes to returning data back to the consumer from Web Api (or any other web service for that matter),
//I highly recommend not passing back entities that come from a database. It is much more reliable and maintainable
//to use Models in which you have control of what the data looks like and not the database. That way you don't have to
//mess around with the formatters so much in the WebApiConfig. You can just create a UserModel that has child Models as
//properties and get rid of the reference loops in the return objects. That makes the serializer much happier.

//Also, it isn't necessary to remove formatters or supported media types typically if you are just specifying the
//"Accepts" header in the request. Playing around with that stuff can sometimes make things more confusing.

//Example:

//public class UserModel {
//    public string Name {get;set;}
//    public string Age {get;set;}
//    // Other properties here that do not reference another UserModel class.
//}

using MY_TASK_DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MY_TASK_DATA_ACCESS
{
    public class DatabaseAccess
    {
        private DB_SMART_DEVEntities dbConnect = new DB_SMART_DEVEntities();

        public UserInfoDTO GetUserLogin(LoginDTO loginModel)
        {
            UserInfoDTO user = null;

            T_USER userFromDb = new T_USER();

            userFromDb = this.dbConnect.T_USER.Where(x => x.USER_ID.Equals(loginModel.UserId)
                && x.USER_PASSWORD.Equals(loginModel.Password)).FirstOrDefault();

            if (userFromDb != null)
            {
                user = new UserInfoDTO()
                {
                    UserId = userFromDb.USER_ID,
                    UserName = userFromDb.USER_NAME,
                    UserPassword = userFromDb.USER_PASSWORD,
                    UserLevel = userFromDb.USER_LEVEL,
                    UserRole = userFromDb.USER_ROLE,
                    BlockFlag = userFromDb.BLOCK_FLAG,
                    DeleteFlag = userFromDb.DELETE_FLAG,
                };
            }

            return user;
        }

        public IEnumerable<TaskDTO> GetAllTaskByBoss(string bossId)
        {
            ICollection<TaskDTO> list = new List<TaskDTO>();
            IEnumerable<T_TASK> listFromDb = new List<T_TASK>();
            listFromDb = this.dbConnect.T_TASK.Where(x => x.CREATE_USER_ID == bossId).ToList();

            foreach (T_TASK t in listFromDb)
            {
                TaskDTO task = new TaskDTO()
                {
                    TaskID = t.TASK_ID,
                    TaskName = t.TASK_NAME,
                    TaskLevel = t.TASK_LEVEL,
                    TaskContent = t.TASK_CONTENT,
                    TaskReworkMoney = t.TASK_REWARD_MONEY,
                    TaskRewordOther = t.TASK_REWARD_OTHER,
                    ViewCount = t.VIEW_COUNT,
                    TaskStatus = t.TASK_STATUS,
                    TimeToFinish = t.TIME_TO_FINISH,
                    CreateDate = t.CREATE_DATE,
                    CreateUserID = t.CREATE_USER_ID,
                    CreateUserName = t.CREATE_USER_NAME,
                    OwnUserID = t.OWN_USER_ID,
                    OwnUserName = t.OWN_USER_NAME,
                    DeleteFlag = t.DELETE_FLAG,
                    ShowOtherReward = (t.TASK_REWARD_OTHER != null ? true : false),
                    ShowGetButton = ((t.TASK_STATUS == 1 || t.TASK_STATUS == 3) ? true : false),
                    ShowOwnUser = (t.TASK_STATUS == 2 ? true : false),
                    ShowOwnUserResolve = (t.TASK_STATUS == 4 ? true : false),
                    ShowOwnUserDone = (t.TASK_STATUS == 6 ? true : false),
                    TaskStatusName = (t.TASK_STATUS == 1 ? "Free"
                    : t.TASK_STATUS == 2 ? "Assigned"
                    : t.TASK_STATUS == 3 ? "Return"
                    : t.TASK_STATUS == 4 ? "Resolve"
                    : t.TASK_STATUS == 5 ? "Reopen"
                    : "Done"
                    )
                };
                list.Add(task);
            }

            return list;
        }

        public IEnumerable<TaskDTO> GetAllTaskByDate(DateTime date)
        {
            ICollection<TaskDTO> list = new List<TaskDTO>();
            IEnumerable<T_TASK> listFromDb = new List<T_TASK>();
            listFromDb = this.dbConnect.T_TASK.Where(x => x.CREATE_DATE == date).ToList();

            foreach (T_TASK t in listFromDb)
            {
                TaskDTO task = new TaskDTO()
                {
                    TaskID = t.TASK_ID,
                    TaskName = t.TASK_NAME,
                    TaskLevel = t.TASK_LEVEL,
                    TaskContent = t.TASK_CONTENT,
                    TaskReworkMoney = t.TASK_REWARD_MONEY,
                    TaskRewordOther = t.TASK_REWARD_OTHER,
                    ViewCount = t.VIEW_COUNT,
                    TaskStatus = t.TASK_STATUS,
                    TimeToFinish = t.TIME_TO_FINISH,
                    CreateDate = t.CREATE_DATE,
                    CreateUserID = t.CREATE_USER_ID,
                    CreateUserName = t.CREATE_USER_NAME,
                    OwnUserID = t.OWN_USER_ID,
                    OwnUserName = t.OWN_USER_NAME,
                    DeleteFlag = t.DELETE_FLAG,
                    ShowOtherReward = (t.TASK_REWARD_OTHER != null ? true : false),
                    ShowGetButton = ((t.TASK_STATUS == 1 || t.TASK_STATUS == 3) ? true : false),
                    ShowOwnUser = (t.TASK_STATUS == 2 ? true : false),
                    ShowOwnUserResolve = (t.TASK_STATUS == 4 ? true : false),
                    ShowOwnUserDone = (t.TASK_STATUS == 6 ? true : false),
                    TaskStatusName = (t.TASK_STATUS == 1 ? "Free"
                    : t.TASK_STATUS == 2 ? "Assigned"
                    : t.TASK_STATUS == 3 ? "Return"
                    : t.TASK_STATUS == 4 ? "Resolve"
                    : t.TASK_STATUS == 5 ? "Reopen"
                    : "Done"
                    )
                };
                list.Add(task);
            }

            return list;
        }

        public IEnumerable<TaskDTO> GetTaskByUser(string userId)
        {
            ICollection<TaskDTO> list = new List<TaskDTO>();

            var listFromDb = (from T in this.dbConnect.T_TASK
                              join UT in this.dbConnect.T_USER_TASK on T.TASK_ID equals UT.TASK_ID
                              join U in this.dbConnect.T_USER on UT.USER_TAKE_ID equals U.USER_ID
                              where UT.USER_TAKE_ID.Equals(userId)
                              select new
                              {
                                  TaskID = T.TASK_ID,
                                  TaskName = T.TASK_NAME,
                                  TaskLevel = T.TASK_LEVEL,
                                  TaskContent = T.TASK_CONTENT,
                                  TaskReworkMoney = T.TASK_REWARD_MONEY,
                                  TaskRewordOther = T.TASK_REWARD_OTHER,
                                  ViewCount = T.VIEW_COUNT,
                                  TaskStatus = T.TASK_STATUS,
                                  TimeToFinish = T.TIME_TO_FINISH,
                                  CreateDate = T.CREATE_DATE,
                                  CreateUserID = T.CREATE_USER_ID,
                                  OwnUserID = T.OWN_USER_ID,
                                  OwnUserName = T.OWN_USER_NAME,
                                  CreateUserName = T.CREATE_USER_NAME,
                                  DeleteFlag = T.DELETE_FLAG
                              });

            foreach (var t in listFromDb)
            {
                TaskDTO task = new TaskDTO()
                {
                    TaskID = t.TaskID,
                    TaskName = t.TaskName,
                    TaskLevel = t.TaskLevel,
                    TaskContent = t.TaskContent,
                    TaskReworkMoney = t.TaskReworkMoney,
                    TaskRewordOther = t.TaskRewordOther,
                    ViewCount = t.ViewCount,
                    TaskStatus = t.TaskStatus,
                    TimeToFinish = t.TimeToFinish,
                    CreateDate = t.CreateDate,
                    CreateUserID = t.CreateUserID,
                    CreateUserName = t.CreateUserName,
                    OwnUserID = t.OwnUserID,
                    OwnUserName = t.OwnUserName,
                    DeleteFlag = t.DeleteFlag,
                    TaskStatusName = (t.TaskStatus == 1 ? "Free"
                   : t.TaskStatus == 2 ? "Assigned"
                   : t.TaskStatus == 3 ? "Return"
                   : t.TaskStatus == 4 ? "Resolve"
                   : t.TaskStatus == 5 ? "Reopen"
                   : "Done"
                   )
                };
                list.Add(task);
            }

            return list;
        }

        public IEnumerable<TaskDTO> SearchTask(SearchConditionDTO condition)
        {
            ICollection<TaskDTO> list = new List<TaskDTO>();

            IEnumerable<T_TASK> listFromDb = new List<T_TASK>();

            List<T_TASK> finalList = new List<T_TASK>();

            bool hasCondition = false;

            // Date condition
            listFromDb = this.dbConnect.T_TASK.Where(x =>
                   (condition.TaskDate != DateTime.MinValue
                    && ((x.CREATE_DATE.Day == condition.TaskDate.Day)
                        && (x.CREATE_DATE.Month == condition.TaskDate.Month)
                        && (x.CREATE_DATE.Year == condition.TaskDate.Year))
                   )).ToList();

            if (condition.Easy || condition.Normal || condition.Hard || condition.HardAsHell
                || condition.Free || condition.Assigned || condition.Return || condition.Resolved || condition.Reopen || condition.Done)
            {
                hasCondition = true;
                // Task level condition
                if (condition.Easy)
                {
                    finalList.AddRange(listFromDb.Where(x => x.TASK_LEVEL <= 5));
                }

                if (condition.Normal)
                {
                    finalList.AddRange(listFromDb.Where(x => x.TASK_LEVEL > 5 && x.TASK_LEVEL <= 10));
                }

                if (condition.Hard)
                {
                    finalList.AddRange(listFromDb.Where(x => x.TASK_LEVEL > 10 && x.TASK_LEVEL <= 20));
                }

                if (condition.HardAsHell)
                {
                    finalList.AddRange(listFromDb.Where(x => x.TASK_LEVEL > 20));
                }

                // Status condition
                if (condition.Free)
                {
                    finalList.AddRange(listFromDb.Where(x => x.TASK_STATUS == 1));
                }
                if (condition.Assigned)
                {
                    finalList.AddRange(listFromDb.Where(x => x.TASK_STATUS == 2));
                }
                if (condition.Return)
                {
                    finalList.AddRange(listFromDb.Where(x => x.TASK_STATUS == 3));
                }
                if (condition.Resolved)
                {
                    finalList.AddRange(listFromDb.Where(x => x.TASK_STATUS == 4));
                }
                if (condition.Reopen)
                {
                    finalList.AddRange(listFromDb.Where(x => x.TASK_STATUS == 5));
                }
                if (condition.Done)
                {
                    finalList.AddRange(listFromDb.Where(x => x.TASK_STATUS == 6));
                }
            }

            finalList.ToList();

            // If no level and status condition choise, return all task of that day
            if (!hasCondition)
            {
                finalList = (List<T_TASK>)listFromDb;
            }

            finalList = finalList.OrderBy(x => x.TASK_ID).ToList();

            // Remove duplicate element
            List<T_TASK> itemToRemove = new List<T_TASK>();
            int tempId = 0;
            foreach (T_TASK t in finalList)
            {
                if (t.TASK_ID == tempId)
                {
                    itemToRemove.Add(t);
                }
                else
                {
                    tempId = t.TASK_ID;
                }
            }

            foreach (T_TASK t in itemToRemove)
            {
                finalList.Remove(t);
            }

            // Convert entity to dto
            foreach (T_TASK t in finalList)
            {
                TaskDTO task = new TaskDTO()
                {
                    TaskID = t.TASK_ID,
                    TaskName = t.TASK_NAME,
                    TaskLevel = t.TASK_LEVEL,
                    TaskContent = t.TASK_CONTENT,
                    TaskReworkMoney = t.TASK_REWARD_MONEY,
                    TaskRewordOther = t.TASK_REWARD_OTHER,
                    ViewCount = t.VIEW_COUNT,
                    TaskStatus = t.TASK_STATUS,
                    TimeToFinish = t.TIME_TO_FINISH,
                    CreateDate = t.CREATE_DATE,
                    CreateUserID = t.CREATE_USER_ID,
                    CreateUserName = t.CREATE_USER_NAME,
                    OwnUserID = t.OWN_USER_ID,
                    OwnUserName = t.OWN_USER_NAME,
                    DeleteFlag = t.DELETE_FLAG,
                    ShowOtherReward = (t.TASK_REWARD_OTHER != null ? true : false),
                    ShowGetButton = ((t.TASK_STATUS == 1 || t.TASK_STATUS == 3) ? true : false),
                    ShowOwnUser = (t.TASK_STATUS == 2 ? true : false),
                    ShowOwnUserResolve = (t.TASK_STATUS == 4 ? true : false),
                    ShowOwnUserDone = (t.TASK_STATUS == 6 ? true : false),
                    TaskStatusName = (t.TASK_STATUS == 1 ? "Free"
                   : t.TASK_STATUS == 2 ? "Assigned"
                   : t.TASK_STATUS == 3 ? "Return"
                   : t.TASK_STATUS == 4 ? "Resolve"
                   : t.TASK_STATUS == 5 ? "Reopen"
                   : "Done"
                   )
                };

                list.Add(task);
            }

            // Sorting

            if (condition.SortItem != 0)
            {
                switch (condition.SortItem)
                {
                    case 1:
                        if (condition.SortDirection == 0)
                        {
                            list = list.OrderBy(x => x.TaskReworkMoney).ToList();
                        }

                        if (condition.SortDirection == 1)
                        {
                            list = list.OrderByDescending(x => x.TaskReworkMoney).ToList();
                        }
                        break;

                    case 2:
                        if (condition.SortDirection == 0)
                        {
                            list = list.OrderBy(x => x.TimeToFinish).ToList();
                        }

                        if (condition.SortDirection == 1)
                        {
                            list = list.OrderByDescending(x => x.TimeToFinish).ToList();
                        }
                        break;

                    case 3:
                        if (condition.SortDirection == 0)
                        {
                            list = list.OrderBy(x => x.TaskLevel).ToList();
                        }

                        if (condition.SortDirection == 1)
                        {
                            list = list.OrderByDescending(x => x.TaskLevel).ToList();
                        }
                        break;

                    default: break;
                }
            }

            return list;
        }

        public void InsertNewUserTask(string userId, int taskId, ref DateTime userChoiseDate)
        {
            // Update task status
            T_USER user = dbConnect.T_USER.Find(userId);
            T_TASK task = dbConnect.T_TASK.Find(taskId);

            // Assigned
            task.TASK_STATUS = 2;
            task.OWN_USER_ID = user.USER_ID;
            task.OWN_USER_NAME = user.USER_NAME;
            dbConnect.SaveChanges();

            userChoiseDate = task.CREATE_DATE;

            // Insert new record to T_USER_TASK
            T_USER_TASK userTask = new T_USER_TASK()
            {
                USER_TAKE_ID = user.USER_ID,
                TASK_ID = taskId,
                TASK_STATUS = 2,
                CREATE_USER_NAME = task.CREATE_USER_ID,
                CREATE_DATE = DateTime.Now,
                DELETE_FLAG = false
            };

            dbConnect.T_USER_TASK.Add(userTask);
            dbConnect.SaveChanges();
        }

        public void DeleteUserTask(string userId, int taskId, ref DateTime userChoiseDate)
        {
            // Update task status
            T_USER user = dbConnect.T_USER.Find(userId);
            T_TASK task = dbConnect.T_TASK.Find(taskId);

            // Return
            task.TASK_STATUS = 3;
            dbConnect.SaveChanges();

            userChoiseDate = task.CREATE_DATE;

            // Delete record from T_USER_TASK
            T_USER_TASK userTask = dbConnect.T_USER_TASK.Where(x => x.TASK_ID == taskId && x.USER_TAKE_ID == userId).FirstOrDefault();

            dbConnect.T_USER_TASK.Remove(userTask);
            dbConnect.SaveChanges();
        }

        public void UpdateWhenResolve(string userId, int taskId, ref DateTime userChoiseDate)
        {
            // Update task status from T_TASK
            T_USER user = dbConnect.T_USER.Find(userId);
            T_TASK task = dbConnect.T_TASK.Find(taskId);

            // Resolve
            task.TASK_STATUS = 4;
            dbConnect.SaveChanges();

            userChoiseDate = task.CREATE_DATE;

            // Update task status from T_USER_TASK
            T_USER_TASK userTask = dbConnect.T_USER_TASK.Where(x => x.TASK_ID == taskId && x.USER_TAKE_ID == userId).FirstOrDefault();

            userTask.TASK_STATUS = 4;
            dbConnect.SaveChanges();
        }

        public void NewTask(TaskDTO item)
        {
            T_TASK task = new T_TASK()
            {
                TASK_NAME = item.TaskName,
                TASK_LEVEL = item.TaskLevel,
                TASK_CONTENT = item.TaskContent,
                TASK_REWARD_MONEY = item.TaskReworkMoney,
                TASK_REWARD_OTHER = item.TaskRewordOther,
                VIEW_COUNT = 0,
                TASK_STATUS = 1,
                TIME_TO_FINISH = item.TimeToFinish,
                CREATE_DATE = DateTime.Now,
                CREATE_USER_ID = item.CreateUserID,
                CREATE_USER_NAME = item.CreateUserName,
                DELETE_FLAG = false
            };

            dbConnect.T_TASK.Add(task);
            dbConnect.SaveChanges();
        }
    }
}