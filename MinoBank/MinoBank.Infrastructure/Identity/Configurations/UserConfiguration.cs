using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinoBank.Core.Entities.Identity;

namespace MinoBank.Infrastructure.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder
                .HasData(
                    new UserEntity
                    {
                        Id = "ed442e80-4b55-403a-a160-2fed26a45dc7",
                        UserName = "admin",
                        FirstName = "admin",
                        LastName = "admin",
                        FullName = $"admin admin",
                        Age = 0,
                        PhoneNumber = "+777",
                        Email = "admin@mail.com",
                        PasswordHash = "AQAAAAIAAYagAAAAEGK35bXYasW9FUAyaVxmN7XxMXukoxqbUZR0SeRjXKyT/6pmQ+sa32ptd0KLMmO66Q=="
                    }
                );
        }
    }
}