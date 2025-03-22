using APP_TO_DO_LIST.Model;

namespace APP_TO_DO_LIST.Business;

public interface IBaseBusiness<T>
{
    T Create(T item);
    T Update(T item);
    List<T> FindAll();
    public T GetById(int id);
    void Delete(int id);
}
