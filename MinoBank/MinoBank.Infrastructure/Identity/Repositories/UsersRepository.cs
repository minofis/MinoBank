using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MinoBank.Core.Entities;
using MinoBank.Core.Interfaces.Repositories;

namespace MinoBank.Infrastructure.Identity.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UserIdentityDbContext _context;
        public UsersRepository(UserIdentityDbContext context)
        {
            _context = context;
        }
        public async Task<UserEntity> GetUserByPhoneNumberAsync(string phoneNumber)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        }

        public async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UserEntity> GetUserByIdAsync(Guid id)
        {
            return await _context.Users
                .Include(u => u.Roles)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
        }
        
        public async Task AddUserAsync(UserEntity user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task AddRoleToUserAsync(Guid userId, RoleEntity role)
        {
            var user = await _context.Users
                .Include(u => u.Roles)
                .FirstOrDefaultAsync(u => u.Id == userId);

            user.AddRole(role);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRoleFromUserAsync(Guid userId, string roleName)
        {
            var user = await _context.Users
                .Include(u => u.Roles)
                .FirstOrDefaultAsync(u => u.Id == userId);

            user.RemoveRole(roleName);
            await _context.SaveChangesAsync();
        }
    }
}