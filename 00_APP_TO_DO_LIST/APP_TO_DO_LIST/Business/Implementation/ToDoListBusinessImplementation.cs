using APP_TO_DO_LIST.Model;
using APP_TO_DO_LIST.Repository.Interface;

namespace APP_TO_DO_LIST.Business.Implementation;

public class ToDoListBusinessImplementation : IToDoListBusiness
{
    private readonly IRepository<ToDoList> _repository;  // dependenc injection 
    public ToDoListBusinessImplementation(IRepository<ToDoList> repository) // constructor
    {
        _repository = repository;
    }

    public List<ToDoList> FindAll()
    {
        return _repository.FindAll();
    }

    public ToDoList FindById(long id)
    {
        return _repository.FindById(id);
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


    // antigo valor/ esse esta no banco / existingTask
    //    {
    //      "id" : "1",
    //      "name": "lavar banheiro",
    //      "description": "lavar banheiro",
    //      "status": "Pending"
    //  }

    // novo valor/ esse voce enviou para ser atualizado / toDoList
    //    {
    //      "id" : "1",
    //      "name": "lavar banheiro",
    //      "description": "lavar banheiro",
    //      "status": "InProcess"
    //  }
    public ToDoList Update(ToDoList toDoList)
    {
        //passou 1 no toDoList.Id para buscar se existe alguma tarefa com esse ID
        //retornou o antigo valor agora o antigo valor esta no existingTask
        ToDoList existingTask = _repository.FindById(toDoList.Id);  // finds the existing task and saves it in the variable
        if (existingTask == null)
        {
            throw new Exception("Task " + toDoList.Name + " does not exist in database");
        }

        if (string.IsNullOrEmpty(toDoList.Name))
        {
            throw new Exception("The name of the task cannot be empty");
        }

        ToDoList result = _repository.Update(existingTask, toDoList);

        return result;
    }

    public void Delete(long id)
    {
        ToDoList result = FindById(id);
        if (result != null)
        {
            _repository.Delete(result);
        }
    }

    public void DeleteCompleteToDoList()
    {
        List<ToDoList> listOfTasks = _repository.GetCompleteTask();
        if (listOfTasks != null)
        {
            foreach (ToDoList item in listOfTasks)  // for each item in result run the code below
            {
                _repository.Delete(item);
            }
        };
    }
}
