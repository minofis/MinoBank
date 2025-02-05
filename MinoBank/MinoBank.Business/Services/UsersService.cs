using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MinoBank.Core.Entities.Identity;
using MinoBank.Core.Interfaces.Auth;
using MinoBank.Core.Interfaces.Services;

namespace MinoBank.Business.Services
{
    public class UsersService : IUsersService
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<RoleEntity> _roleManager;
        public UsersService( IJwtProvider jwtProvider, UserManager<UserEntity> userManager, RoleManager<RoleEntity> roleManager)
        {
            _jwtProvider = jwtProvider;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<string> Login(string phoneNumber, string password)
        {
            // Get user by phone number
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber)
                ?? throw new ArgumentException($"User with phone number {phoneNumber} not found.");


            // Verify that password is correct
            var result = await _userManager.CheckPasswordAsync(user, password);

            // Validate password
            if (result == false)
            {
                throw new ArgumentException("Login is failed");
            }

            var roles = await _userManager.GetRolesAsync(user);

            // Generate jwt token for the user
            var token = _jwtProvider.GenerateToken(user, roles);

            // Return token
            return token;
        }

        public async Task Register(string userName, string firstName, string lastName, int age, string phoneNumber, string email, string password)
        {
            if(await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber) != null)
            {
                throw new ArgumentException($"User with phone number {phoneNumber} alredy exist");
            }

            if(await _userManager.Users.FirstOrDefaultAsync(u => u.Email == email) != null)
            {
                throw new ArgumentException($"User with email {email} alredy exist");
            }

            var user = new UserEntity()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = userName,
                FirstName = firstName,
                LastName = lastName,
                FullName = $"{firstName} {lastName}",
                Age = age,
                PhoneNumber = phoneNumber,
                Email = email
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    throw new ArgumentException($"Error: {error.Description}");
                }
            }

            await _userManager.AddToRoleAsync(user, "Customer");
        }

        public async Task<UserEntity> GetUserByIdAsync(Guid userId)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId.ToString())
                ?? throw new ArgumentException($"User with ID {userId} not found.");
        }

        public async Task AssignRoleToUserAsync(Guid userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString())
                ?? throw new ArgumentException($"User with ID {userId} not found.");

            var roleExists = await _roleManager.RoleExistsAsync(roleName);

            if (!roleExists)
            {
                throw new ArgumentException($"Role with name {roleName} not found.");
            }

            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task RemoveRoleFromUserAsync(Guid userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString())
                ?? throw new ArgumentException($"User with ID {userId} not found.");

            await _userManager.RemoveFromRoleAsync(user, roleName);
        }

        public async Task<string> GetUserIdAsync(ClaimsPrincipal user)
        {
            return user.FindFirst("userId")?.Value;
        }
    }
}