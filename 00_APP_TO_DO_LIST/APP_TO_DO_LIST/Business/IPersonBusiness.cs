using APP_TO_DO_LIST.Model;
using static APP_TO_DO_LIST.Model.ToDoList;

namespace APP_TO_DO_LIST.Business;

public interface IPersonBusiness
{
    Person Create(Person person);
    Person Update(Person person);
    List<Person> FindAll();
    public Person FindById(long id);
    void Delete(long id);
  
}
