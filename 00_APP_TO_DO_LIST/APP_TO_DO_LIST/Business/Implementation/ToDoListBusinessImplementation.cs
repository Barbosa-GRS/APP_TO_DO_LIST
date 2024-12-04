using APP_TO_DO_LIST.Model;
using APP_TO_DO_LIST.Repository.Interface;
using static APP_TO_DO_LIST.Model.ToDoList;
using System.Linq;
using System.Collections.Generic;

namespace APP_TO_DO_LIST.Business.Implementation;

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
        if (toDoList.Status == Enums.ToDoListStatus.Completed)
        {
            throw new Exception("The user cannot create a task with completed status");
        }
        else if (string.IsNullOrEmpty(toDoList.Name))  // check with Lucas if this is usual
        {
            throw new Exception("The name of the task should not be empty"); // how to make this appear in postman
        }
                
        return _repository.Create(toDoList);

    }

    public ToDoList Update(ToDoList toDoList)
    {
        var existingTask = _repository.FindById(toDoList.Id);  // finds the existing task and saves it in the variable
        if (existingTask == null)
        {
            return new ToDoList();
        }

        var result = _repository.Update(existingTask, toDoList);

        return result;
    }

    public void Delete(long id)
    {
        _repository.Delete(id);
    }

    public void DeleteCompleteToDoList()
    {
        var result = _repository.GetCompleteTask();
        if (result != null)
        {
             _repository.DeleteCompleteToDoList(result);
        };
        
    }
}
