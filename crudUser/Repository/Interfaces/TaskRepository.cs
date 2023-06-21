using crudUser.Models;

namespace crudUser.Repository.Interfaces
{
    public interface ITaskRepository
    {
        Task<List <TaskModel>> BuscarTodasTarefas();
        Task<TaskModel> BuscarPorId(Guid id);
        Task<TaskModel> Adicionar(TaskModel usuario);
        Task<TaskModel> Atualizar(TaskModel usuario, Guid id);
        Task<bool> Apagar(Guid id);
    }
}