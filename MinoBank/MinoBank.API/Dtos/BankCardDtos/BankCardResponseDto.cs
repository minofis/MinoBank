using MinoBank.API.Dtos.BankTransactionDtos;

namespace MinoBank.API.Dtos.BankCardDtos
{
    public class BankCardResponseDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal Balance { get; set; } = 0;
        public decimal DailyLimit { get; set; }
        public decimal MonthlyLimit { get; set; }
        public decimal AnnualLimit { get; set; }
        public string PinCode { get; set; } = "0000";
        public List<BankTransactionResponseDto> SentTransactions { get; set; } = new List<BankTransactionResponseDto>();
        public List<BankTransactionResponseDto> RecivedTransactions { get; set; } = new List<BankTransactionResponseDto>();
        public Guid BankAccountId { get; set; }
        public BankCardDetailsResponseDto Details { get; set; }
    }
}