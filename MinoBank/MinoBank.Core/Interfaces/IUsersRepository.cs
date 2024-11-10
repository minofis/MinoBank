using MinoBank.Core.Entities;

namespace MinoBank.Core.Interfaces
{
    public interface IUsersRepository
    {
        public Task<List<User>> GetAllUsersAsync();
        public Task CreateUserAsync(User user);
    }
}