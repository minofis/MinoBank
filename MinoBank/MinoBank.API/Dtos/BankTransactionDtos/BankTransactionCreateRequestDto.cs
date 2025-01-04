using MinoBank.Core.Enums.BankTransaction;

namespace MinoBank.API.Dtos.BankTransactionDtos
{
    public class BankTransactionCreateRequestDto
    {
        public string SenderBankCardNumber { get; set; } = string.Empty;
        public string RecipientBankCardNumber { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public BankTransactionCurrencyCode CurrencyCode { get; set; }
    }
}