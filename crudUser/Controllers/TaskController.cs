using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using crudUser.Models;
using crudUser.Repository.Interfaces;

namespace crudUser.Controllers
{
    [Route("api/Task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> BuscarTodasTarefas()
        {
            List<TaskModel> users = await _taskRepository.BuscarTodasTarefas();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TaskModel>>> BuscarPorId(Guid id)
        {
            TaskModel taskById = await _taskRepository.BuscarPorId(id);
            if (taskById == null)
            {
                return NotFound();
            }
            return Ok(taskById);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> Cadastrar([FromBody] TaskModel taskModel)
        {
            TaskModel user = await _taskRepository.Adicionar(taskModel);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> Atualizar([FromBody] TaskModel taskModel, Guid id)
        {
            taskModel.Id = id;
            TaskModel user = await _taskRepository.Atualizar(taskModel, id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> Apagar(Guid id)
        {
            bool TaskDelete = await _taskRepository.Apagar(id);

            if (!TaskDelete) {
                return NotFound();
            }
            return Ok( new{ Message = "successfully deleted task"});
        }
    }
}
