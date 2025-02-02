using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MinoBank.API.Dtos.UserDtos;
using MinoBank.Core.Interfaces.Services;

namespace MinoBank.API.Controllers
{
    [ApiController]
    [Route("minobank/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;
        public UsersController(IUsersService usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody]UserLoginRequestDto loginDto)
        {
            // Validate the incomming request
            if (loginDto == null)
            {
                return BadRequest("Login data is required");
            }
            try
            {
                // Login action
                var token = await _usersService.Login(loginDto.PhoneNumber, loginDto.Password);

                // Return a 200 OK
                return Ok(token);
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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserRegisterRequestDto registerDto)
        {
            // Validate the incomming request
            if (registerDto == null)
            {
                return BadRequest("Register data is required");
            }
            try
            {
                // Register a new user
                await _usersService.Register
                (
                    registerDto.FirstName,
                    registerDto.LastName,
                    registerDto.Age,
                    registerDto.PhoneNumber,
                    registerDto.Email, 
                    registerDto.Password
                );

                // Return a 201 Created 
                return Created();
            }
            catch (ArgumentException ex)
            {
                // Return a 400 Bad Request response with the error message
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                // Return a 500 Internal Server Error with the error message
                return StatusCode(500, $"Internal server error: {ex.Message}");
            };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseDto>> GetUser(Guid id)
        {
            try
            {
                // Get user by specified ID
                var user = await _usersService.GetUserByIdAsync(id);

                // Map user to user response DTO
                var userDto = _mapper.Map<UserResponseDto>(user);

                // Return a 200 Ok response with user DTO
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

        [HttpPost("{id}/add-role")]
        public async Task<IActionResult> AddRoleToUser([FromQuery]string roleName, Guid id)
        {
            try
            {
                await _usersService.AddRoleToUserAsync(id, roleName);

                return Ok();
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

        [HttpPost("{id}/remove-role")]
        public async Task<IActionResult> RemoveRoleFromUser([FromQuery]string roleName, Guid id)
        {
            try
            {
                await _usersService.RemoveRoleFromUserAsync(id, roleName);

                return Ok();
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