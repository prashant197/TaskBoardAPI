using System.Data;
using System.Data.SqlClient;
using TaskBoardAPI.Data_Access;

namespace TaskBoardAPI.Data_Repository
{
    public interface ITaskBoardTaskRepository
    {
        List<TaskBoardTasksModel> GetTaskFromTaskBoard(int id);
    }
    public class TaskBoardTaskRepository : ITaskBoardTaskRepository
    {
        SqlConnection conn = new SqlConnection("Server= DESKTOP-JBLNH81\\SQLEXPRESS;Database=ApiDb2;Trusted_Connection=True;MultipleActiveResultSets=true");// (ConfigurationManager.ConnectionStrings["taskapi_conn"].ConnectionString);
        TaskBoardTasksModel taskBoard_TaskModel = new TaskBoardTasksModel();


        //get all task using specific taskboard-Id
        public List<TaskBoardTasksModel> GetTaskFromTaskBoard(int id)
        {
            TaskModel taskModel = new TaskModel();

            TaskBoardModel tskboardModel = new TaskBoardModel();
            List<TaskModel> alltask = new List<TaskModel>();
            SqlDataAdapter da = new SqlDataAdapter("AllTaskFromTaskBoard", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@TaskBoard_Id", id);
            DataSet dataSet = new DataSet();
            da.Fill(dataSet);
            List<TaskBoardTasksModel> taskBoardTasksList = new List<TaskBoardTasksModel>();
            if (dataSet.Tables.Count > 1)
            {

                DataTable dataTableTaskBoard = dataSet.Tables[0];
                TaskBoardTasksModel taskBoardTasks;
                for (int j = 0; j < dataTableTaskBoard.Rows.Count; j++)
                {

                    TaskBoardTasksModel taskBoard_TaskAccess = new TaskBoardTasksModel();
                    taskBoard_TaskAccess.TaskBoard_Id = Convert.ToInt32(dataTableTaskBoard.Rows[j]["TaskBoard_ID"]);
                    taskBoard_TaskAccess.TaskBoard_Name = dataTableTaskBoard.Rows[j]["TaskBoard_Name"].ToString();
                    taskBoard_TaskAccess.TaskBoard_Description = dataTableTaskBoard.Rows[j]["TaskBoard_Description"].ToString();


                    DataTable dt = dataSet.Tables[1];
                    taskBoard_TaskAccess.AllTask = new List<TaskModel>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        //  tskboard.TaskBoard_Id = Convert.ToInt32(dt.Rows[i]["TaskBoard_Id"]);
                        //  tskboard.TaskBoard_Name = dt.Rows[i]["TaskBoard_Name"].ToString();
                        //  tskboard.TaskBoard_Description = dt.Rows[i]["TaskBoard_Description"].ToString();
                        taskModel = new TaskModel();
                        taskModel.Task_Id = Convert.ToInt32(dt.Rows[i]["Task_Id"]);
                        taskModel.Task_Name = dt.Rows[i]["Task_Name"].ToString();
                        taskModel.Task_description = dt.Rows[i]["Task_description"].ToString();
                        taskModel.Task_DeadLine = Convert.ToInt32(dt.Rows[i]["Task_DeadLine"]);
                        taskModel.Task_Status = dt.Rows[i]["Task_Status"].ToString();


                        taskBoard_TaskAccess.AllTask.Add(taskModel);



                    }


                    taskBoardTasksList.Add(taskBoard_TaskAccess);
                }
            }
            return taskBoardTasksList;

        }
    }
}
