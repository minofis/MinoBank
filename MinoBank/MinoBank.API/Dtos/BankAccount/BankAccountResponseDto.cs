using MinoBank.API.Dtos.BankAccountDetails;
using MinoBank.Core.Entities;

namespace MinoBank.API.Dtos.BankAccount
{
    public class BankAccountResponseDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public List<BankCard> BankCards { get; set; } = new List<BankCard>();
        public BankAccountDetailsResponseDto? Details { get; set; }
    }
}