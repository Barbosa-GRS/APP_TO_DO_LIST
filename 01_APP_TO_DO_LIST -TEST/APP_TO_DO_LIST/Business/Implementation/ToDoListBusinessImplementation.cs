using APP_TO_DO_LIST.Model;
using APP_TO_DO_LIST.Repository;

namespace APP_TO_DO_LIST.Business.Implementation
{
    public class ToDoListBusinessImplementation : IToDoListBusiness
    {

        private readonly IRepository _repository; // repository call (instance)

        public ToDoListBusinessImplementation(IRepository repository) // constructor for injection of instance of IRepository
        {
            _repository = repository;
        }

        public List<ToDoList> FindAll()
        {
            return _repository.FindAll(); // go to the repository and run the method FindAll 

        }
        public ToDoList Create(ToDoList toDoList)
        {
           return _repository.Create(toDoList);
        }

        public ToDoList Update(ToDoList toDoList)
        {
            return _repository.Update(toDoList);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public void DeleteCompleted()
        {
            _repository.DeleteCompleted();
        }
    }
}
