using MinoBank.API.Dtos.BankCardDtos;

namespace MinoBank.API.Dtos.BankAccountDtos
{
    public class BankAccountResponseDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}