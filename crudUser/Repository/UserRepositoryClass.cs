using crudUser.Data;
using crudUser.Models;
using crudUser.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace crudUser.Repository
{
    public class UsersRepository : IUserRepository
    {
        private readonly SystemTask _dbContext;
        public UsersRepository(SystemTask systemTask)
        {
            _dbContext = systemTask;
        }

        public async Task<UserModel> BuscarPorId(int id)
        {
           return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UserModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UserModel> Adicionar(UserModel usuario)
        {
           await _dbContext.Usuarios.AddAsync(usuario);
           await _dbContext.SaveChangesAsync();
            return usuario;
        }


        public async Task<UserModel> Atualizar(UserModel user, int id)
        {
            UserModel userId = await BuscarPorId(id);
            if(userId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado");
            }
            userId.Name = user.Name;
            userId.Email = user.Email;

            _dbContext.Usuarios.Update(userId);
            await _dbContext.SaveChangesAsync();
            return userId;
        }

        public async Task<bool> Apagar(int id)
        {
            UserModel userId = await BuscarPorId(id);

            if(userId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado");
            }
            _dbContext.Usuarios.Remove(userId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}