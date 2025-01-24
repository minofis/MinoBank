using MinoBank.Core.Entities;

namespace MinoBank.Core.Interfaces.Repositories
{
    public interface IUsersRepository
    {

        Task<User> GetUserByPhoneNumberAsync(string phoneNumber);
        Task AddUserAsync(User user);
    }
}