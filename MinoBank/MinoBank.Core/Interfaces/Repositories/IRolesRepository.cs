using MinoBank.Core.Entities;

namespace MinoBank.Core.Interfaces.Repositories
{
    public interface IRolesRepository
    {
        Task<List<RoleEntity>> GetAllRolesAsync();
        Task Create(RoleEntity role);
    }
}