using Microsoft.AspNetCore.Mvc;
using MinoBank.API.Dtos;
using MinoBank.Core.Entities;
using MinoBank.Core.Interfaces;

namespace MinoBank.API.Controllers
{
    [ApiController]
    [Route("minobank/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepo;
        public UsersController(IUsersRepository usersRepo)
        {
            _usersRepo = usersRepo;
        }

        [HttpGet]
        public async Task<List<User>> GetAllUsers(){
            return await _usersRepo.GetAllUsersAsync();
        }

        [HttpPost]
        [Route("Create")]
        public async Task CreateUser(UserCreateRequestDto userDto){
            var user = new User{
                Username = userDto.Username,
                Email = userDto.Email,
                Password = userDto.Password
            };
            await _usersRepo.CreateUserAsync(user);
        }
    }
}