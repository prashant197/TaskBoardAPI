using Microsoft.AspNetCore.Mvc;
using TaskBoardAPI.Business_Logic;
using TaskBoardAPI.Data_Access;

namespace TaskBoardAPI.Controllers
{
    public class TaskBoardTaskControllercs:ControllerBase
    {
        TaskBoardBusiness taskBoardtaskBusiness = new TaskBoardBusiness();
        [HttpGet]
        public List<TaskBoardTasksModel> GetTaskBoardFromTask(int id)
        {
            return taskBoardtaskBusiness.GetTaskFromTaskBoard();
        }


    }
}
