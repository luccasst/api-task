using crudUser.Models;

namespace crudUser.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<List <UserModel>> BuscarTodosUsuarios();
        Task<UserModel> BuscarPorId(Guid id);
        Task<UserModel> Adicionar(UserModel usuario);
        Task<UserModel> Atualizar(UserModel usuario, Guid id);
        Task<bool> Apagar(Guid id);
    }
}