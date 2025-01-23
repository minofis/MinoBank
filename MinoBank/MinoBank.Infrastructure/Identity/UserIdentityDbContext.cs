using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MinoBank.Infrastructure.Identity.Entities;

namespace MinoBank.Infrastructure.Identity
{
    public class UserIdentityDbContext : IdentityDbContext<UserEntity>
    {
        public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options) : base(options){}

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}