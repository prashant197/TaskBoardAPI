using TaskBoardAPI.Data_Repository;

namespace TestTaskBoardAPI
{
    internal class Mock<T>
    {
        public Mock()
        {
        }

        public TaskBoardRepository Object { get; internal set; }

        internal object Setup(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}