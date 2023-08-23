using TaskBoardAPI.Business_Logic;
using TaskBoardAPI.Data_Access;
using TaskBoardAPI.Data_Repository;

namespace TestTaskBoardAPI
{
    public class Tests
    {
        private Mock<ITaskBoardRepository> boardRepositoryMock;
        private  Mock<ITaskRepository> taskRepositoryMock;
        private Mock<ITaskBoardTaskRepository> taskBoardtaskRepositoryMock;
        private List<TaskBoardModel> TaskBoards;
        private List<TaskModel> Tasks;
        private List<TaskBoardTasksModel> TaskBoardTasks;

        private TaskBoardRepository taskBoardRepository { get; set; } = null!;
        private TaskRepository taskRepository { get; set; } = null!;

        [SetUp]
        public void Setup()
        {
            taskBoardtaskRepositoryMock = new Mock<ITaskBoardTaskRepository>();
            taskRepositoryMock = new Mock<ITaskRepository>();
            boardRepositoryMock = new Mock<ITaskBoardRepository>();

            taskBoardRepository = new TaskBoardRepository();

            taskRepository = new TaskRepository();
            TaskBoards = new List<TaskBoardModel>();
            TaskBoardModel taskBoardModel = new() { TaskBoard_Id = 1, TaskBoard_Name = "Hp", TaskBoard_Description = "laptop company" };

            Tasks = new List<TaskModel>();
            TaskModel task = new() { Task_Id = 1, Task_Name = "coding", Task_description = "dotnet ", Task_DeadLine = 5, Task_Status = "Active", TaskBoard_Id = 1 };



            TaskBoardTasksModel TaskBoardTasksModel = new TaskBoardTasksModel();
            TaskBoardTasksModel.AllTask = new List<TaskModel>();
            TaskBoardTasksModel.AllTask.Add(new TaskModel { Task_Id = 1, Task_Name = "coding", Task_description = "dotnet ", Task_DeadLine = 5, Task_Status = "Active", TaskBoard_Id = 1 });





        }

        [Test]
        public void Test1()
        {

            //act
            var v = new Mock<ITaskBoardRepository>();
            //  object value1 = boardRepositoryMock.Setup(a => a.GetTaskBoard<List<TaskBoardModel>()).Returns(TaskBoards);
               v.Setup(a => a.GetTaskBoard()).Returns(TaskBoards);

            //taskRepositoryMock.Setup(a => a.GetTask()).Returns(Tasks);

            //arrange
            var taskboardBunsineess = new TaskBoardBusiness(boardRepositoryMock.Object);
            var taskBoardList = taskboardBunsineess.GetTaskBoard();


            //Assert
            Assert.IsTrue(taskBoardList.Count == 1);
            Assert.IsTrue(taskBoardList.All(a => a.TaskBoard_Name == "Hp"));

            /*TaskBoards = new List<TaskBoardModel>();
            TaskBoardModel taskBoardModel1 = new() { TaskBoard_Id = 1, TaskBoard_Name = "Hp", TaskBoard_Description = "laptop company" };


              Tasks = new List<TaskModel>();
              TaskModel taskModel1 = new()  { Task_Name = "coding", Task_description = "dotnet ", Task_DeadLine = 5, Task_Status = "Active", TaskBoard_Id = 2 };


         n*/





            //Act

            /* var taskboardres = taskBoardRepository.SaveTaskBoard(taskBoardModel1);
             var taskboardList = taskBoardRepository.GetTaskBoard();
             var updateTaskBoard = taskBoardRepository.UpdateTaskBoard(id, taskBoardModel1);

             var taskres = taskRepository.SaveTask(taskModel1,id);
             var taskList = taskRepository.GetTask();
            */





            //Assert
            // Test all taskboard methord
            //  Assert.IsTrue(taskboardres == "taskboard has been added");
            //Assert.IsTrue(updateTaskBoard == "TaskBoard has been updated");

            // Assert.IsTrue(taskboardList.Count == 35);




            //   Assert.IsTrue(taskList.Count == 41);





            // test all task methord

            //  Assert.IsTrue(taskres == "task has been added");

            //    ;










        }
    }
}