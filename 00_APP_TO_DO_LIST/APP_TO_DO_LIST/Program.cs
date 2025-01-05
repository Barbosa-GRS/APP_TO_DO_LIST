using APP_TO_DO_LIST.Business;
using APP_TO_DO_LIST.Business.Implementation;
using APP_TO_DO_LIST.Context;
using APP_TO_DO_LIST.Repository;
using APP_TO_DO_LIST.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Add connection with dataset


var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"]; // get string of connection
builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(
    connection, 
    new MySqlServerVersion(new Version (8,0,2))) //add o dbcontext 
);


// add versioning API

builder.Services.AddApiVersioning();

// add Dependency Injection

builder.Services.AddScoped<IToDoListBusiness,ToDoListBusinessImplementation>();
builder.Services.AddScoped<IPersonBusiness,PersonBusinessImplementation>();

builder.Services.AddScoped(typeof(IRepository<>),typeof(BaseRepository<>)); // use typeof for generic form
builder.Services.AddScoped(typeof(ITaskRepository),typeof(TaskRepository)); // use typeof for generic form


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
