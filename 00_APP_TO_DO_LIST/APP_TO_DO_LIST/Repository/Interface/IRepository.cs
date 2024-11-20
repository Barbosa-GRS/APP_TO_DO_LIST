using APP_TO_DO_LIST.Model;

namespace APP_TO_DO_LIST.Repository.Interface
{
    public interface IRepository
    {
        ToDoList Create(ToDoList toDoList);
        ToDoList Update(ToDoList toDoList);
        List<ToDoList> FindAll();
        void Delete(long id);
        bool Exist (long id);

    }
}
