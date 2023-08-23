using System.Data;
using System.Data.SqlClient;
using TaskBoardAPI.Data_Access;

namespace TaskBoardAPI.Data_Repository
{
    public interface ITaskBoardRepository
    {
        List<TaskBoardModel> GetTaskBoard();
        TaskBoardModel GetSingleTaskBoard(int id);

        string SaveTaskBoard(TaskBoardModel taskBoardModel);

        string UpdateTaskBoard(int id, TaskBoardModel taskBoardModel);

        string DeleteTaskBoard(int id);








    }


    public class TaskBoardRepository : ITaskBoardRepository

    {
        SqlConnection conn = new SqlConnection("Server= DESKTOP-JBLNH81\\SQLEXPRESS;Database=ApiDb2;Trusted_Connection=True;MultipleActiveResultSets=true");// ConfigurationManager.ConnectionStrings["taskapi_conn"].ConnectionString);
        TaskBoardModel taskBoardModel = new TaskBoardModel();

        public List<TaskBoardModel> GetTaskBoard() { 
        

            List<TaskBoardModel> firsttask = new List<TaskBoardModel>();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GetAllTaskBoard", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);


                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TaskBoardModel tsk = new TaskBoardModel();
                        tsk.TaskBoard_Id = Convert.ToInt32(dt.Rows[i]["TaskBoard_Id"]);
                        tsk.TaskBoard_Name = dt.Rows[i]["TaskBoard_Name"].ToString();
                        tsk.TaskBoard_Description = dt.Rows[i]["TaskBoard_Description"].ToString();

                        firsttask.Add(tsk);



                    }
                    if (firsttask.Count > 0)
                    {
                        return firsttask;
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {

                conn.Close();

            }
            return firsttask;


        }
        public TaskBoardModel GetSingleTaskBoard(int id)
        {
            TaskBoardModel tsk = new TaskBoardModel();

            SqlDataAdapter da = new SqlDataAdapter("TaskBoardById", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@TaskBoard_Id", id);
            DataTable dt = new DataTable();
            da.Fill(dt);


            if (dt.Rows.Count > 0)
            {


                tsk.TaskBoard_Name = dt.Rows[0]["TaskBoard_Name"].ToString();
                tsk.TaskBoard_Id = Convert.ToInt32(dt.Rows[0]["TaskBoard_Id"]);
                tsk.TaskBoard_Description = dt.Rows[0]["TaskBoard_Description"].ToString();





            }
            if (tsk != null)
            {
                return tsk;
            }
            else
            {
                return null;
            }


            return tsk;
        }
        public string SaveTaskBoard(TaskBoardModel taskBoardModel)
        {
            string msg = "";
            try
            {
                if (taskBoardModel != null)
                {
                    SqlCommand cmd = new SqlCommand("AddTaskBoard", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TaskBoard_Name", taskBoardModel.TaskBoard_Name);
                    cmd.Parameters.AddWithValue("@TaskBoard_Description", taskBoardModel.TaskBoard_Description);
                    //     cmd.Parameters.AddWithValue("@TaskBoard_DeadLine", taskBoard.TaskBoard_DeadLine);
                    //   cmd.Parameters.AddWithValue("@TaskBoard_Status", taskBoard.TaskBoard_Status);

                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    //conn.Close();

                    if (i > 0)
                    {
                        msg = "taskboard has been added";
                    }
                    else
                    {
                        msg = "error";
                    }
                }
            }
            catch (Exception ex)
            { }
            finally
            {

                conn.Close();

            }
            return msg;





        }
        public string UpdateTaskBoard(int id, TaskBoardModel taskboardModel)
        {
            string msg = "";
            try
            {

                if (taskboardModel != null)
                {
                    SqlCommand cmd = new SqlCommand("UpdateTaskBoard", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TaskBoard_Id", id);
                    cmd.Parameters.AddWithValue("@TaskBoard_Name", taskboardModel.TaskBoard_Name);
                    cmd.Parameters.AddWithValue("@TaskBoard_Description", taskboardModel.TaskBoard_Description);


                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (i > 0)
                    {
                        msg = "TaskBoard has been updated";
                    }
                    else
                    {
                        msg = "error";
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return msg;
        }

        public string DeleteTaskBoard(int id)
        {
            string msg = "";

            SqlCommand cmd = new SqlCommand("DeleteTaskBoard", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TaskBoard_Id", id);


            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();

            if (i > 0)
            {
                msg = "Taskboard has been deleted";
            }
            else
            {
                msg = "error";
            }
            return msg;

        }


    }
}
