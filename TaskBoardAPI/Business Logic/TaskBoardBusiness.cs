using Microsoft.AspNetCore.Mvc;
using TaskBoardAPI.Data_Access;
using TaskBoardAPI.Data_Repository;

namespace TaskBoardAPI.Business_Logic
{
 
    
    public class TaskBoardBusiness 
    { 
    
        TaskBoardModel taskBoardModel = new TaskBoardModel();
        TaskBoardRepository taskBoardRepository = new TaskBoardRepository();
         TaskBoardRepository @object;
         ITaskBoardRepository object1;

        public TaskBoardBusiness(TaskBoardRepository @object)
        {
            this.@object = @object;
        }

        public TaskBoardBusiness(ITaskBoardRepository object1)
        {
            this.object1 = object1;
        }

        public TaskBoardBusiness()
        {
        }

        public List<TaskBoardModel> GetTaskBoard()
        {
            return taskBoardRepository.GetTaskBoard();

        }
         
        public TaskBoardModel GetSingleTaskBoard(int id)
        {
            return taskBoardRepository.GetSingleTaskBoard(id);

        }
         
        public string SaveTaskBoard(TaskBoardModel taskBoardModel)
        {
            return taskBoardRepository.SaveTaskBoard(taskBoardModel);

        }
         
        public string UpdateTaskBoard(int id, TaskBoardModel taskBoardModel)
        {
            return taskBoardRepository.UpdateTaskBoard(id, taskBoardModel);

        }
        public string DeleteTaskBoard(int id)
        {
            return taskBoardRepository.DeleteTaskBoard(id);
        }

        internal List<TaskBoardTasksModel> GetTaskFromTaskBoard()
        {
            throw new NotImplementedException();
        }
    }
}
