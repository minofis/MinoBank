using MinoBank.Core.Entities;

namespace MinoBank.Core.Interfaces.Repositories
{
    public interface IRolesRepository
    {
        Task<RoleEntity> GetRoleByNameAsync(string roleName);
    }
}