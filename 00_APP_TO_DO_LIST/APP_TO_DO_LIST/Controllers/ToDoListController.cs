using APP_TO_DO_LIST.Business;
using APP_TO_DO_LIST.Model;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APP_TO_DO_LIST.Controllers;

[ApiVersion("1")]
[ApiController]
[Route("api/[controller]/v{version:apiVersion}")]
public class ToDoListController : ControllerBase
{

    private readonly ILogger<ToDoListController> _logger;
    private readonly IToDoListBusiness _business;

    public ToDoListController(ILogger<ToDoListController> logger, IToDoListBusiness business)
    {
        _logger = logger;
        _business = business;
    }

    [HttpGet]
    public IActionResult Get()  // for read
    {
        return Ok(_business.FindAll());
    }

    [HttpPost]
    public IActionResult Post([FromBody] ToDoList toDoList)  // for create
    {
        if (toDoList == null)
        {
            return BadRequest();
        }
        return Ok(_business.Create(toDoList));
    }

    [HttpPut]
    public IActionResult Put([FromBody] ToDoList todolist) // for update
    {
        if (todolist == null)
        {
            return BadRequest();
        }
        return Ok(_business.Update(todolist)); ;
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] long id)
    {
        _business.Delete(id);
        return NoContent();
    }
    
    [HttpDelete]
    public IActionResult DeleteCompleteToDoList()
    {
        _business.DeleteCompleteToDoList();
        return NoContent();
    }
}
