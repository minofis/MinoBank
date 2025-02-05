using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MinoBank.Infrastructure.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder
                .HasData(
                    new IdentityUserRole<string>{RoleId = "58874eb2-13a9-423e-950d-571b65771274", UserId = "ed442e80-4b55-403a-a160-2fed26a45dc7"}
                );
        }
    }
}