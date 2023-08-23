namespace TaskBoardAPI.Data_Access
{
    public class TaskModel
    {
        public int Task_Id { get; set; }

        public string Task_Name { get; set; }

        public string Task_description { get; set; }

        public int Task_DeadLine { get; set; }

        public string Task_Status { get; set; }

        public int TaskBoard_Id { get; set; }
    }
}
