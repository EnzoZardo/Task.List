using Microsoft.AspNetCore.Mvc;
using TaskList.Domain.Entities.Tasks;
using TaskList.Domain.Services.Interfaces;
using TaskList.Presentation.Extensions;

namespace TaskList.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController(ITaskServices services) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Find(int id)
            => await services.Find(id).ToValueActionResult();

        [HttpGet]
        public async Task<IActionResult> FindAll()
            => await services.FindAll().ToValueActionResult();

        [HttpPost]
        public async Task<IActionResult> Add(UserTask task) 
            => await services.Add(task).ToValueActionResult();

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
            => await services.Delete(id).ToActionResult();

        [HttpPatch("Conclude/{id}")]
        public async Task<IActionResult> Conclude(int id) 
            => await services.Conclude(id).ToActionResult();
            
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserTask task) 
            => await services.Update(id, task).ToActionResult();
    }
}
