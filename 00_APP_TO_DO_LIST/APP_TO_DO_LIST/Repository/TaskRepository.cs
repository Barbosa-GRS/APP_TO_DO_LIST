using APP_TO_DO_LIST.Context;
using APP_TO_DO_LIST.Enums;
using APP_TO_DO_LIST.Model;
using APP_TO_DO_LIST.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace APP_TO_DO_LIST.Repository;

public class TaskRepository : BaseRepository<ToDoList>, ITaskRepository
{
    public TaskRepository(MySQLContext context)
        : base(context)
    {

    }

    public List<ToDoList> GetCompleteTask()  
    {
        var result = _context.ToDoLists.Where(p => p.Status == ToDoListStatus.Completed).ToList();
        return result;
    }

    //public async Task<ToDoList> Create(ToDoList toDoList)
    //{
    //    // Validar se a pessoa existe
    //    var personExists = _context.Persons.Any(p => p.Id == toDoList.PersonId);
    //    if (!personExists)
    //    {
    //        throw new Exception("Person does not exist.");
    //    }

    //    // Salvar a ToDoList
    //    await _context.ToDoLists.AddAsync(toDoList);
    //    await _context.SaveChangesAsync();
    //    return toDoList;
    //}
}
