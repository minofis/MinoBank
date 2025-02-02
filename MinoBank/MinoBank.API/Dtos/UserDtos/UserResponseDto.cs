using MinoBank.Core.Entities;

namespace MinoBank.API.Dtos.UserDtos
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<RoleEntity> Roles { get; set; }
    }
}