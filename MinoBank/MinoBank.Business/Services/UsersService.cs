using MinoBank.Core.Entities;
using MinoBank.Core.Interfaces.Repositories;
using MinoBank.Core.Interfaces.Services;

namespace MinoBank.Business.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepo;
        public UsersService(IUsersRepository usersRepo)
        {
            _usersRepo = usersRepo;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _usersRepo.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            // Get user by specificated ID
            var user = await _usersRepo.GetUserByIdAsync(userId)
                ?? throw new ArgumentException($"User with ID {userId} not found.");

            // Return user
            return user;
        }

        public async Task CreateUserAsync(User user)
        {
            await _usersRepo.CreateUserAsync(user);
        }

        public async Task DeleteUserByIdAsync(Guid userId)
        {
            await _usersRepo.DeleteUserByIdAsync(userId);
        }
    }
}