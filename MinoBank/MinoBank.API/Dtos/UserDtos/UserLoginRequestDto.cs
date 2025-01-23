using System.ComponentModel.DataAnnotations;

namespace MinoBank.API.Dtos.UserDtos
{
    public class UserLoginRequestDto
    {
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}