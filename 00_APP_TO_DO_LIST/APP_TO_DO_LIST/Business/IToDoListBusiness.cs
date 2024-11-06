using APP_TO_DO_LIST.Model;

namespace APP_TO_DO_LIST.Business
{
    public interface IToDoListBusiness
    {
        ToDoList Create(ToDoList toDoList);
        ToDoList Update(ToDoList toDoList);
        List<ToDoList> FindAll();
        void Delete(long id);

    }
}
