using MinoBank.Core.Entities;

namespace MinoBank.Core.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid userId);
        Task CreateUserAsync(User user);
        Task DeleteUserByIdAsync(Guid userId);
        Task UpdateUserByIdAsync(Guid userId, User user);
    }
}