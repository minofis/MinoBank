using Microsoft.AspNetCore.Mvc;
using MinoBank.API.Dtos;
using MinoBank.Core.Entities;
using MinoBank.Core.Interfaces.Repositories;

namespace MinoBank.API.Controllers
{
    [ApiController]
    [Route("MinoBank/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepo;
        public UsersController(IUsersRepository usersRepo)
        {
            _usersRepo = usersRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return await _usersRepo.GetAllUsersAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            var user = await _usersRepo.GetUserByIdAsync(id);
            if(user == null){
                return BadRequest();
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("Create")]
        public async Task CreateUser([FromBody]UserCreateRequestDto userDto)
        {
            var user = new User{
                Username = userDto.Username,
                Email = userDto.Email,
                Password = userDto.Password,
                CreationDate = DateTime.Now
            };
            await _usersRepo.CreateUserAsync(user);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task DeleteUserById(Guid id)
        {
            await _usersRepo.DeleteUserByIdAsync(id);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task UpdateUserById(Guid id, UserCreateRequestDto userDto)
        {
            var user = new User{
                Username = userDto.Username,
                Email = userDto.Email,
                Password = userDto.Password
            };
            await _usersRepo.UpdateUserByIdAsync(id, user);
        }
    }
}