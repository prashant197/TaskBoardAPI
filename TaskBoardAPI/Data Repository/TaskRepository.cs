using System.Data;
using System.Data.SqlClient;
using TaskBoardAPI.Data_Access;

namespace TaskBoardAPI.Data_Repository
{
    public interface ITaskRepository
    {
        List<TaskModel> GetTask();

        TaskModel GetSingleTask(int id);

        string SaveTask(TaskModel taskModel, int id);

        string UpdateTask(int id, TaskModel taskModel);

        string DeleteTask(int id);

     }




    public class TaskRepository : ITaskRepository
    {
        SqlConnection conn = new SqlConnection("Server= DESKTOP-JBLNH81\\SQLEXPRESS;Database=ApiDb2;Trusted_Connection=True;MultipleActiveResultSets=true");// (ConfigurationManager.ConnectionStrings["taskapi_conn"].ConnectionString);
        TaskModel taskModel = new TaskModel();
        public List<TaskModel> GetTask()
        {
            List<TaskModel> firsttask = new List<TaskModel>();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GetAllTask", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);


                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TaskModel tsk = new TaskModel();
                        tsk.Task_Id = Convert.ToInt32(dt.Rows[i]["Task_Id"]);
                        tsk.Task_Name = dt.Rows[i]["Task_Name"].ToString();
                        tsk.Task_description = dt.Rows[i]["Task_description"].ToString();
                        tsk.Task_DeadLine = Convert.ToInt32(dt.Rows[i]["Task_DeadLine"]);
                        tsk.Task_Status = dt.Rows[i]["Task_Status"].ToString();
                        tsk.TaskBoard_Id = Convert.ToInt32(dt.Rows[i]["TaskBoard_Id"]);

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
        public TaskModel GetSingleTask(int id)
        {

            TaskModel tsk = new TaskModel();

            SqlDataAdapter da = new SqlDataAdapter("TaskById", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Task_Id", id);
            DataTable dt = new DataTable();
            da.Fill(dt);


            if (dt.Rows.Count > 0)
            {


                tsk.Task_Name = dt.Rows[0]["Task_Name"].ToString();
                tsk.Task_Id = Convert.ToInt32(dt.Rows[0]["Task_Id"]);
                tsk.Task_description = dt.Rows[0]["Task_description"].ToString();
                tsk.Task_DeadLine = Convert.ToInt32(dt.Rows[0]["Task_DeadLine"]);
                tsk.Task_Status = dt.Rows[0]["Task_Status"].ToString();
                tsk.TaskBoard_Id = Convert.ToInt32(dt.Rows[0]["TaskBoard_Id"]);




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

        public string SaveTask(TaskModel taskModel, int id)
        {
            string msg = "";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("CheckTaskBoardID", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@TaskBoard_Id", id);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (taskModel != null)
                    {
                        SqlCommand cmd = new SqlCommand("AddTask", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Task_Name", taskModel.Task_Name);
                        cmd.Parameters.AddWithValue("@Task_description", taskModel.Task_description);
                        cmd.Parameters.AddWithValue("@Task_DeadLine", taskModel.Task_DeadLine);
                        cmd.Parameters.AddWithValue("@Task_Status", taskModel.Task_Status);
                        cmd.Parameters.AddWithValue("@TaskBoard_Id", taskModel.TaskBoard_Id);

                        conn.Open();
                        int i = cmd.ExecuteNonQuery();
                        //conn.Close();

                        if (i > 0)
                        {
                            msg = "task has been added";
                        }
                        else
                        {
                            msg = "error";
                        }
                    }
                }
                else { return "no taskboard found with this taskboard id"; }
            }
            catch (Exception ex)
            { }
            finally
            {

                conn.Close();

            }
            return msg;

        }
        public string UpdateTask(int id, TaskModel taskModel)
        {
            string msg = "";
            try
            {

                if (taskModel != null)
                {
                    SqlCommand cmd = new SqlCommand("UpdateTask", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Task_Id", id);
                    cmd.Parameters.AddWithValue("@Task_Name", taskModel.Task_Name);
                    cmd.Parameters.AddWithValue("@Task_description", taskModel.Task_description);
                    cmd.Parameters.AddWithValue("@Task_DeadLine", taskModel.Task_DeadLine);
                    cmd.Parameters.AddWithValue("@TaskBoard_id", taskModel.TaskBoard_Id);


                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (i > 0)
                    {
                        msg = "Task has been updated";
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

        //delete task from taskID
        public string DeleteTask(int id)
        {
            string msg = "";

            SqlCommand cmd = new SqlCommand("DeleteTask", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Task_Id", id);


            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();

            if (i > 0)
            {
                msg = "Task has been deleted";
            }
            else
            {
                msg = "error";
            }
            return msg;


        }
    }
}
