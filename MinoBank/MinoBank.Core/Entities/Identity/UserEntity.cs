using Microsoft.AspNetCore.Identity;

namespace MinoBank.Core.Entities.Identity
{
    public class UserEntity : IdentityUser
    {
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}