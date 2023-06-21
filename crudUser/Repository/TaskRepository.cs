using crudUser.Data;
using crudUser.Models;
using crudUser.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace crudUser.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly SystemTask _dbContext;
        public TaskRepository(SystemTask systemTask)
        {
            _dbContext = systemTask;
        }

        public async Task<TaskModel> BuscarPorId(Guid id)
        {
           return await _dbContext.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TaskModel>> BuscarTodasTarefas()
        {
            return await _dbContext.Tarefas.ToListAsync();
        }

        public async Task<TaskModel> Adicionar(TaskModel tarefa)
        {
           await _dbContext.Tarefas.AddAsync(tarefa);
           await _dbContext.SaveChangesAsync();
            return tarefa;
        }


        public async Task<TaskModel> Atualizar(TaskModel task, Guid id)
        {
            TaskModel taskId = await BuscarPorId(id);
            if(taskId == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrado");
            }
            taskId.Name = task.Name;
            taskId.Description = task.Description;
            taskId.Status = task.Status;
            taskId.UserId = task.UserId;

            _dbContext.Tarefas.Update(taskId);
            await _dbContext.SaveChangesAsync();
            return taskId;
        }

        public async Task<bool> Apagar(Guid id)
        {
            TaskModel taskId = await BuscarPorId(id);

            if(taskId == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrado");
            }
            _dbContext.Tarefas.Remove(taskId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}