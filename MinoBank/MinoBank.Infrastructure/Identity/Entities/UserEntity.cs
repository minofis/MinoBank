using Microsoft.AspNetCore.Identity;

namespace MinoBank.Infrastructure.Identity.Entities
{
    public class UserEntity : IdentityUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}