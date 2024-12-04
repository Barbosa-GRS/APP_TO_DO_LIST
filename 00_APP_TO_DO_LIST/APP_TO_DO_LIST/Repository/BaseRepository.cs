using APP_TO_DO_LIST.Context;
using APP_TO_DO_LIST.Model;
using APP_TO_DO_LIST.Repository.Interface;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using APP_TO_DO_LIST.Enums;


namespace APP_TO_DO_LIST.Repository;

public class BaseRepository : IRepository
{

    private MySQLContext _context;  // dataset call, 

    public BaseRepository(MySQLContext context) // constructor for injection of instance of MySQLContext ccc
    {
        _context = context;
    }

    // responsible for find all tasks
    public List<ToDoList> FindAll()
    {
        return _context.ToDoLists.ToList();
    }

    // responsible for find expecific tasks
    public ToDoList FindById(long id)
    {
        return _context.ToDoLists.FirstOrDefault(e => e.Id.Equals(id));
    }

    // responsible for create a new task
    public ToDoList Create(ToDoList toDoList)
    {
        try
        {
            _context.Add(toDoList);
            _context.SaveChanges();
        }
        catch (Exception)
        {

            throw;
        }
        return toDoList;
    }

    // responsible for update task
    public ToDoList Update(ToDoList existingTask, ToDoList toDoList)
    {
        try
        {
            _context.Entry(existingTask).CurrentValues.SetValues(toDoList); // get result and put the currente values im toDoList
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }

        return toDoList;
    }

    // responsible for delete task
    public void Delete(long id)
    {
        var result = FindById(id);
        if (result != null)
        {
            try
            {
                _context.ToDoLists.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }

    //Check if Id exist in data base
    public bool Exist(long id)
    {
        //check if exist in _context any task wwith id equals request
        return FindById(id) != null;
    }

    public void DeleteCompleteToDoList(List<ToDoList> completeTasks)
    {        
        {
            try
            {
                foreach (var item in completeTasks)  // for each item in result run the code below
                {
                    _context.ToDoLists.Remove(item);
                }
                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public List<ToDoList> GetCompleteTask()
    {
        var result = _context.ToDoLists.Where(p => p.Status == ToDoListStatus.Completed).ToList();
        return result;
    }

    
}
