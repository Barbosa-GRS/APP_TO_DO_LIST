using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APP_TO_DO_LIST.Controllers
{
    [ApiVersion ("2")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ToDoListController : ControllerBase
    {
        
        private readonly ILogger<ToDoListController> _logger;

        public ToDoListController(ILogger<ToDoListController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()  // for read
        {
            return null;
        }

        [HttpPost]
        public IActionResult Post()  // for create
        {
            return null;
        }

        [HttpPut]
        public IActionResult Put() // for update
        {
            return null;
        }

        [HttpDelete] IActionResult Delete()
        {
            return null;
        }
    }
}
