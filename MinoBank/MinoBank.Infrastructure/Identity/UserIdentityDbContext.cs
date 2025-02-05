using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MinoBank.Core.Entities.Identity;
using MinoBank.Infrastructure.Identity.Configurations;

namespace MinoBank.Infrastructure.Identity
{
    public class UserIdentityDbContext : IdentityDbContext<UserEntity, RoleEntity, string>
    {
        public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}