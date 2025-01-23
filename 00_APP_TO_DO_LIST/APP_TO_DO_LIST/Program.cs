using APP_TO_DO_LIST.Business;
using APP_TO_DO_LIST.Business.Implementation;
using APP_TO_DO_LIST.Context;
using APP_TO_DO_LIST.Repository;
using APP_TO_DO_LIST.Repository.Interface;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Parameters for swagger
var appName = "To do List";
var appVersion = "v1";
var appDescription = $"API develop for get '{appName}'";

builder.Services.AddRouting(options => options.LowercaseUrls = true); // deixa as letras minusculas na url do swagger

// Add services to the container.

builder.Services.AddControllers();

// Adding injection Swagger, attributes and configuration for use

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(appVersion,
        new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = appName,
            Version = appVersion,
            Description = appDescription,
            Contact = new Microsoft.OpenApi.Models.OpenApiContact
            {
                Name = "Gabriel Barbosa",
                Url = new Uri("https://github.com/Barbosa-GRS")
            }
        });
});


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
builder.Services.AddScoped(typeof(IPersonRepository),typeof(PersonRepository)); // use typeof for generic form


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

// Add Swagger configuration

app.UseSwagger(); // generate json with documentation

// generate page HTML
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json",
        $"{appName} - {appVersion}");
});
// Configure swagger page
var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");
app.UseRewriter(option);


app.UseAuthorization();

app.MapControllers();

app.Run();
