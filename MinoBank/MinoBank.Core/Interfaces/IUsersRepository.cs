using MinoBank.Core.Entities;

namespace MinoBank.Core.Interfaces
{
    public interface IUsersRepository
    {
        public Task<List<User>> GetAllUsersAsync();
        public Task<User> GetUserByIdAsync(int userId);
        public Task CreateUserAsync(User user);
        public Task DeleteUserByIdAsync(int userId);
        public Task UpdateUserByIdAsync(int userId, User user);
    }
}