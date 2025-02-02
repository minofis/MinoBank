using Microsoft.EntityFrameworkCore;
using MinoBank.Core.Entities;

namespace MinoBank.Infrastructure.Identity
{
    public class UserIdentityDbContext : DbContext
    {
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options) : base(options){}
    }
}