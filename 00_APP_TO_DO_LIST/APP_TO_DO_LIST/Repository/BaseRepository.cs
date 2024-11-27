using APP_TO_DO_LIST.Model;
using APP_TO_DO_LIST.Model.Context;
using APP_TO_DO_LIST.Repository.Interface;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;


namespace APP_TO_DO_LIST.Repository
{
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
        public ToDoList Update(ToDoList toDoList)
        {
            // check if exist task id, if it doesn't exist creat a new task
            if (!Exist(toDoList.Id)) return new ToDoList();

            //check which task has the same id and save it in result
            var result = _context.ToDoLists.FirstOrDefault(p => p.Id.Equals(toDoList.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(toDoList); // get result and put the currente values im toDoList
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return toDoList;
        }

        // responsible for delete task
        public void Delete(long id)
        {
            var result = _context.ToDoLists.FirstOrDefault(p => p.Id.Equals(id));
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
            return _context.ToDoLists.Any(e => e.Id.Equals(id));
        }

        public void DeleteCompleteToDoList()
        {
            var result = _context.ToDoLists
                .Where(p => p.Status == ToDoListStatus.Completed)  // filter task completed
                .ToList();  //  save to a list
            if (result != null)
            {
                try
                {
                    foreach (var item in result)  // for each item in result run the code below
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




    }
}
