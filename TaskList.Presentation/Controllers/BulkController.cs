using Microsoft.AspNetCore.Mvc;
using TaskList.Domain.Services.Interfaces;
using TaskList.Presentation.Extensions;

namespace TaskList.Presentation.Controllers
{
    [Route("api/Tasks/[controller]")]
    [ApiController]
    public class BulkController(ITaskServices services) : ControllerBase
    {
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] IEnumerable<int> ids) 
            => await services.Delete(ids).ToActionResult();

        [HttpPatch("Conclude")]
        public async Task<IActionResult> Conclude([FromQuery] IEnumerable<int> ids) 
            => await services.Conclude(ids).ToActionResult();
    }
}
