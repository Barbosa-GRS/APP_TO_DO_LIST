using Microsoft.EntityFrameworkCore;  // for use DbContext

namespace APP_TO_DO_LIST.Model.Context
{
    public class MySQLContext : DbContext  //interacts with the database
    {
        public MySQLContext() { }  // constructor to create instance of MySQLContext

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }  //

        public DbSet<ToDoList> ToDoLists { get; set; }  // represent a table in dataset and allows CRUD in class ToDoList
    }
}

