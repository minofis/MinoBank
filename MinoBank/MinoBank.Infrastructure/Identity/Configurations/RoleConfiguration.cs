using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinoBank.Core.Entities;

namespace MinoBank.Infrastructure.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder
                .HasData(
                    new RoleEntity{Id = 1, Name = "ADMIN"},
                    new RoleEntity{Id = 2, Name = "CUSTOMER"}
                );
        }
    }
}