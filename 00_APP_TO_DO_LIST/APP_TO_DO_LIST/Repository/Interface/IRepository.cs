using APP_TO_DO_LIST.Model;
using APP_TO_DO_LIST.Model.Base;

namespace APP_TO_DO_LIST.Repository.Interface;

public interface IRepository <T> where T : BaseEntity
{
    T Create(T item);
    T Update(T oldItem, T item);
    List<T> FindAll();
    public T FindById(long id);
    void Delete(T item);
    bool Exist(long id);
    //List<ToDoList> GetCompleteTask();
}
