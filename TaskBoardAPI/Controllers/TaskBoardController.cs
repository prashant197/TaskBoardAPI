using Microsoft.AspNetCore.Mvc;
using TaskBoardAPI.Business_Logic;
using TaskBoardAPI.Data_Access;
using TaskBoardAPI.Data_Repository;

namespace TaskBoardAPI.Controllers
{
     [ApiController]
     [Route("api/[controller]")]
    public class TaskBoardController : ControllerBase
    {
        //TaskBoardRepository taskBoardRepository = new TaskBoardRepository();
        TaskBoardBusiness taskBoardBusiness = new TaskBoardBusiness();
        

        [HttpGet]
        public List<TaskBoardModel> GetTaskBoard()
        {
            return taskBoardBusiness.GetTaskBoard();

        }
        [HttpGet("{id}")]
        public TaskBoardModel GetSingleTaskBoard(int id)
        {
            return taskBoardBusiness.GetSingleTaskBoard(id);

        }
        [HttpPost("{taskBoardModel}")]
        public string SaveTaskBoard(TaskBoardModel taskBoardModel)
        {
            return taskBoardBusiness.SaveTaskBoard(taskBoardModel);

        }
        [HttpPut("{id},{taskBoardModel}")]
        public string UpdateTaskBoard(int id, TaskBoardModel taskBoardModel)
        {
            return taskBoardBusiness.UpdateTaskBoard(id, taskBoardModel);

        }
        [HttpDelete("{id}")]
        public string DeleteTaskBoard(int id)
        {
            return taskBoardBusiness.DeleteTaskBoard(id);
        }

    }
}
