using APP_TO_DO_LIST.Model;

namespace APP_TO_DO_LIST.Repository.Interface;

public interface IRepository
{
    ToDoList Create(ToDoList toDoList);
    ToDoList Update(ToDoList existingTask, ToDoList toDoList);
    List<ToDoList> FindAll();
    public ToDoList FindById(long id);
    void Delete(ToDoList item);
    bool Exist(long id);
    List<ToDoList> GetCompleteTask();
}
