namespace MinoBank.API.Dtos.BankTransactionDtos
{
    public class BankTransactionResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public decimal Commission { get; set; }
        public string CurrencyCode { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string CreationDate { get; set; } = string.Empty;
        public Guid SenderBankCardId { get; set; }
        public Guid RecipientBankCardId { get; set; }
    }
}