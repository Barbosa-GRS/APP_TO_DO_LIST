using APP_TO_DO_LIST.Integration.Interface;
using APP_TO_DO_LIST.Integration.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APP_TO_DO_LIST.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CepController : ControllerBase
{
    private readonly IViaCepIntegration _viaCepIntegration;
    public CepController(IViaCepIntegration viaCepIntegration)
    {
        _viaCepIntegration = viaCepIntegration;
    }

    [HttpGet("{zipCode}")]
    public async Task<ActionResult<ViaCepResponse>> ListAddress(string zipCode)
    {
        var response = await _viaCepIntegration.GetByViaCep(zipCode);
        if (response == null)
        {
            return BadRequest("Zip Code not found");
        }
        return Ok(response);
    }
}
