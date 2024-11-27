using APP_TO_DO_LIST.Model;
using APP_TO_DO_LIST.Repository.Interface;
using static APP_TO_DO_LIST.Model.ToDoList;
using System.Linq;
using System.Collections.Generic;

namespace APP_TO_DO_LIST.Business.Implementation
{
    public class ToDoListBusinessImplementation : IToDoListBusiness
    {
        private readonly IRepository _repository;  // dependenc injection 
        public ToDoListBusinessImplementation(IRepository repository) // constructor
        {
            _repository = repository;
        }

        public List<ToDoList> FindAll()
        {
            return _repository.FindAll();
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

        public void DeleteCompleteToDoList( )
        {
           _repository.DeleteCompleteToDoList(); 
        }
    }
}
