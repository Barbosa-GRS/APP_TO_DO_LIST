using APP_TO_DO_LIST.Model;
using APP_TO_DO_LIST.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace APP_TO_DO_LIST.Repository.Implementation
{
    public class RepositoryImplementation : IRepository
    {

        private MySQLContext _context;  // dataset call,  

        public RepositoryImplementation(MySQLContext context) // constructor for injection of instance of MySQLContext
        {
            _context = context;
        }

        // responsible for find all tasks
        public List<ToDoList> FindAll()
        {
            return _context.ToDoLists.ToList();
        }

        // responsible for create a new task  // var completed = _context.ToDoLists.Where(c => c.Status == "Completed").ToList();
        public ToDoList Create(ToDoList toDoList)
        {
            if (toDoList.Status != "Completed" && toDoList.Status != "Pending")
            {
                throw new ArgumentException("Status  should Completed or Pending");
            }
            else
            {
                try
                {
                    _context.ToDoLists.Add(toDoList);
                    _context.SaveChanges();
                    return toDoList;
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        // responsible for update task
        public ToDoList Update(ToDoList toDoList)
        {
            // check if task exist, case not retur a new task
            if (!Exists(toDoList.Id)) return new ToDoList();

            // get courrent task

            var result = _context.ToDoLists.SingleOrDefault(r => r.Id.Equals(toDoList.Id)); // SingleOrDefault take an element that meets the condition
            if (result != null)
            {
                // to do update
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(toDoList);// entry in task inside of result and ...?? take actual values and set in toDoList.
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
            var result = _context.ToDoLists.SingleOrDefault(r => r.Id.Equals(id)); // SingleOrDefault take an element that meets the condition

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

        // responsible for check if task exist in data base
        public bool Exists(long id)
        {
            return _context.ToDoLists.Any(e => e.Id.Equals(id));
        }

        // responsible for delete task was completed
        public void DeleteCompleted()
        {
            var completed = _context.ToDoLists.Where(c => c.Status == "Completed").ToList();  // there is a problem.... in database, maybe there isn't this word

            try
            {
                _context.ToDoLists.RemoveRange(completed);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
