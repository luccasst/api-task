using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using crudUser.Models;
using crudUser.Repository.Interfaces;

namespace crudUser.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> BuscarUsuarios()
        {
            List<UserModel> users = await _userRepository.BuscarTodosUsuarios();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserModel>>> BuscarPorId(Guid id)
        {
            UserModel userById = await _userRepository.BuscarPorId(id);
            if (userById == null)
            {
                return NotFound();
            }
            return Ok(userById);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Cadastrar([FromBody] UserModel userModel)
        {
            UserModel user = await _userRepository.Adicionar(userModel);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Atualizar([FromBody] UserModel userModel, Guid id)
        {
            userModel.Id = id;
            UserModel user = await _userRepository.Atualizar(userModel, id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> Apagar(Guid id)
        {
            bool userDelete = await _userRepository.Apagar(id);

            if (!userDelete) {
                return NotFound();
            }
            return Ok( new{ Message = "successfully deleted user"});
        }
    }
}
