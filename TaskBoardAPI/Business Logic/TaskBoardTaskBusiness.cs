using Microsoft.AspNetCore.Mvc;
using TaskBoardAPI.Data_Access;
using TaskBoardAPI.Data_Repository;

namespace TaskBoardAPI.Business_Logic
{
    
    public class TaskBoardTaskBusiness 
    {
        TaskBoardTasksModel TaskBoard_TaskModel = new TaskBoardTasksModel();
        TaskBoardTaskRepository taskBoard_TaskRepository = new TaskBoardTaskRepository();
        public List<TaskBoardTasksModel> GetAllTaskFromTaskBoard(int id)
        {
            return taskBoard_TaskRepository.GetTaskFromTaskBoard(id);

        }
    }
}
