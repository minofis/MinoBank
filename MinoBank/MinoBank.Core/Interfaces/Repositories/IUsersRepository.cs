using MinoBank.Core.Entities;

namespace MinoBank.Core.Interfaces.Repositories
{
    public interface IUsersRepository
    {

        Task<UserEntity> GetUserByPhoneNumberAsync(string phoneNumber);
        Task<UserEntity> GetUserByEmailAsync(string email);
        Task<UserEntity> GetUserByIdAsync(Guid id);
        Task AddUserAsync(UserEntity user);
        Task AddRoleToUserAsync(Guid userId, RoleEntity role);
        Task RemoveRoleFromUserAsync(Guid userId, string roleName);
    }
}