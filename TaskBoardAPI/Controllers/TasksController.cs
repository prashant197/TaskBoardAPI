using Microsoft.AspNetCore.Mvc;
using TaskBoardAPI.Business_Logic;
using TaskBoardAPI.Data_Access;

namespace TaskBoardAPI.Controllers
{
    
    
    public class TasksController 
    {
        TaskBusiness taskBusiness = new TaskBusiness();
        [HttpGet]

        public List<TaskModel> GetTask()
        {
            return taskBusiness.GetTask();
        }
        [HttpGet]
        public TaskModel GetSingleTask(int id)
        {
            return taskBusiness.GetSingleTask(id);

        }

        [HttpPost]
        public string SaveTask(TaskModel taskModel, int id)
        {
            return taskBusiness.SaveTask(taskModel, id);

        }
        [HttpPut]
        public string UpdateTask(int id, TaskModel taskModel)
        {
            return taskBusiness.UpdateTask(id, taskModel);

        }
        [HttpDelete]
        public string DeleteTask(int id)
        {
            return taskBusiness.DeleteTask(id);
        }
    }
}
