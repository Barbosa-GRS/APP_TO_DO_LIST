using APP_TO_DO_LIST.Business;
using APP_TO_DO_LIST.Model;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using System;

namespace APP_TO_DO_LIST.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ToDoListController : ControllerBase
    {

        private readonly ILogger<ToDoListController> _logger;

        private IToDoListBusiness _business;

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
        public IActionResult Post([FromBody] ToDoList toDoList)  // for create fromBory=uses request body parameters
        {
            if (toDoList == null)
             {
                 return BadRequest();
             }
             else
             {
                 return Ok(_business.Create(toDoList));
             }
        }

        [HttpPut]
        public IActionResult Put([FromBody] ToDoList toDoList) // for update
        {
            if (toDoList == null) return BadRequest();
            return Ok(_business.Update(toDoList));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _business.Delete(id);
            return NoContent();
        }
        [HttpDelete]
        public IActionResult DeleteCompleted()
        {
            _business.DeleteCompleted();
            return NoContent();
        }
    }
}
