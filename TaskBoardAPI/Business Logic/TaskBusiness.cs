using Microsoft.AspNetCore.Mvc;
using TaskBoardAPI.Data_Access;
using TaskBoardAPI.Data_Repository;

namespace TaskBoardAPI.Business_Logic
{
   
    public class TaskBusiness 
    {
        TaskModel taskmodel = new TaskModel();
        TaskRepository taskRepository = new TaskRepository();
        public List<TaskModel> GetTask()
        {
            return taskRepository.GetTask();
        }
        public TaskModel GetSingleTask(int id)
        {
            return taskRepository.GetSingleTask(id);

        }
        public string SaveTask(TaskModel taskAccess, int id)
        {
            return taskRepository.SaveTask(taskAccess, id);

        }
        public string UpdateTask(int id, TaskModel taskAccess)
        {
            return taskRepository.UpdateTask(id, taskmodel);
        }
        public string DeleteTask(int id)
        {
            return taskRepository.DeleteTask(id);

        }
    }
}
