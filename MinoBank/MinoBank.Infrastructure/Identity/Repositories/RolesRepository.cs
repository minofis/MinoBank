using Microsoft.EntityFrameworkCore;
using MinoBank.Core.Entities;
using MinoBank.Core.Interfaces.Repositories;

namespace MinoBank.Infrastructure.Identity.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private readonly UserIdentityDbContext _context;
        public RolesRepository(UserIdentityDbContext context)
        {
            _context = context;
        }

        public async Task<RoleEntity> GetRoleByNameAsync(string roleName)
        {
            return await _context.Roles
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Name == roleName);
        }
    }
}