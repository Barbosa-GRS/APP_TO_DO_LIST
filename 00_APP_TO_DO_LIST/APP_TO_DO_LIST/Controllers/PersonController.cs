using APP_TO_DO_LIST.Business;
using APP_TO_DO_LIST.Model;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APP_TO_DO_LIST.Controllers;

[ApiVersion("1")]
[ApiController]
[Route("api/[controller]/v{version:apiVersion}")]

public class PersonController : ControllerBase
{
    private readonly IPersonBusiness _personBusiness;

    public PersonController(IPersonBusiness personBusiness)
    {
        _personBusiness = personBusiness;
    }

    [HttpGet]
    [ProducesResponseType((200), Type = typeof(List<Person>))] //OK
    [ProducesResponseType(204)] //No Content
    [ProducesResponseType(400)] //Bad Request
    [ProducesResponseType(401)] //Unauthorized

    public IActionResult Get()
    {
        return Ok(_personBusiness.FindAll());
    }

    [HttpGet("{id}")]
    [ProducesResponseType((200), Type = typeof(Person))]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult GetById([FromRoute] int id)
    {
        return Ok(_personBusiness.GetById(id));
    }

    [HttpPost]
    [ProducesResponseType((200), Type = typeof(Person))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult Post([FromBody] Person person)
    {
        if (person == null)
        {
            return BadRequest();
        }

        _personBusiness.Create(person);
        return Ok(person);
    }

    [HttpPut]
    [ProducesResponseType((200), Type = typeof(Person))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult Put([FromBody] Person person)
    {
        if (person == null)
        {
            return NoContent();
        }
        _personBusiness.Update(person);
        return Ok(person);
    }



    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult Delete([FromRoute] int id)
    {
        _personBusiness.Delete(id);
        return NoContent();
    }



}
