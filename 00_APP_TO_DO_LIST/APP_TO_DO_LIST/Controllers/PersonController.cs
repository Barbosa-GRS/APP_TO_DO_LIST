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
    private readonly ILogger<PersonController> _logger;
    private readonly IPersonBusiness _personBusiness;

    public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
    {
        _logger = logger;
        _personBusiness = personBusiness;
    }


    [HttpGet]

    public IActionResult Get()
    {
        return Ok(_personBusiness.FindAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        return Ok(_personBusiness.FindById(id));
    }

    [HttpPost]
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
    public IActionResult Delete([FromRoute] int id)
    {
        _personBusiness.Delete(id);
        return NoContent();
    }



}
