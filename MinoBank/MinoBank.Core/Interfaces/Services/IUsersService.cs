using System.Security.Claims;
using MinoBank.Core.Entities.Identity;

namespace MinoBank.Core.Interfaces.Services
{
    public interface IUsersService
    {
        Task Register(string userName,string firstName, string lastName, int age, string phoneNumber, string email, string password);
        Task<string> Login(string phoneNumber, string password);
        Task AssignRoleToUserAsync(Guid userId, string roleName);
        Task RemoveRoleFromUserAsync(Guid userId, string roleName);
        Task<UserEntity> GetUserByIdAsync(Guid userId);
        Task<string> GetUserIdAsync(ClaimsPrincipal user);
    }
}