using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using crudUser.Models;
using crudUser.Repository.Interfaces;

namespace crudUser.Controllers
{
    [Route("api/[controller]")]
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

        [HttpPost]
        public async Task<ActionResult<UserModel>> Cadastrar([FromBody] UserModel userModel)
        {
            UserModel user = await _userRepository.Adicionar(userModel);

            return Ok(user);
        }
    }
}