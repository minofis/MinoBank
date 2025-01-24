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
        private readonly IMapper _mapper;
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/login")]
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

                // Return a 200 Ok 
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

        [HttpPost]
        [Route("/register")]
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
                await _usersService.Register(registerDto.FirstName, registerDto.LastName, registerDto.Age, registerDto.PhoneNumber, registerDto.Email, registerDto.Password);

                // Return a 200 Ok 
                return Ok("User registered successfully");
            }
            catch(Exception ex)
            {
                // Return a 500 Internal Server Error with the error message
                return StatusCode(500, $"Internal server error: {ex.Message}");
            };
        }
    }
}