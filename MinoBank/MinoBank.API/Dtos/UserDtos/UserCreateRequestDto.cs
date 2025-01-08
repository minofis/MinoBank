using System.ComponentModel.DataAnnotations;

namespace MinoBank.API.Dtos.UserDtos
{
    public class UserCreateRequestDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}