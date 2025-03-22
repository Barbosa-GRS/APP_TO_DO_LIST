using APP_TO_DO_LIST.Model;
using APP_TO_DO_LIST.Model.Base;
using System.Linq.Expressions;

namespace APP_TO_DO_LIST.Repository.Interface;

public interface IRepository<T> where T : BaseEntity 
{
    T Create(T item);
    T Update(T oldItem, T item);
    List<T> FindAll(params Expression<Func<T, object>>[] includes);
    T GetById(int id, params Expression<Func<T, object>>[] includes);
    void Delete(T item);
    bool Exists(Func<T, bool> predicate);



}
