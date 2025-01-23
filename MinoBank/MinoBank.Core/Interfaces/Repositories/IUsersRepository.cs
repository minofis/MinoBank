using MinoBank.Core.Entities;

namespace MinoBank.Core.Interfaces.Repositories
{
    public interface IUsersRepository
    {

        Task<User> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
    }
}