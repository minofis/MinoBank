using MinoBank.Core.Entities;

namespace MinoBank.Core.Interfaces.Services
{
    public interface IUsersService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid userId);
        Task CreateUserAsync(User user);
        Task DeleteUserByIdAsync(Guid userId);
    }
}