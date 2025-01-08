using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MinoBank.API.Dtos.UserDtos;
using MinoBank.Core.Entities;
using MinoBank.Core.Interfaces.Services;

namespace MinoBank.API.Controllers
{
    [ApiController]
    [Route("minobank/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserResponseDto>>> GetAllUsers()
        {
            // Get all users
            var users = await _usersService.GetAllUsersAsync();

            // Map the user to a list of response DTOs
            var userDtos = _mapper.Map<List<UserResponseDto>>(users);

            // Return a 200 Ok response with the list of users
            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseDto>> GetUser(Guid id)
        {
            try
            {
                // Get user by the specified ID
                var user = await _usersService.GetUserByIdAsync(id);

                // Map the user to response DTO
                var userDto = _mapper.Map<UserResponseDto>(user);

                // Return a 200 Ok response with the user
                return Ok(userDto);
            }
            catch (ArgumentException ex)
            {
                // Return a 404 Not Found response with the error message
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                // Return a 500 Internal Server Error with the error message
                return StatusCode(500, $"Internal server error: {ex.Message}");
            };
        }

        [HttpPost]
        public async Task<ActionResult<UserResponseDto>> Create([FromBody]UserCreateRequestDto userDto)
        {
            // Validate the incomming request
            if (userDto == null)
            {
                return BadRequest("User data is required");
            }
            try
            {
                // Map the request DTO to a user entity
                var user = _mapper.Map<User>(userDto);

                // Create a new user
                await _usersService.CreateUserAsync(user);

                // Map the user entity to a response DTO
                var userResponseDto = _mapper.Map<UserResponseDto>(user);

                // Return a 201 Created response with the user
                return CreatedAtAction(nameof(GetUser), new {id = user.Id}, userResponseDto);
            }
            catch(Exception ex)
            {
                // Return a 500 Internal Server Error with the error message
                return StatusCode(500, $"Internal server error: {ex.Message}");
            };
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                // Delete user service method
                await _usersService.DeleteUserByIdAsync(id);

                // Return a 200 Ok response
                return Ok("User is deleted successfully");
            }
            catch (ArgumentException ex)
            {
                // Return a 404 Not Found response with the error message
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                // Return a 500 Internal Server Error with the error message
                return StatusCode(500, $"Internal server error: {ex.Message}");
            };
        }
    }
}