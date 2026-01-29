using Microsoft.AspNetCore.Mvc;

namespace TaskList.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() 
            => Ok("Oie");
    }
}
