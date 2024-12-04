using APP_TO_DO_LIST.Model;
using APP_TO_DO_LIST.Enums;
using Microsoft.EntityFrameworkCore;  // for use DbContext

namespace APP_TO_DO_LIST.Context;

public class MySQLContext : DbContext  //interacts with the database
{
    public MySQLContext() { }  // constructor to create instance of MySQLContext

    public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }  //


    public DbSet<ToDoList> ToDoLists { get; set; }  // represent a table in dataset and allows CRUD in class ToDoList

    // Testing convert the int of enum for string in database
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Chama o método da classe base (DbContext)
        base.OnModelCreating(modelBuilder);

        // Aqui você pode adicionar configurações específicas do seu modelo
        modelBuilder.Entity<ToDoList>()
            .Property(t => t.Status)
            .HasConversion(
                v => v.ToString(),   // Converte para string ao salvar
                v => (ToDoListStatus)Enum.Parse(typeof(ToDoListStatus), v)  // Converte de volta ao recuperar do banco
            );
    }


}

