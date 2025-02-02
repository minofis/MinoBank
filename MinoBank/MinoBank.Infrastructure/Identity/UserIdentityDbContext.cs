using Microsoft.EntityFrameworkCore;
using MinoBank.Core.Entities;
using MinoBank.Core.Entities.Identity;
using MinoBank.Infrastructure.Identity.Configurations;

namespace MinoBank.Infrastructure.Identity
{
    public class UserIdentityDbContext : DbContext
    {
        public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options) : base(options){}
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}