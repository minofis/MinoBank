using MinoBank.Core.Entities;

namespace MinoBank.Core.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task CreateUserAsync(User user);
        Task DeleteUserByIdAsync(int userId);
        Task UpdateUserByIdAsync(int userId, User user);
    }
}