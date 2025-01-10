using APP_TO_DO_LIST.Model;

namespace APP_TO_DO_LIST.Repository.Interface;

public interface ITaskRepository : IRepository<ToDoList>
{
    List<ToDoList> GetCompleteTask();
}
