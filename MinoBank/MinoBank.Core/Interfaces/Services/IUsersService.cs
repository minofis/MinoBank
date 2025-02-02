using MinoBank.Core.Entities;

namespace MinoBank.Core.Interfaces.Services
{
    public interface IUsersService
    {
        Task Register(string firstName, string lastName, int age, string phoneNumber, string email, string password);
        Task<string> Login(string phoneNumber, string password);
        Task AddRoleToUserAsync(Guid userId, string roleName);
        Task RemoveRoleFromUserAsync(Guid userId, string roleName);
        Task<UserEntity> GetUserByIdAsync(Guid userId);
    }
}