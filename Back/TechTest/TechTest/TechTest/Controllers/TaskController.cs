using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TechTest.Business.Interface;
using TechTest.Dto;
using TechTest.Modelos;

namespace TechTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        readonly ITaskBusiness _taskBusiness;
        public TasksController(ITaskBusiness taskBusiness)
        {
            _taskBusiness = taskBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<Response>> GetTasks()
        {
            return Ok(await _taskBusiness.getTasks());
        }
        [HttpPost]
        public async Task<ActionResult<Response>> PostTasks([FromBody] TechTest.Modelos.Task task)
        {
            return Ok(await _taskBusiness.createTask(task));
        }
        [HttpPut]
        [Route("{idTask}/status")]
        public async Task<ActionResult<Response>> PutTasks([FromRoute] int idTask)
        {
            return Ok(await _taskBusiness.updateTaskState(idTask));
        }
    }
}
