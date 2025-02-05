using System.ComponentModel.DataAnnotations;

namespace MinoBank.API.Dtos.UserDtos
{
    public class UserRegisterRequestDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public int Age { get; set; }
        [Required]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}