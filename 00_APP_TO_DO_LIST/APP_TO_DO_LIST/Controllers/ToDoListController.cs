using APP_TO_DO_LIST.Business;
using APP_TO_DO_LIST.Model;
using APP_TO_DO_LIST.Repository.Interface;
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
    [ProducesResponseType((200), Type = typeof(List<ToDoList>))] //OK
    [ProducesResponseType(204)] //No Content
    [ProducesResponseType(400)] //Bad Request
    [ProducesResponseType(401)] //Unauthorized
    public IActionResult Get()  // for read
    {
        return Ok(_business.FindAll());
    }

    [HttpGet("{id}")]
    [ProducesResponseType((200), Type = typeof(ToDoList))]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult GetById([FromRoute] int id)
    {
        return Ok(_business.GetById(id));
    }


    [HttpPost]
    [ProducesResponseType((200), Type = typeof(ToDoList))]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult Post([FromBody] ToDoList toDoList)  // for create
    {
        if (toDoList == null)
        {
            return BadRequest();
        }
        return Ok(_business.Create(toDoList));
    }

    [HttpPut]
    [ProducesResponseType((200), Type = typeof(ToDoList))]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult Put([FromBody] ToDoList todolist) // for update
    {
        if (todolist == null)
        {
            return BadRequest();
        }
        return Ok(_business.Update(todolist)); ;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult Delete([FromRoute] int id)
    {
        _business.Delete(id);
        return NoContent();
    }

    [HttpDelete("completed-tasks")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult DeleteCompleteToDoList()
    {
        _business.DeleteCompleteToDoList();
        return NoContent();
    }
}
