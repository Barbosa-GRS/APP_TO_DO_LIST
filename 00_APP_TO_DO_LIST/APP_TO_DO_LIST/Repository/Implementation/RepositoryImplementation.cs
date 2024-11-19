using APP_TO_DO_LIST.Model;
using APP_TO_DO_LIST.Model.Context;

namespace APP_TO_DO_LIST.Repository.Implementation
{
    public class RepositoryImplementation : IRepository
    {

        private MySQLContext _context;  // dataset call, 

        public RepositoryImplementation(MySQLContext context) // constructor for injection of instance of MySQLContext ccc
        {
            _context = context;
        }

        // responsible for find all tasks
        public List<ToDoList> FindAll()
        {
            throw new NotImplementedException();
        }

        // responsible for create a new task
        public ToDoList Create(ToDoList toDoList)
        {
            throw new NotImplementedException();
        }

        // responsible for update task
        public ToDoList Update(ToDoList toDoList)
        {
            throw new NotImplementedException();
        }

        // responsible for delete task
        public void Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}
